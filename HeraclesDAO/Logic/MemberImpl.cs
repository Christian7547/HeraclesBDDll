using HeraclesDAO.Interfaces;
using HeraclesDAO.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace HeraclesDAO.Logic
{
    internal class MemberImpl : BaseImpl, IMember
    {
        public int Delete(Member t)
        {
            _query = @"UPDATE member SET status = 0 WHERE id = @id";
            using(MySqlCommand delete = CreateCommand(_query))
            {
                delete.Connection.Open();
                delete.Parameters.AddWithValue("@id", t.Id); 
                
                return WriteCommand(delete);    
            }
        }

        public int Insert(Member t)
        {
            _query = @"INSERT INTO member (name, lastName, secondLastName) VALUES (@name, @lastName, @secondLastName)";
            using(MySqlCommand insert = CreateCommand(_query))
            {
                insert.Parameters.AddWithValue("@name", t.Name);
                insert.Parameters.AddWithValue("@lastName", t.LastName);
                insert.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
                return WriteCommand(insert);
            }
        }

        public DataTable Select()
        {
            _query = @"SELECT name, lastName, secondLastName FROM member WHERE status = 1"; 
            using(MySqlCommand select = CreateCommand(_query))
            {
                return ReadCommand(select);
            }
        }

        public int Update(Member t)
        {
            throw new NotImplementedException();
        }
    }
}
