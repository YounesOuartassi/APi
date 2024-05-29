using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


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
                string query = "SELECT * FROM player";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Utilisez GetInt32() pour récupérer la valeur entière
                    int id = reader.GetInt32(0);
                    int homeTeamApiId = reader.GetInt32(1);

                    // Affichez les valeurs entières
                    Console.WriteLine($"id: {id}, home_team_api_id: {homeTeamApiId}");
                }



            }
        }
    }
}
