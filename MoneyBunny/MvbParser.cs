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
        class MvbValue : Value
        {
            public MvbValue(string value_as_text)
            {
                var text = value_as_text.Trim(' ', '\r', '\n');

                if (text.EndsWith(" S"))
                {
                    Sign = Sign.Negative;
                }
                else if (text.EndsWith(" H"))
                {
                    Sign = Sign.Positive;
                }
                else
                {
                    throw new ArgumentException("value format is invalid", nameof(value_as_text));
                }

                text = text.Trim(' ', 'S', 'H');
                var new_amount = double.Parse(text, NumberStyles.Any, CultureInfo.GetCultureInfo("de-DE"));
                Amount = (int)(new_amount * 100);
            }
        }

        private readonly static string FirstPageStart = "alter Kontostand vom";
        private readonly static string PageEnd = "Übertrag auf Blatt";
        private readonly static string PageStart = "Übertrag von Blatt";
        private readonly static string LastPageEnd = "neuer Kontostand vom";

        private int CurrentIndex = 0;
        private int CurrentPage = 0;
        private string FileContent;
        private int PageCount = 0;

        public List<Transaction> Transactions = new List<Transaction>();

        Dictionary<int, Value> Carryover = new Dictionary<int, Value>();

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

        DateTime ParseShortDate()
        {
            var date_string = FileContent.Substring(CurrentIndex, 6);
            CurrentIndex += 7;
            return DateTime.ParseExact(date_string, "dd.MM.", CultureInfo.InvariantCulture);
        }

        TransactionType ParseTransactionType()
        {
            var end_of_type_index = FileContent.IndexOf("PN:", CurrentIndex);
            var type = FileContent.Substring(CurrentIndex, (end_of_type_index - 1) - CurrentIndex);
            CurrentIndex = end_of_type_index;

            if (type == "SEPA-BASISLASTSCHR.")
            {
                return TransactionType.DirectDebit;
            }
            else if (type == "Kartenzahlung girocard")
            {
                return TransactionType.CardPayment;
            }
            else if (type == "SEPA-ÜBERWEISUNG")
            {
                return TransactionType.Transfer;
            }
            throw new Exception("Unkown TransactionType: '" + type + "'");
        }

        void ParseTransaction()
        {
            int next_line_index = CurrentIndex;
            var line = 0;
            var transaction = new Transaction();

            do
            {
                next_line_index = SkipLines(CurrentIndex, 1);
                if (line == 0)
                {
                    transaction.Date = ParseShortDate();
                    ParseShortDate();
                    transaction.Type = ParseTransactionType();
                    CurrentIndex = SkipWords(CurrentIndex, 1);
                    var index_after_value = SkipLines(CurrentIndex, 1);
                    var amount = FileContent.Substring(CurrentIndex, index_after_value - CurrentIndex);
                    transaction.Value = new MvbValue(amount);
                }
                else
                {
                    var end_of_line_index = SkipLines(CurrentIndex, 1);
                    transaction.Reference += FileContent.Substring(CurrentIndex, end_of_line_index - CurrentIndex);
                    CurrentIndex = end_of_line_index;
                }
                line++;
            } while (FileContent[next_line_index] == ' ');

            Transactions.Add(transaction);
        }

        int GetStartOfPage()
        {
            if (CurrentPage == 0)
            {
                var index = FileContent.IndexOf(FirstPageStart, CurrentIndex);
                index += FirstPageStart.Length;

                // If we want the date:
                //var date_string = FileContent.Substring(index + 1, 10);
                //var from_date = DateTime.ParseExact(date_string, "dd.MM.yyyy", CultureInfo.InvariantCulture);

                // If we want the value:
                //var index_before_carryover = SkipLines(index, 2);
                //var index_after_carryover = SkipLines(index_before_carryover, 1);
                //var value = new MvbValue(FileContent.Substring(index_before_carryover, index_after_carryover - index_before_carryover));
                //Carryover[CurrentPage] = value;

                index = SkipLines(index, 3);

                return index;
            }
            else
            {
                var index = FileContent.IndexOf(PageStart, CurrentIndex) + PageStart.Length + 2;

                var index_after_carryover = SkipLines(index, 1);
                var value = new MvbValue(FileContent.Substring(index, index_after_carryover - index));

                if (Carryover[CurrentPage - 1] != value)
                {
                    throw new Exception("Carryover-Check failed on Page: " + CurrentPage + 1);
                }

                return SkipLines(index_after_carryover, 2);
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
                var index = FileContent.IndexOf(PageEnd, CurrentIndex) + PageEnd.Length + 2;

                var index_after_carryover = SkipLines(index, 1);
                var value = new MvbValue(FileContent.Substring(index, index_after_carryover - index));

                Carryover[CurrentPage] = value;

                return index_after_carryover;
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

            foreach (var page in Enumerable.Range(0, PageCount))
            {
                CurrentPage = page;
                CurrentIndex = GetStartOfPage();
                var end_of_page_pos = GetEndOfPage();

                do
                {
                    ParseTransaction();
                } while (CurrentIndex < end_of_page_pos);
            }
            return true;
        }
    }
}
