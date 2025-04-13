namespace MoneyBunny.DataStore
{
    using MoneyBunny.Rules;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data.SQLite;
    using System.Linq;

    public enum DbFilter
    {
        All,
        WhereNoCategory,
        WhereCategoryId,
        WhereTransactionId,
    }

    public enum DbOrder
    {
        None,
        ByDate,
        ByDateDescending,
        ByValue,
        ByValueDescending,
    }

    public class DataBase
    {
        private static readonly string DataStoreFileName = "DataStore.db";
        private static string DataStoreFilePath
            => AppPaths.GetLocalAppPath(DataStoreFileName);
        private static string ConnectionString
            => $"URI=file:{DataStoreFilePath};foreign keys=true";

        private static bool isInitialized;

        private static SQLiteConnection OpenConnection()
        {
            if (!isInitialized)
            {
                isInitialized = true;
                CreateCategoriesTable();
                CreateTransactionsTable();
                CreateRulesTable();
            }

            var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        private static void AddFilter(
            DbFilter filter,
            SQLiteCommand command,
            IEnumerable<long> ids)
        {
            string id_string() => string.Join(", ", ids.Select(id => $"{id}"));
            switch (filter)
            {
                case DbFilter.All:
                    break;
                case DbFilter.WhereNoCategory:
                    command.CommandText += " WHERE CategoryId IS NULL";
                    break;
                case DbFilter.WhereCategoryId:
                    command.CommandText += " WHERE CategoryId in (@CategoryIds)";
                    _ = command.Parameters.AddWithValue("@CategoryIds", id_string());
                    break;
                case DbFilter.WhereTransactionId:
                    command.CommandText = " WHERE TransactionId in (@TransactionIds)";
                    _ = command.Parameters.AddWithValue("@TransactionIds", id_string());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(filter),
                        "Selected filter is invalid for this query");
            }
        }

        private static void AddOrder(
            DbOrder order,
            SQLiteCommand command)
        {
            switch (order)
            {
                case DbOrder.None:
                    break;
                case DbOrder.ByDate:
                    command.CommandText += " ORDER BY Date";
                    break;
                case DbOrder.ByDateDescending:
                    command.CommandText += " ORDER BY Date DESC";
                    break;
                case DbOrder.ByValue:
                    command.CommandText += " ORDER BY Value";
                    break;
                case DbOrder.ByValueDescending:
                    command.CommandText += " ORDER BY Value DESC";
                    break;
                default:
                    throw new InvalidEnumArgumentException(
                        nameof(order),
                        (int)order,
                        typeof(DbOrder));
            }
        }


        private static void CreateRulesTable()
        {
            using var connection = OpenConnection();
            using var command = new SQLiteCommand(connection);
            command.CommandText = "CREATE TABLE IF NOT EXISTS \"Rules\" ("
                + "\"RuleId\"    INTEGER NOT NULL UNIQUE,"
                + "\"Type\"  TEXT,"
                + "\"Comparator\"    TEXT,"
                + "\"Value\" TEXT,"
                + "\"CategoryId\"    INTEGER NOT NULL,"
                + "PRIMARY KEY(\"RuleId\" AUTOINCREMENT),"
                + " FOREIGN KEY(\"CategoryId\") REFERENCES \"Categories\"(\"CategoryId\") ON DELETE CASCADE"
                + ")";
            _ = command.ExecuteNonQuery();
        }

        private static void DropRulesTable()
        {
            using var connection = OpenConnection();
            using var command = new SQLiteCommand(connection);
            command.CommandText = "DROP TABLE IF EXISTS \"Rules\"";
            _ = command.ExecuteNonQuery();
        }

        private static void InsertRules(
            IEnumerable<Tuple<IRule, long>> rules_and_category_ids)
        {
            using var connection = OpenConnection();
            using var transaction = connection.BeginTransaction();
            using var command = new SQLiteCommand(connection);
            InsertRules(command, rules_and_category_ids);
            transaction.Commit();
        }

        private static void InsertRules(SQLiteCommand command,
            IEnumerable<Tuple<IRule, long>> rules_and_category_ids)
        {
            command.CommandText = "INSERT INTO Rules"
                    + " (Type, Comparator, Value, CategoryId)"
                    + " Values (@Type, @Comparator, @Value, @CategoryId)";
            foreach (var (rule, category_id) in rules_and_category_ids)
            {
                _ = command.Parameters.AddWithValue("@Type", rule.Type.ToDisplayString());
                _ = command.Parameters.AddWithValue("@Comparator", rule.ComparatorText);
                _ = command.Parameters.AddWithValue("@Value", rule.ValueText);
                _ = command.Parameters.AddWithValue("@CategoryId", category_id);
                _ = command.ExecuteNonQuery();
                command.Reset();
            }
        }

        public static void DeleteRules(
            IEnumerable<IRule> rules)
        {
            using var connection = OpenConnection();
            using var command = new SQLiteCommand(connection);
            command.CommandText = "DELETE FROM Rules"
                + " WHERE RuleId IN (@RuleIds)";
            var rule_ids = rules
                .Select(c => $"{c.RuleId}");
            _ = command.Parameters.AddWithValue("@RuleIds",
                string.Join(", ", rule_ids));
            _ = command.ExecuteNonQuery();
        }

        public static void DeleteRules(
            IEnumerable<Category> categories)
        {
            using var connection = OpenConnection();
            using var command = new SQLiteCommand(connection);
            command.CommandText = "DELETE FROM Rules"
                + " WHERE CategoryId IN (@CategoryIds)";
            var category_ids = categories
                .Select(c => $"{c.CategoryId}");
            _ = command.Parameters.AddWithValue("@CategoryIds",
                string.Join(", ", category_ids));
            _ = command.ExecuteNonQuery();
        }

        public static IEnumerable<IRule> GetRules(
            DbFilter filter = DbFilter.All,
            IEnumerable<long> ids = null,
            DbOrder order = DbOrder.None)
        {
            using var connection = OpenConnection();
            using var command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Rules";
            AddFilter(filter, command, ids);
            AddOrder(order, command);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return Rule.CreateRule(
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3));
            }
        }

        public static void ClearRules()
        {
#if USE_DELETE
            string statement = "DELETE FROM Rules";
            using (var connection = OpenConnection())
            using (var command = new SQLiteCommand(statement, connection))
            {
                command.ExecuteNonQuery();
            }
#else
            DropRulesTable();
            CreateRulesTable();
#endif
        }


        private static void CreateCategoriesTable()
        {
            using var connection = OpenConnection();
            using var command = new SQLiteCommand(connection);
            command.CommandText = "CREATE TABLE IF NOT EXISTS \"Categories\" ("
                + "\"CategoryId\" INTEGER NOT NULL,"
                + "\"Name\"  TEXT,"
                + "PRIMARY KEY(\"CategoryId\" AUTOINCREMENT)"
                + ")";
            _ = command.ExecuteNonQuery();
        }

        private static void DropCategoriesTable()
        {
            using var connection = OpenConnection();
            using var command = new SQLiteCommand(connection);
            command.CommandText = "DROP TABLE IF EXISTS \"Categories\"";
            _ = command.ExecuteNonQuery();
        }

        public static void InsertCategories(
            IEnumerable<Category> categories)
        {
            using var connection = OpenConnection();
            using var transaction = connection.BeginTransaction();
            using var command = new SQLiteCommand(connection);
            command.Transaction = transaction;
            foreach (var c in categories)
            {
                command.CommandText = "INSERT INTO Categories"
                        + " (Name)"
                        + " VALUES (@Name)";
                _ = command.Parameters.AddWithValue("@Name", c.Name);
                _ = command.ExecuteNonQuery();
                c.CategoryId = connection.LastInsertRowId;
                command.Reset();

                if (c.Rules == null)
                {
                    continue;
                }

                InsertRules(command, c.Rules.Select(r => Tuple.Create(r, c.CategoryId.Value)));
            }
            transaction.Commit();
        }

        public static void UpdateCategoryName(
            IEnumerable<Category> categories)
        {
            using var connection = OpenConnection();
            using var transaction = connection.BeginTransaction();
            using var command = new SQLiteCommand(connection);
            command.Transaction = transaction;
            command.CommandText = "UPDATE Categories SET"
                + " Name=@Name"
                + " WHERE CategoryId=@CategoryId";
            foreach (var c in categories)
            {
                _ = command.Parameters.AddWithValue("@Name", c.Name);
                _ = command.Parameters.AddWithValue("@CategoryId", c.CategoryId);
                _ = command.ExecuteNonQuery();
            }
            transaction.Commit();
        }

        public static void UpdateCategoryRules(
            IEnumerable<Category> categories)
        {
            DeleteRules(categories);
            InsertRules(categories.SelectMany(c => c.Rules.Select(r => Tuple.Create(r, c.CategoryId.Value))));
        }

        public static void DeleteCategories(
            IEnumerable<Category> categories)
        {
            using var connection = OpenConnection();
            using var command = new SQLiteCommand(connection);
            command.CommandText = "DELETE FROM Categories"
                + " WHERE CategoryId IN (@CategoryIds)";
            var category_ids = categories
                .Select(c => $"{c.CategoryId}");
            _ = command.Parameters.AddWithValue("@CategoryIds",
                string.Join(", ", category_ids));
            _ = command.ExecuteNonQuery();
        }

        public static IEnumerable<Category> GetCategories(
            DbFilter filter = DbFilter.All,
            IEnumerable<long> ids = null,
            DbOrder order = DbOrder.None)
        {
            using var connection = OpenConnection();
            using var command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Categories";
            AddFilter(filter, command, ids);
            AddOrder(order, command);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Category
                {
                    CategoryId = reader.GetInt64(0),
                    Name = reader.GetString(1),
                };
            }
        }

        public static void ClearCategories()
        {
#if USE_DELETE
            string statement = "DELETE FROM Categories";
            using (var connection = OpenConnection())
            using (var command = new SQLiteCommand(statement, connection))
            {
                command.ExecuteNonQuery();
            }
#else
            DropCategoriesTable();
            CreateCategoriesTable();
#endif
        }


        private static void CreateTransactionsTable()
        {
            using var connection = OpenConnection();
            using var command = new SQLiteCommand(connection);
            command.CommandText = "CREATE TABLE IF NOT EXISTS \"Transactions\" ("
                + "\"TransactionId\" INTEGER NOT NULL,"
                + "\"Date\"  TEXT,"
                + "\"Type\"  TEXT,"
                + "\"Reference\" TEXT,"
                + "\"Value\" INTEGER,"
                + "\"CategoryId\"    INTEGER,"
                + "FOREIGN KEY(\"CategoryId\") REFERENCES \"Categories\"(\"CategoryId\") ON DELETE SET NULL,"
                + "PRIMARY KEY(\"TransactionId\" AUTOINCREMENT)"
                + ")";
            _ = command.ExecuteNonQuery();
        }

        private static void DropTransactionsTable()
        {
            using var connection = OpenConnection();
            using var command = new SQLiteCommand(connection);
            command.CommandText = "DROP TABLE IF EXISTS \"Transactions\"";
            _ = command.ExecuteNonQuery();
        }

        public static void InsertTransactions(
            IEnumerable<Transaction> transactions)
        {
            using var connection = OpenConnection();
            using var transaction = connection.BeginTransaction();
            using var command = new SQLiteCommand(connection);
            command.Transaction = transaction;
            command.CommandText = "INSERT INTO Transactions"
                    + " (Date, Type, Reference, Value, CategoryId)"
                    + " Values (@Date, @Type, @Reference, @Value, @CategoryId)";
            foreach (var t in transactions)
            {
                _ = command.Parameters.AddWithValue("@Date", t.Date);
                _ = command.Parameters.AddWithValue("@Type", t.Type);
                _ = command.Parameters.AddWithValue("@Reference", t.Reference);
                _ = command.Parameters.AddWithValue("@Value", t.Value);
                _ = command.Parameters.AddWithValue("@CategoryId", t.CategoryId);
                _ = command.ExecuteNonQuery();
                t.TransactionId = connection.LastInsertRowId;
                command.Reset();
            }
            transaction.Commit();
        }

        public static void UpdateTransactionCategories(
            IEnumerable<Transaction> transactions)
        {
            using var connection = OpenConnection();
            using var transaction = connection.BeginTransaction();
            using var command = new SQLiteCommand(connection);
            command.Transaction = transaction;
            command.CommandText = "UPDATE Transactions SET"
                + " CategoryId = @CategoryId"
                + " WHERE TransactionId = @TransactionId";
            foreach (var t in transactions)
            {
                _ = command.Parameters.AddWithValue("@TransactionId", t.TransactionId);
                _ = command.Parameters.AddWithValue("@CategoryId", t.CategoryId);
                _ = command.ExecuteNonQuery();
            }
            transaction.Commit();
        }

        public static IEnumerable<Transaction> GetTransactions(
            DbFilter filter = DbFilter.All,
            IEnumerable<long> ids = null,
            DbOrder order = DbOrder.None)
        {
            using var connection = OpenConnection();
            using var command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Transactions";
            AddFilter(filter, command, ids);
            AddOrder(order, command);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Transaction
                {
                    TransactionId = reader.GetInt64(0),
                    Date = reader.GetDateTime(1),
                    Type = reader.GetString(2),
                    Reference = reader.GetString(3),
                    Value = reader.GetInt32(4),
                    CategoryId = reader.GetValue(5) as long?,
                };
            }
        }

        public static void ClearTransactions()
        {
#if USE_DELETE
            string statement = "DELETE FROM Transactions";
            using (var connection = OpenConnection())
            using (var command = new SQLiteCommand(statement, connection))
            {
                command.ExecuteNonQuery();
            }
#else
            DropTransactionsTable();
            CreateTransactionsTable();
#endif
        }
    }
}
