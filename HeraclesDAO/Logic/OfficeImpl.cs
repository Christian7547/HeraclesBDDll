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
    public class OfficeImpl : BaseImpl, IBranchOffice
    {
        public int Delete(Office t)
        {
            int success;
            _query = @"UPDATE BranchOffice SET [status] = 0, lastUpdate = CURRENT_TIMESTAMP, userId = @userId WHERE id = @id";
            using(SqlCommand delete = CreateCommand(_query))
            {
                delete.Connection.Open();
                delete.Parameters["@userId"].Value = t.UserId;
                delete.Parameters["@id"].Value = t.Id;
                success = WriteCommand(delete);
            }
            return success;
        }

        public int Insert(Office t)
        {
            int success;
            _query = @"INSERT INTO BranchOffice([name], latitude, longitude, cityId, userId) 
                        VALUES(@name, @latitude, @longitude, @cityId, @userId)";
            using (SqlCommand insert = CreateCommand(_query))
            {
                insert.Connection.Open();
                insert.Parameters.AddWithValue("@name", t.Name);
                insert.Parameters.AddWithValue("@latitude", t.Latitude);
                insert.Parameters.AddWithValue("@longitude", t.Longitude);
                insert.Parameters.AddWithValue("@cityId", t.CityId);
                insert.Parameters.AddWithValue("@userId", t.UserId);

                success = WriteCommand(insert);
            }
            return success;
        }

        public DataTable Select()
        {
            DataTable dataTable;
            _query = @"SELECT O.id AS ID, O.[name] AS Office, O.latitude AS Latitude, O.longitude AS Longitude, C.[name] AS City
	                            FROM BranchOffice O
	                            INNER JOIN City C ON C.id = O.cityId
	                            WHERE O.[status] = 1";
            using (SqlCommand select = CreateCommand(_query))
            {
                dataTable = ReadCommand(select);
            }
            return dataTable;
        }

        public int Update(Office t)
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

        public DataTable GetCities()
        {
            DataTable data;
            _query = @"SELECT id, [name] FROM City ORDER BY [name]";
            using(SqlCommand getCities = CreateCommand(_query))
            {
                data = ReadCommand(getCities);
            }
            return data;
        }
    }
}
