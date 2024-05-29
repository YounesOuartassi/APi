using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace MySqlApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Exemple de requête de sélection
                string query = "SELECT * FROM MaTable";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Manipulez les données ici, par exemple :
                    Console.WriteLine($"ID: {reader.GetInt32(0)}, Nom: {reader.GetString(1)}");
                }

                reader.Close();
            }
        }
    }
}
