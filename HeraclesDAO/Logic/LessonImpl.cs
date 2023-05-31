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
    public class LessonImpl : BaseImpl, ILesson
    {
        public int Delete(Lesson t)
        {
            throw new NotImplementedException();
        }

        public int Insert(Lesson t)
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {
            DataTable dt;
            _query = @"SELECT id, [name] AS 'Lesson' FROM Lesson WHERE [status] = 1";
            using(SqlCommand select = CreateCommand(_query))
            {
                dt = ReadCommand(select);
            }
            return dt;
        }

        public int Update(Lesson t)
        {
            throw new NotImplementedException();
        }
    }
}
