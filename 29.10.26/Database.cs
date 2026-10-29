using System;
using System.IO;

namespace _29._10._26
{
    public static class Database
    {
        private static readonly string DbPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                         "corp_fleet.db");

        private static readonly string ConnectionString =
            "Data Source=" + DbPath + ";Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        public static void Initialize()
        {
            if (!File.Exists(DbPath))
                SQLiteConnection.CreateFile(DbPath);

            using (SQLiteConnection connection = GetConnection())
            {
                connection.Open();

                string sql = @"
                    CREATE TABLE IF NOT EXISTS Vehicles (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Brand TEXT NOT NULL,
                        Model TEXT NOT NULL,
                        Year INTEGER NOT NULL,
                        Mileage REAL NOT NULL,
                        VehicleType TEXT NOT NULL,
                        ExtraCapacity REAL NOT NULL DEFAULT 0
                    );";

                using (SQLiteCommand command =
                       new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
