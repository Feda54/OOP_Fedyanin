using System.Collections.Generic;

namespace _28._10._26
{
    public sealed class DatabaseInitializer
    {
        private readonly string _connectionString;

        public DatabaseInitializer(string databasePath = "shop.db")
        {
            _connectionString = "Data Source=" + databasePath;
        }

        public void Initialize()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "CREATE TABLE IF NOT EXISTS Categories (" +
                        "Id INTEGER PRIMARY KEY, " +
                        "Name TEXT NOT NULL, " +
                        "DiscountRate REAL NOT NULL); " +

                        "CREATE TABLE IF NOT EXISTS Products (" +
                        "Id INTEGER PRIMARY KEY, " +
                        "Name TEXT NOT NULL, " +
                        "CategoryId INTEGER NOT NULL, " +
                        "Price REAL NOT NULL, " +
                        "Stock INTEGER NOT NULL, " +
                        "FOREIGN KEY (CategoryId) REFERENCES Categories(Id)); " +

                        "CREATE TABLE IF NOT EXISTS Sales (" +
                        "Id INTEGER PRIMARY KEY, " +
                        "ProductId INTEGER NOT NULL, " +
                        "CustomerName TEXT NOT NULL, " +
                        "Quantity INTEGER NOT NULL, " +
                        "SaleDate TEXT NOT NULL, " +
                        "Channel TEXT NOT NULL, " +
                        "FOREIGN KEY (ProductId) REFERENCES Products(Id));";

                    command.ExecuteNonQuery();
                }

                SeedData(connection);
            }
        }

        private void SeedData(SqliteConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "INSERT OR IGNORE INTO Categories " +
                    "(Id, Name, DiscountRate) VALUES " +
                    "(1, 'Ноутбуки', 0.05), " +
                    "(2, 'Смартфоны', 0.10), " +
                    "(3, 'Аксессуары', 0.03), " +
                    "(4, 'Мониторы', 0.07); " +

                    "INSERT OR IGNORE INTO Products " +
                    "(Id, Name, CategoryId, Price, Stock) VALUES " +
                    "(1, 'Lenovo IdeaPad', 1, 350000, 12), " +
                    "(2, 'ASUS VivoBook', 1, 420000, 8), " +
                    "(3, 'HP Pavilion', 1, 390000, 10), " +
                    "(4, 'iPhone 15', 2, 450000, 7), " +
                    "(5, 'Samsung Galaxy S24', 2, 400000, 9), " +
                    "(6, 'Xiaomi Redmi Note', 2, 150000, 20), " +
                    "(7, 'Мышь Logitech', 3, 12000, 30), " +
                    "(8, 'Клавиатура A4Tech', 3, 15000, 25), " +
                    "(9, 'Наушники JBL', 3, 28000, 18), " +
                    "(10, 'Монитор Samsung', 4, 180000, 6); " +

                    "INSERT OR IGNORE INTO Sales " +
                    "(Id, ProductId, CustomerName, Quantity, SaleDate, Channel) VALUES " +
                    "(1, 1, 'Иван', 1, '2026-01-10', 'Магазин'), " +
                    "(2, 4, 'Анна', 1, '2026-01-11', 'Интернет'), " +
                    "(3, 7, 'Пётр', 2, '2026-01-12', 'Магазин'), " +
                    "(4, 2, 'Мария', 1, '2026-01-13', 'Интернет'), " +
                    "(5, 5, 'Олег', 1, '2026-01-14', 'Магазин'), " +
                    "(6, 8, 'Елена', 2, '2026-01-15', 'Интернет'), " +
                    "(7, 3, 'Дмитрий', 1, '2026-01-16', 'Магазин'), " +
                    "(8, 6, 'Сергей', 2, '2026-01-17', 'Интернет'), " +
                    "(9, 9, 'Ольга', 1, '2026-01-18', 'Магазин'), " +
                    "(10, 10, 'Андрей', 1, '2026-01-19', 'Интернет'), " +
                    "(11, 1, 'Наталья', 1, '2026-01-20', 'Интернет'), " +
                    "(12, 4, 'Игорь', 2, '2026-01-21', 'Магазин'), " +
                    "(13, 7, 'Алина', 3, '2026-01-22', 'Интернет'), " +
                    "(14, 2, 'Максим', 1, '2026-01-23', 'Магазин'), " +
                    "(15, 5, 'Юлия', 1, '2026-01-24', 'Интернет'), " +
                    "(16, 8, 'Роман', 1, '2026-01-25', 'Магазин'), " +
                    "(17, 3, 'Кирилл', 2, '2026-01-26', 'Интернет'), " +
                    "(18, 6, 'Татьяна', 1, '2026-01-27', 'Магазин'), " +
                    "(19, 9, 'Виктор', 2, '2026-01-28', 'Интернет'), " +
                    "(20, 10, 'Дарья', 1, '2026-01-29', 'Магазин');";

                command.ExecuteNonQuery();
            }
        }

        public List<Category> LoadCategories()
        {
            var result = new List<Category>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT Id, Name, DiscountRate FROM Categories";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Category(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetDouble(2)));
                        }
                    }
                }
            }

            return result;
        }

        public List<Product> LoadProducts()
        {
            var result = new List<Product>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT Id, Name, CategoryId, Price, Stock FROM Products";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Product(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetInt32(2),
                                reader.GetDouble(3),
                                reader.GetInt32(4)));
                        }
                    }
                }
            }

            return result;
        }

        public List<Sale> LoadSales()
        {
            var result = new List<Sale>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT Id, ProductId, CustomerName, Quantity, " +
                        "SaleDate, Channel FROM Sales";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Sale(
                                reader.GetInt32(0),
                                reader.GetInt32(1),
                                reader.GetString(2),
                                reader.GetInt32(3),
                                reader.GetString(4),
                                reader.GetString(5)));
                        }
                    }
                }
            }

            return result;
        }
    }
}
