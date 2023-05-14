using HeraclesDAO.Interfaces;
using HeraclesDAO.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace HeraclesDAO.Logic
{
    public class CoachImpl : BaseImpl, ICoach
    {
        public int Delete(Coach t)
        {
            _query = @"UPDATE coach SET `status` = 0, lastUpdate = CURRENT_TIMESTAMP, userId = @userId WHERE id = @id";
            using(MySqlCommand delete = CreateCommand(_query))
            {
                delete.Connection.Open();
                delete.Parameters.AddWithValue("@id", t.Id); 
                delete.Parameters.AddWithValue("@userId", 1);
                
                return WriteCommand(delete);    
            }
        }

        public int Insert(Coach t)
        {
            _query = @"INSERT INTO coach (`names`, lastName, secondLastName, ci, phone, userId) 
                        VALUES(@names, @lastName, @secondLastName, @ci, @phone, @userId)";
            using(MySqlCommand insert = CreateCommand(_query))
            {
                insert.Connection.Open();
                insert.Parameters.AddWithValue("@names", t.Name);
                insert.Parameters.AddWithValue("@lastName", t.LastName);
                insert.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
                insert.Parameters.AddWithValue("@ci", t.CI);
                insert.Parameters.AddWithValue("@phone", t.Phone);
                insert.Parameters.AddWithValue("@userId", 1);

                return WriteCommand(insert);
            }
        }

        public DataTable Select()
        {
            _query = @"SELECT id AS ID, `names` AS 'Name', lastName AS 'LastName', secondLastName AS 'SecondLastName', 
                        ci AS CI, phone AS Phone
                        FROM coach WHERE `status` = 1";
            using(MySqlCommand select = CreateCommand(_query))
            {
                return ReadCommand(select);
            }
        }

        public int Update(Coach t)
        {
            _query = @"UPDATE coach SET `names` = @name, lastName = @lastName, secondLastName = @sLastName, ci = @ci, 
                        phone = @phone, lastUpdate = CURRENT_TIMESTAMP, userId = @userId WHERE id = @id";
            using(MySqlCommand update = CreateCommand(_query))
            {
                update.Connection.Open();
                update.Parameters.AddWithValue("@name", t.Name);
                update.Parameters.AddWithValue("@lastName", t.LastName);
                update.Parameters.AddWithValue("@sLastName", t.SecondLastName);
                update.Parameters.AddWithValue("@ci", t.CI);
                update.Parameters.AddWithValue("@phone", t.Phone);
                update.Parameters.AddWithValue("@userId", 1);
                update.Parameters.AddWithValue("@id", t.Id);

                return WriteCommand(update);
            }
        }
    }
}
