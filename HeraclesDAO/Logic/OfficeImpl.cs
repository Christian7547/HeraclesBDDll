using HeraclesDAO.Interfaces;
using HeraclesDAO.Models;
using HeraclesDAO.Models.Session;
using System.Data;
using System.Data.SqlClient;

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
                delete.Parameters.AddWithValue("@userId", SessionClass.SessionId);
                delete.Parameters.AddWithValue("@id", t.Id);
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
                insert.Parameters.AddWithValue("@userId", SessionClass.SessionId);

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
                update.Parameters.AddWithValue("@name", t.Name);
                update.Parameters.AddWithValue("@latitude", t.Latitude);
                update.Parameters.AddWithValue("@longitude", t.Longitude);
                update.Parameters.AddWithValue("@cityId", t.CityId);
                update.Parameters.AddWithValue("@userId", SessionClass.SessionId);
                update.Parameters.AddWithValue("@id", t.Id);

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
