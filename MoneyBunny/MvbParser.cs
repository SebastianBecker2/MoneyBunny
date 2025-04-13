using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace MoneyBunny
{
    class MvbParser
    {
        private readonly static string YearOfTransactionPrefix = "Kontoauszug";

        private int CurrentIndex = 0;
        private string FileContent;

        private int YearOfTransactions;

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

        DateTime ParseShortDate(string text, int index = 0)
        {
            return ParseLongDate(text.Substring(index, 6) + YearOfTransactions.ToString());
        }

        DateTime ParseShortDate()
        {
            var date_string = FileContent.Substring(CurrentIndex, 6);
            CurrentIndex += 7;
            return ParseShortDate(date_string);
        }

        DateTime ParseLongDate(string text, int index = 0)
        {
            return DateTime.ParseExact(text.Substring(index, 10), "dd.MM.yyyy", CultureInfo.InvariantCulture);
        }

        DateTime ParseLongDate()
        {
            var date_string = FileContent.Substring(CurrentIndex, 10);
            CurrentIndex += 11;
            return ParseLongDate(date_string);
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

        int GetYearOfTransaction()
        {
            var prefix_index = FileContent.IndexOf(YearOfTransactionPrefix);
            prefix_index += YearOfTransactionPrefix.Length;
            while (FileContent[prefix_index] != '/')
            {
                ++prefix_index;
            }
            ++prefix_index;
            return int.Parse(FileContent.Substring(prefix_index, 4));
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

        public bool Parse()
        {
            if (string.IsNullOrWhiteSpace(FileContent))
            {
                return false;
            }

            YearOfTransactions = GetYearOfTransaction();


            string mainPattern = @"^\d{2}\.\d{2}\. \d{2}\.\d{2}\. .*,\d{2} [HS]";
            string indentPattern = @"^ {14,}";
            string excludePattern = @"^\s*(Übertrag (auf|von) Blatt|neuer Kontostand vom)";


            var lines = FileContent.Split(["\r\n", "\n"], StringSplitOptions.None);

            var filtered = lines
                .Where(line =>
                    Regex.IsMatch(line, mainPattern) ||
                    (Regex.IsMatch(line, indentPattern) && !Regex.IsMatch(line, excludePattern)))
                .ToList();

            ParseTransactions(string.Join("\r\n", filtered));

            return true;
        }
    }
}
