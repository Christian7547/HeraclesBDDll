using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace HeraclesDAO.Logic
{
    public class BaseImpl
    {
        string _connectionString = "Server=ASUS_CHRIS07\\SQLEXPRESS;Database=Heracles;User=sa;Password=Univalle;";
        public string _query = "";

        #region BasicCruds
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
        #endregion

        #region Transactions
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public bool ExecuteAnyCommands(SqlTransaction transaction, List<SqlCommand> commands)
        {
            try
            {
                foreach (SqlCommand command in commands)
                {
                    command.Connection = transaction.Connection;
                    command.Transaction = transaction;
                    WriteCommand(command);
                }
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public DataTable FindLastId(string tableName)
        {
            DataTable dt;
            _query = $"SELECT IDENT_CURRENT({tableName})";
            using(SqlCommand command = CreateCommand(_query))
            {
                dt = ReadCommand(command);
                return dt;
            }
        }

        #endregion
    }
}
