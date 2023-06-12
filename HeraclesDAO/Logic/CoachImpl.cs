using HeraclesDAO.Interfaces;
using HeraclesDAO.Models;
using System.Data.SqlClient;
using System;
using System.Data;
using HeraclesDAO.Models.Session;

namespace HeraclesDAO.Logic
{
    public class CoachImpl : BaseImpl, ICoach
    {
        public int Delete(Coach t)
        {
            int success;
            _query = @"UPDATE Coach SET [status] = 0, lastUpdate = CURRENT_TIMESTAMP, userId = @userId WHERE id = @id";
            using(SqlCommand delete = CreateCommand(_query))
            {
                delete.Connection.Open();
                delete.Parameters.AddWithValue("@id", t.Id); 
                delete.Parameters.AddWithValue("@userId", SessionClass.SessionId);
                
                success = WriteCommand(delete);    
            }
            return success;
        }

        public int Insert(Coach t)
        {
            int success;
            _query = @"INSERT INTO Coach (names, lastName, secondLastName, ci, phone, userId) 
                        VALUES(@names, @lastName, @secondLastName, @ci, @phone, @userId)";
            using(SqlCommand insert = CreateCommand(_query))
            {
                insert.Connection.Open();
                insert.Parameters.AddWithValue("@names", t.Name);
                insert.Parameters.AddWithValue("@lastName", t.LastName);
                insert.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
                insert.Parameters.AddWithValue("@ci", t.CI);
                insert.Parameters.AddWithValue("@phone", t.Phone);
                insert.Parameters.AddWithValue("@userId", SessionClass.SessionId);

                success = WriteCommand(insert);
            }
            return success;
        }

        public DataTable Select()
        {
            DataTable data;
            _query = @"SELECT id AS ID, names AS 'Name', lastName AS LastName, secondLastName AS SecondLastName, 
                        ci AS CI, phone AS Phone
                        FROM Coach 
                        WHERE [status] = 1
                        ORDER BY 2";
            using(SqlCommand select = CreateCommand(_query))
            {
                data = ReadCommand(select);
            }
            return data;
        }

        public int Update(Coach t)
        {
            int success;
            _query = @"UPDATE Coach SET names = @name, lastName = @lastName, secondLastName = @sLastName, ci = @ci, 
                        phone = @phone, lastUpdate = CURRENT_TIMESTAMP, userId = @userId WHERE id = @id";
            using(SqlCommand update = CreateCommand(_query))
            {
                update.Connection.Open();
                update.Parameters.AddWithValue("@name", t.Name);
                update.Parameters.AddWithValue("@lastName", t.LastName);
                update.Parameters.AddWithValue("@sLastName", t.SecondLastName);
                update.Parameters.AddWithValue("@ci", t.CI);
                update.Parameters.AddWithValue("@phone", t.Phone);
                update.Parameters.AddWithValue("@userId", SessionClass.SessionId);
                update.Parameters.AddWithValue("@id", t.Id);

                success = WriteCommand(update);
            }
            return success;
        }

        public DataTable GetCoachs()
        {
            DataTable dt;
            _query = @"SELECT id, CONCAT(names,' ',lastName,' ',secondLastName) AS 'Name' FROM Coach WHERE [status] = 1";
            using (SqlCommand getAll = CreateCommand(_query))
            {
                dt = ReadCommand(getAll);
            }
            return dt;
        }
    }
}
