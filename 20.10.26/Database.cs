using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace _20._10._26
{
    public static class Database
    {
        private static readonly string ConnectionString =
        "Data Source=" + DbPath;

        public static List<OrderItem> LoadOrders(string tableName)
        {
            if (tableName != "OnlineOrders" &&
                tableName != "StoreOrders")
            {
                throw new ArgumentException("Неизвестная таблица");
            }

            var orders = new List<OrderItem>();

            using (var connection =
                new SqliteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT Id, CustomerName, ProductName, " +
                        "Category, Price, Quantity FROM " + tableName;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new OrderItem();

                            item.Id =
                                Convert.ToInt32(reader["Id"]);

                            item.CustomerName =
                                Convert.ToString(
                                    reader["CustomerName"]) ?? "";

                            item.ProductName =
                                Convert.ToString(
                                    reader["ProductName"]) ?? "";

                            item.Category =
                                Convert.ToString(
                                    reader["Category"]) ?? "";

                            item.Price =
                                Convert.ToDecimal(reader["Price"]);

                            item.Quantity =
                                Convert.ToInt32(reader["Quantity"]);

                            orders.Add(item);
                        }
                    }
                }
            }

            return orders;
        }
    }
}


