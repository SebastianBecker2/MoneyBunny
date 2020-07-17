using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoneyBunny
{
    class MvbParser
    {
        private readonly static string FirstPageStart = "alter Kontostand vom";
        private readonly static string PageEnd = "Übertrag auf Blatt";
        private readonly static string PageStart = "Übertrag von Blatt";
        private readonly static string LastPageEnd = "neuer Kontostand vom";

        private int CurrentIndex = 0;
        private int CurrentPage = 0;
        private string FileContent;
        private int PageCount = 0;

        public List<Transaction> Transactions = new List<Transaction>();

        Dictionary<int, int> Carryover = new Dictionary<int, int>();

        public MvbParser(string file_content)
        {
            FileContent = file_content;
        }

        int SkipAfterString(int index, string substring, int count = 1)
        {
            foreach (var _ in Enumerable.Range(0, count))
            {
                index = FileContent.IndexOf(substring, index) + substring.Length;
            }
            return index;
        }

        int SkipLines(int index, int line_count = 1)
        {
            return SkipAfterString(index, Environment.NewLine, line_count);
        }

        int SkipWords(int index, int word_count = 1)
        {
            return SkipAfterString(index, " ", word_count);
        }

        static DateTime ParseShortDate(string text, int index = 0)
        {
            return DateTime.ParseExact(text.Substring(0, 6), "dd.MM.", CultureInfo.InvariantCulture);
        }

        DateTime ParseShortDate()
        {
            var date_string = FileContent.Substring(CurrentIndex, 6);
            CurrentIndex += 7;
            return ParseShortDate(date_string);
        }

        int ParseValue(string value_as_text)
        {
            var text = value_as_text.Trim(' ', '\r', '\n');

            var amount_as_text = text.Trim(' ', 'S', 'H');
            var amount = double.Parse(amount_as_text, NumberStyles.Any, CultureInfo.GetCultureInfo("de-DE"));

            if (text.EndsWith(" S"))
            {
                return (int)(amount * -100);
            }
            else if (text.EndsWith(" H"))
            {
                return (int)(amount * 100);
            }
            else
            {
                throw new ArgumentException("value format is invalid", nameof(value_as_text));
            }
        }

        static string ParseTransactionType(string text, int index = 0)
        {
            var end_of_type_index = text.IndexOf("PN:", index);
            return text.Substring(index, (end_of_type_index - 1) - index);
        }

        void ParseTransactions(string transactions_text)
        {
            Transaction transaction = null;

            foreach (var line in transactions_text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!line.StartsWith(" "))
                {
                    transaction = new Transaction();
                    Transactions.Add(transaction);

                    transaction.Date = ParseShortDate(line);
                    transaction.Type = ParseTransactionType(line, 14);
                    var index = line.IndexOf("PN:", 14);
                    index = line.IndexOf(' ', index);
                    transaction.Value = ParseValue(line.Substring(index));
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(transaction.Reference))
                {
                    transaction.Reference += Environment.NewLine;
                }
                transaction.Reference += line.Trim();
            }
        }

        int GetStartOfPage()
        {
            if (CurrentPage == 0)
            {
                var index = FileContent.IndexOf(FirstPageStart, CurrentIndex);
                index += FirstPageStart.Length;
                while (!char.IsDigit(FileContent[index]))
                {
                    index = SkipLines(index, 1);
                }
                return index;
            }
            else
            {
                var index = FileContent.IndexOf(PageStart, CurrentIndex) + PageStart.Length + 2;

                var index_after_carryover = SkipLines(index, 1);
                var value = ParseValue(FileContent.Substring(index, index_after_carryover - index));

                if (Carryover[CurrentPage - 1] != value)
                {
                    throw new Exception("Carryover-Check failed on Page: " + CurrentPage + 1);
                }

                return SkipLines(index_after_carryover, 1);
            }
        }

        int GetEndOfPage()
        {
            if (CurrentPage == PageCount - 1)
            {
                return FileContent.IndexOf(LastPageEnd, CurrentIndex);
            }
            else
            {
                var index = FileContent.IndexOf(PageEnd, CurrentIndex);
                var index_before_carryover = index + PageEnd.Length + 2;

                var index_after_carryover = SkipLines(index_before_carryover, 1);
                var value_text = FileContent.Substring(index_before_carryover, index_after_carryover - index_before_carryover);

                Carryover[CurrentPage] = ParseValue(value_text);

                return index;
            }
        }

        public bool Parse()
        {
            if (string.IsNullOrWhiteSpace(FileContent))
            {
                return false;
            }

            var first_page_start_pos = FileContent.IndexOf(FirstPageStart);
            if (first_page_start_pos == -1)
            {
                return false;
            }

            var last_page_end_pos = FileContent.IndexOf(LastPageEnd);
            if (last_page_end_pos == -1)
            {
                return false;
            }

            PageCount = Regex.Matches(FileContent, PageEnd).Count + 1;

            var transactions = "";

            foreach (var page in Enumerable.Range(0, PageCount))
            {
                CurrentPage = page;
                CurrentIndex = GetStartOfPage();
                var end_of_page_pos = GetEndOfPage();

                transactions += FileContent.Substring(CurrentIndex, end_of_page_pos - CurrentIndex);
                transactions = transactions.Trim(' ');

            }

            ParseTransactions(transactions);
            return true;
        }
    }
}
