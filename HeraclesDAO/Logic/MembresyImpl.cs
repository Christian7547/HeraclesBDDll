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
            _query = @"UPDATE Membresy SET [status] = 0, lastUpdate = CURRENT_TIMESTAMP, userId = @userId WHERE id = @id";
            using(SqlCommand delete = CreateCommand(_query))
            {
                delete.Connection.Open();
                delete.Parameters.AddWithValue("@id", t.Id);
                delete.Parameters.AddWithValue("@userId", SessionClass.SessionId);
                
                return WriteCommand(delete);    
            }
        }

        public Membresy GetMembresy(byte id)
        {
            Membresy membresy = null;
            _query = @"SELECT id, [type], price, [status], registerDate, ISNULL(lastUpdate, CURRENT_TIMESTAMP), userId FROM Membresy WHERE id = @id;";
            using(SqlCommand get = CreateCommand(_query))
            {
                get.Connection.Open();
                get.Parameters.AddWithValue("@id", id);
                DataTable dataTable = ReadCommand(get);
                if(dataTable.Rows.Count > 0)
                {
                    membresy = new Membresy()
                    {
                        Id = byte.Parse(dataTable.Rows[0][0].ToString()),
                        TypeMembresy = dataTable.Rows[0][1].ToString(), 
                        Price = float.Parse(dataTable.Rows[0][2].ToString()),
                        Status = byte.Parse(dataTable.Rows[0][3].ToString()),
                        RegisterDate = DateTime.Parse(dataTable.Rows[0][4].ToString()), 
                        LastUpdate = DateTime.Parse(dataTable.Rows[0][5].ToString()),
                        UserId = int.Parse(dataTable.Rows[0][6].ToString())
                    };
                }
            }
            return membresy;
        }

        public int Insert(Membresy t)
        {
            _query = @"INSERT INTO Membresy ([type], price, userId) VALUES (@type, @price, @userId)";
            using(SqlCommand insert = CreateCommand(_query))
            {
                insert.Connection.Open();
                insert.Parameters.AddWithValue("@type", t.TypeMembresy);
                insert.Parameters.AddWithValue("@price", t.Price);
                insert.Parameters.AddWithValue("@userId", SessionClass.SessionId);

                return WriteCommand(insert);
            }

        }

        public DataTable Select()
        {
            _query = @"SELECT id AS ID, [type] AS 'Type', price AS Price FROM Membresy WHERE [status] = 1 ORDER BY [type]";
            using(SqlCommand select = CreateCommand(_query))
            {
                return ReadCommand(select); 
            }
            
        }

        public int Update(Membresy t)
        {
            _query = @"UPDATE Membresy SET [type] = @type, price = @price, lastUpdate = CURRENT_TIMESTAMP, userId = @userId WHERE id = @id";
            using(SqlCommand update = CreateCommand(_query))
            {
                update.Connection.Open();
                update.Parameters.AddWithValue("@type", t.TypeMembresy);
                update.Parameters.AddWithValue("@price", t.Price);
                update.Parameters.AddWithValue("@id", t.Id);
                update.Parameters.AddWithValue("@userId", SessionClass.SessionId);       

                return WriteCommand(update);    
            }
        }
    }
}