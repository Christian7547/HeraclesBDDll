using HeraclesDAO.Interfaces;
using HeraclesDAO.Models;
using System.Data.SqlClient;
using System;
using System.Data;

namespace HeraclesDAO.Logic
{
    public class MemberImpl : BaseImpl, IMember
    {
        public int Delete(Member t)
        {
            _query = @"UPDATE Member SET [status] = 0 WHERE id = @id";
            using(SqlCommand delete = CreateCommand(_query))
            {
                delete.Connection.Open();
                delete.Parameters.AddWithValue("@id", t.Id); 
                
                return WriteCommand(delete);    
            }
        }

        public int Insert(Member t)
        {
            _query = @"INSERT INTO Member (name, lastName, secondLastName) VALUES (@name, @lastName, @secondLastName)";
            using(SqlCommand insert = CreateCommand(_query))
            {
                insert.Parameters.AddWithValue("@name", t.Name);
                insert.Parameters.AddWithValue("@lastName", t.LastName);
                insert.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
                return WriteCommand(insert);
            }
        }

        public DataTable Select()
        {
            _query = @"SELECT id AS ID, names AS 'Names', lastName AS 'LastName', secondLastName AS 'SecondLastName' FROM Member WHERE [status] = 1"; 
            using(SqlCommand select = CreateCommand(_query))
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
