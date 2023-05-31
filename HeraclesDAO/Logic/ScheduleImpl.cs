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
    public class ScheduleImpl : BaseImpl, ISchedule
    {
        public int Delete(Schedule t)
        {
            throw new NotImplementedException();
        }

        public int Insert(Schedule t)
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {
            DataTable dt;
            _query = @"SELECT id, [day], startHour, finishHour FROM Schedule WHERE [status] = 1";
            using(SqlCommand select = CreateCommand(_query))
            {
                dt = ReadCommand(select);
            }
            return dt;
        }

        public int Update(Schedule t)
        {
            throw new NotImplementedException();
        }

        public DataTable GetSchedules()
        {
            DataTable dt;
            _query = @"SELECT id, CONCAT(day,'  ',startHour,' - ',finishHour) AS Schedule FROM Schedule WHERE [status] = 1";
            using (SqlCommand select = CreateCommand(_query))
            {
                dt = ReadCommand(select);
            }
            return dt;
        }
    }
}
