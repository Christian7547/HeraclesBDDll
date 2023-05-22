using System.Data.SqlClient;
using System.Data;

namespace HeraclesDAO.Logic
{
    public class BaseImpl
    {
        string _connectionString = "Server=T110-06\\SQLEXPRESS;Database=Heracles;User=sa;Password=Univalle;";
        public string _query = "";

        public SqlCommand CreateCommand(string sql)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(sql, connection);   
            return command;
        }

        public DataTable ReadCommand(SqlCommand command)
        {
            DataTable dt = new DataTable();    
            using(SqlCommand sqlConnection = new SqlCommand(_connectionString))
            {
                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            } 
            return dt;  
        }

        public int WriteCommand(SqlCommand command)
        {
            return command.ExecuteNonQuery();
        }
    }
}
