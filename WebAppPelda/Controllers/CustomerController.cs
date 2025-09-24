using WebAppPelda.Models;
using MySql.Data.MySqlClient;

namespace WebAppPelda.Controllers
{
    public class CustomerController
    {
        static MySqlConnection SQLConnection;
        public static void BuildConnection()
        {

            string connectionString = "SERVER = localhost;" +
                                      "DATABASE= uzlet;" +
                                      "UID = root;" +
                                      "PASSWORD =;" +
                                      "SSL MODE= none;";
            SQLConnection = new MySqlConnection();
            SQLConnection.ConnectionString = connectionString;
        }

        public List<Customer> GetCustomersFromDataBase()
        {
            BuildConnection();
            SQLConnection.Open();
            string sql = "SELECT * FROM customer";
            MySqlCommand command = new MySqlCommand(sql, SQLConnection);
            MySqlDataReader reader = command.ExecuteReader();
            List<Customer> databaselist = new List<Customer>();
            while (reader.Read())
            {
                databaselist.Add(new Customer
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Phone = reader.GetString("phone"),
                    Score = reader.GetInt32("score")
                });
            }
            SQLConnection.Close();
            return databaselist;

        }
        //public List<Customer> GetCustomersFromFile()
        //    {
        //    List<Customer> customers = new List<Customer>();
        //    string[] lines = File.ReadAllLines("CustomersDatas.txt").Skip(1).ToArray();
        //    foreach (string line in lines)
        //    {
        //        string[] parts = line.Split(';');
        //            customers.Add(new Customer
        //            {
        //                Id = int.Parse(parts[0]),
        //                Name = parts[1],
        //                Phone = parts[2],
        //                Score = int.Parse(parts[3])
        //            });
        //    }
        //    return customers;
            //Teszt drogokkal 
            //return new List<Customer>
            //    {
            //        new Customer { Id = 1, Name = "Alice", Phone = "555-1234", Score = 90 },
            //        new Customer { Id = 2, Name = "Bob", Phone = "555-5678", Score = 75 },
            //        new Customer { Id = 3, Name = "Charlie", Phone = "555-8765", Score = 85 },
            //        new Customer { Id = 4, Name = "Diana", Phone = "555-4321", Score = 95 },
            //        new Customer { Id = 5, Name = "Ethan", Phone = "555-6789", Score = 80 },
            //        new Customer { Id = 6, Name = "Fiona", Phone = "555-9876", Score = 88 },
            //        new Customer { Id = 7, Name = "George", Phone = "555-5432", Score = 70 }
            //    };
        }
    }

