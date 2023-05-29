using HeraclesDAO.Interfaces;
using HeraclesDAO.Models;
using System.Data.SqlClient;
using System;
using System.Data;
using HeraclesDAO.Models.Session;

namespace HeraclesDAO.Logic
{
    public class MembresyImpl : BaseImpl, IMembresy
    {
        public int Delete(Membresy t)
        {
            int success;
            _query = @"UPDATE Membresy SET [status] = 0, lastUpdate = CURRENT_TIMESTAMP, userId = @userId WHERE id = @id";
            using(SqlCommand delete = CreateCommand(_query))
            {
                delete.Connection.Open();
                delete.Parameters.AddWithValue("@id", t.Id);
                delete.Parameters.AddWithValue("@userId", SessionClass.SessionId);
                
                success = WriteCommand(delete);    
            }
            return success;
        }

        public int Insert(Membresy t)
        {
            int success;
            _query = @"INSERT INTO Membresy ([type], price, userId) VALUES (@type, @price, @userId)";
            using(SqlCommand insert = CreateCommand(_query))
            {
                insert.Connection.Open();
                insert.Parameters.AddWithValue("@type", t.TypeMembresy);
                insert.Parameters.AddWithValue("@price", t.Price);
                insert.Parameters.AddWithValue("@userId", SessionClass.SessionId);

                success = WriteCommand(insert);
            }
            return success;
        }

        public DataTable Select()
        {
            DataTable data;
            _query = @"SELECT id AS ID, [type] AS 'Type', price AS Price FROM Membresy WHERE [status] = 1 ORDER BY [type]";
            using(SqlCommand select = CreateCommand(_query))
            {
                data = ReadCommand(select); 
            }
            return data;
        }

        public int Update(Membresy t)
        {
            int success;
            _query = @"UPDATE Membresy SET [type] = @type, price = @price, lastUpdate = CURRENT_TIMESTAMP, userId = @userId WHERE id = @id";
            using(SqlCommand update = CreateCommand(_query))
            {
                update.Connection.Open();
                update.Parameters.AddWithValue("@type", t.TypeMembresy);
                update.Parameters.AddWithValue("@price", t.Price);
                update.Parameters.AddWithValue("@id", t.Id);
                update.Parameters.AddWithValue("@userId", SessionClass.SessionId);       

                success = WriteCommand(update);    
            }
            return success;
        }

        public DataTable GetMembresies()
        {
            DataTable dt;
            _query = @"SELECT id, [type] FROM Membresy";
            using (SqlCommand get = CreateCommand(_query))
            {
                dt = ReadCommand(get);
            }
            return dt;
        }

    }
}