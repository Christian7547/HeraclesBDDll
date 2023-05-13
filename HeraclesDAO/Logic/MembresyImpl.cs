using HeraclesDAO.Interfaces;
using HeraclesDAO.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace HeraclesDAO.Logic
{
    public class MembresyImpl : BaseImpl, IMembresy
    {
        public int Delete(Membresy t)
        {
            _query = @"UPDATE membresy SET status = 0, lastUpdate = CURRENT_TIMESTAMP WHERE id = @id";
            using(MySqlCommand delete = CreateCommand(_query))
            {
                delete.Connection.Open();
                delete.Parameters.AddWithValue("@id", t.Id);
                
                return WriteCommand(delete);    
            }
        }

        public Membresy GetMembresy(byte id)
        {
            Membresy membresy = null;
            _query = @"SELECT id, `type`, price, `status`, registerDate, IFNULL(lastUpdate, CURRENT_TIMESTAMP), userId FROM membresy WHERE id = @id;";
            using(MySqlCommand get = CreateCommand(_query))
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
            _query = @"INSERT INTO membresy (type, price, userId) VALUES (@type, @price, @userId)";
            using(MySqlCommand insert = CreateCommand(_query))
            {
                insert.Connection.Open();
                insert.Parameters.AddWithValue("@type", t.TypeMembresy);
                insert.Parameters.AddWithValue("@price", t.Price);
                insert.Parameters.AddWithValue("@userId", 1);

                return WriteCommand(insert);
            }

        }

        public DataTable Select()
        {
            _query = @"SELECT id AS ID, `type` AS `Type`, price AS Price FROM membresy WHERE status = 1 ORDER BY type";
            using(MySqlCommand select = CreateCommand(_query))
            {
                return ReadCommand(select); 
            }
            
        }

        public int Update(Membresy t)
        {
            _query = @"UPDATE membresy SET `type` = @type, price = @price, lastUpdate = CURRENT_TIMESTAMP, userId = @userId WHERE id = @id";
            using(MySqlCommand update = CreateCommand(_query))
            {
                update.Connection.Open();
                update.Parameters.AddWithValue("@type", t.TypeMembresy);
                update.Parameters.AddWithValue("@price", t.Price);
                update.Parameters.AddWithValue("@id", t.Id);
                update.Parameters.AddWithValue("@userId", 1);       

                return WriteCommand(update);    
            }
        }
    }
}