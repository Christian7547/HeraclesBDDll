using HeraclesDAO.Interfaces;
using HeraclesDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeraclesDAO.Logic
{
    public class RoomImpl : BaseImpl, IRoom
    {
        public int Delete(Room t)
        {
            throw new NotImplementedException();
        }

        public int Insert(Room t)
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {
            DataTable dt;
            _query = @"SELECT id, [name] FROM Room WHERE [status] = 1";
            using (SqlCommand select = CreateCommand(_query))
            {
                dt = ReadCommand(select);
            }
            return dt;
        }

        public int Update(Room t)
        {
            throw new NotImplementedException();
        }
    }
}
