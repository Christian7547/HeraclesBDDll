using HeraclesDAO.Interfaces;
using HeraclesDAO.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace HeraclesDAO.Logic
{
    internal class MembresyImpl : BaseImpl, IMembresy
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

        public int Insert(Membresy t)
        {
            _query = @"INSERT INTO membresy (type, price) VALUES (@type, @price)";
            using(MySqlCommand insert = CreateCommand(_query))
            {
                insert.Connection.Open();
                insert.Parameters.AddWithValue("@type", t.TypeMembresy);
                insert.Parameters.AddWithValue("@price", t.Price);

                return WriteCommand(insert);
            }

        }

        public DataTable Select()
        {
            _query = @"SELECT id, type, price FROM membresy WHERE status = 1 ORDER BY type";
            using(MySqlCommand select = CreateCommand(_query))
            {
                return ReadCommand(select); 
            }
            
        }

        public int Update(Membresy t)
        {
            _query = @"UPDATE membresy SET type = @type, price = @price, lastUpdate = CURRENT_TIMESTAMP WHERE id = @id";
            using(MySqlCommand update = CreateCommand(_query))
            {
                update.Connection.Open();
                update.Parameters.AddWithValue("@type", t.TypeMembresy);
                update.Parameters.AddWithValue("@price", t.Price);
                update.Parameters.AddWithValue("@id", t.Id);
                //update.Parameters.AddWithValue("@id", t.Id);          USERID

                return WriteCommand(update);    
            }
        }
    }
}