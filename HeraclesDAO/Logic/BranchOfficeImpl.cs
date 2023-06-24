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
    public class BranchOfficeImpl : BaseImpl, IBranchOffice
    {
        public int Delete(BranchOffice t)
        {
            int success;
            _query = @"UPDATE BranchOffice SET [status] = 0, lastUpdate = CURRENT_TIMESTAMP, userId = @userId WHERE id = @id";
            using (SqlCommand update = CreateCommand(_query))
            {
                update.Connection.Open();
                update.Parameters["@userId"].Value = t.UserId;
                update.Parameters["@id"].Value = t.Id;

                success = WriteCommand(update);
            }
            return success;
        }

        public int Insert(BranchOffice t)
        {
            int success;
            _query = @"INSERT INTO BranchOffice([name], latitude, longitude, cityId) 
                        VALUES(@name, @latitude, @longitude, @cityId)";
            using(SqlCommand insert = CreateCommand(_query))
            {
                insert.Connection.Open();
                insert.Parameters["@name"].Value = t.Name;
                insert.Parameters["@latitude"].Value = t.Latitude;
                insert.Parameters["@longitude"].Value = t.Longitude;
                insert.Parameters["@cityId"].Value = t.CityId;
                insert.Parameters["@userId"].Value = t.UserId;

                success = WriteCommand(insert);
            }
            return success;
        }

        public DataTable Select()
        {
            DataTable dataTable;
            _query = @"SELECT id, [name], latitude, longitude FROM BranchOffice WHERE [status] = 1";
            using(SqlCommand select = CreateCommand(_query))
            {
                dataTable = ReadCommand(select);
            }
            return dataTable;
        }

        public int Update(BranchOffice t)
        {
            int success;
            _query = @"UPDATE BranchOffice SET [name] = @name, latitude = @latitude, longitude = @longitude, cityId = @cityId,
						lastUpdate = CURRENT_TIMESTAMP, userId = @userId WHERE id = @id";
            using (SqlCommand update = CreateCommand(_query))
            {
                update.Connection.Open();
                update.Parameters["@name"].Value = t.Name;
                update.Parameters["@latitude"].Value = t.Latitude;
                update.Parameters["@longitude"].Value = t.Longitude;
                update.Parameters["@cityId"].Value = t.CityId;
                update.Parameters["@userId"].Value = t.UserId;
                update.Parameters["@id"].Value = t.Id;

                success = WriteCommand(update);
            }
            return success;
        }
    }
}
