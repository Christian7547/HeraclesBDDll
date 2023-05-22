using HeraclesDAO.Interfaces;
using HeraclesDAO.Models;
using HeraclesDAO.Models.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HeraclesDAO.Logic
{
    public class UserImpl : BaseImpl, IUser
    {
        public int Delete(User t)
        {
            int success;
            _query = @"UPDATE [User] SET [status] = 0, lastUpdate = CURRENT_TIMESTAMP, userId = @userId WHERE id = @id";
            using(SqlCommand delete = CreateCommand(_query))
            {
                delete.Connection.Open();
                delete.Parameters.AddWithValue("@id", t.Id); 
                delete.Parameters.AddWithValue("@userId", SessionClass.SessionId);

                success = WriteCommand(delete);
            }
            return success;
        }

        public int Insert(User t)
        {
            int success;
            _query = @"INSERT INTO [User] (names, lastName, email, userName, [password], [role], userId) 
                        VALUES (@names, @lastName, @email, @userName, HASHBYTES('MD5', @password), @role, @userId)";
            using(SqlCommand insert = CreateCommand(_query))
            {
                insert.Connection.Open();

                insert.Parameters.AddWithValue("@names", t.Name);
                insert.Parameters.AddWithValue("@lastName", t.LastName);
                insert.Parameters.AddWithValue("@email", t.Email);
                insert.Parameters.AddWithValue("@userName", t.UserName);
                insert.Parameters.AddWithValue("@password", t.Password).SqlDbType = SqlDbType.VarChar;
                insert.Parameters.AddWithValue("@role", t.Role);
                insert.Parameters.AddWithValue("@userId", SessionClass.SessionId);

                success = WriteCommand(insert);    
            }
            return success;
        }

        public DataTable Select()
        {
            DataTable data;
            _query = @"SELECT id AS ID, names AS 'Name', lastName AS LastName, email AS Email, userName AS UserName, [role] AS 'Role' FROM [User] WHERE [status] = 1";
            using(SqlCommand select = CreateCommand(_query))
            {
                data = ReadCommand(select);
            }
            return data;
        }

        public int Update(User t)
        {
            int success;
            _query = @"UPDATE [User] SET names = @names, lastName = @lastName, email = @email, userName = @user, 
                            [role] = @role, lastUpdate = CURRENT_TIMESTAMP, userId = @userId
                        WHERE id = @id";
            using(SqlCommand update = CreateCommand(_query))
            {
                update.Connection.Open();
                update.Parameters.AddWithValue("@names", t.Name);
                update.Parameters.AddWithValue("@lastName", t.LastName);
                update.Parameters.AddWithValue("@email", t.Email);
                update.Parameters.AddWithValue("@user", t.UserName);
                update.Parameters.AddWithValue("@role", t.Role);
                update.Parameters.AddWithValue("@userId", SessionClass.SessionId);
                update.Parameters.AddWithValue("@id", t.Id);

                success = WriteCommand(update);
            }
            return success;
        }

        public DataTable Login(string userName, string password)
        {
            DataTable dataTable;
            _query = @"SELECT id, userName, [role], email, firstSession
                        FROM [User] 
                        WHERE [status] = 1 AND userName = @userName AND [password] = HASHBYTES('MD5', @password)";
            using (SqlCommand login = CreateCommand(_query))
            {
                login.Parameters.AddWithValue("@userName", userName);
                login.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
                login.Parameters.AddWithValue("@id", SessionClass.SessionId);

                dataTable = ReadCommand(login);
            }
            return dataTable;
        }

        public int ChangePassword(string newPassword, string oldPassword)
        {
            int success;
            _query = @"UPDATE [User] SET [password] = HASHBYTES('MD5', @newPassword), lastUpdate = CURRENT_TIMESTAMP, 
                            userId = @userId
                       WHERE id = @id AND [password] = HASHBYTES('MD5', @oldPassword)";
            using(SqlCommand change = CreateCommand(_query))
            {
                change.Connection.Open();   
                change.Parameters.AddWithValue("@newPassword", newPassword).SqlDbType = SqlDbType.VarChar;
                change.Parameters.AddWithValue("@oldPassword", oldPassword).SqlDbType = SqlDbType.VarChar;
                change.Parameters.AddWithValue("@userId", SessionClass.SessionId);
                change.Parameters.AddWithValue("@id", SessionClass.SessionId); 
                success = WriteCommand(change);
            }
            return success;
        }

        public bool FirstSession()
        {
            _query = @"UPDATE [User] SET firstSession = 1, lastUpdate = CURRENT_TIMESTAMP,
                        userId = @userId
                        WHERE id = @id";
            using(SqlCommand firstSession = CreateCommand(_query))
            {
                firstSession.Connection.Open();
                firstSession.Parameters.AddWithValue("@userId", SessionClass.SessionId);
                firstSession.Parameters.AddWithValue("@id", SessionClass.SessionId);
                WriteCommand(firstSession);
            }
            return true;
        }
    }
}
