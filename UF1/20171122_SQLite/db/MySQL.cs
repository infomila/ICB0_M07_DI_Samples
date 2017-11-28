using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20171122_SQLite.db
{
    class MySQL
    {

        public void test()
        {
            try
            {
                string conString = "server = 127.0.0.1; uid = root; pwd = ; database = cds";
                using (MySqlConnection connection = new MySqlConnection(conString))
                {
                    DbConnectionStringBuilder 
                    connection.Open();
                    MySqlCommand getCommand = connection.CreateCommand();
                    getCommand.CommandText = "SELECT whatToDO FROM todo";
                    using (MySqlDataReader reader = getCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reader.GetString("whatToDO");
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                // Handle it 
            }
        }
    }
}
