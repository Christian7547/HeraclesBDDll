using MySql.Data.MySqlClient;
using System.Data;

namespace HeraclesDAO.Logic
{
    internal class BaseImpl
    {
        string _connectionString = "Server=localhost;Database=heracles;Uid=root;Pwd=chris.gonza707;";
        public string _query = "";

        public MySqlCommand CreateCommand(string sql)
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand(sql, connection);   
            return command;
        }

        public DataTable ReadCommand(MySqlCommand command)
        {
            DataTable dt = new DataTable();    
            using(MySqlCommand mySqlConnection = new MySqlCommand(_connectionString))
            {
                command.Connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dt);
            } 
            return dt;  
        }

        public int WriteCommand(MySqlCommand command)
        {
            return command.ExecuteNonQuery();
        }
    }
}
