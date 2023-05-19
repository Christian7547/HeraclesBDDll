using HeraclesDAO.Interfaces;
using HeraclesDAO.Models;
using HeraclesDAO.Models.Session;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HeraclesDAO.Logic
{
    public class UserImpl : BaseImpl, IUser
    {
        public int Delete(User t)
        {
            _query = @"UPDATE [User] SET [status] = 0, lastUpdate = CURRENT_TIMESTAMP, userId = @userId WHERE id = @id";
            using(SqlCommand delete = CreateCommand(_query))
            {
                delete.Connection.Open();
                delete.Parameters.AddWithValue("@id", t.Id); 
                delete.Parameters.AddWithValue("@userId", SessionClass.SessionId);

                return WriteCommand(delete);
            }
        }

        public int Insert(User t)
        {
            _query = @"INSERT INTO [User] (email, userName, [password], [role], userId) 
                        VALUES (@email, @userName, HASHBYTES('MD5', @password), @role, @userId)";
            using(SqlCommand insert = CreateCommand(_query))
            {
                insert.Connection.Open();

                insert.Parameters.AddWithValue("@email", t.Email);
                insert.Parameters.AddWithValue("@userName", t.UserName);
                insert.Parameters.AddWithValue("@password", t.Password).SqlDbType = SqlDbType.VarChar;
                insert.Parameters.AddWithValue("@role", t.Role);
                insert.Parameters.AddWithValue("@userId", SessionClass.SessionId);

                return WriteCommand(insert);    
            }
        }

        public DataTable Select()
        {
            _query = @"SELECT id AS ID, email AS Email, userName AS UserName, [role] AS 'Role' FROM [User] WHERE [status] = 1";
            using(SqlCommand select = CreateCommand(_query))
            {
                return ReadCommand(select);
            }
        }

        public int Update(User t)
        {
            _query = @"UPDATE [User] SET email = @email, userName = @userName, [role] = @role,
                            lastUpdate = CURRENT_TIMESTAMP, userId = @userId
                       WHERE id = @id";
            using(SqlCommand  update = CreateCommand(_query))
            {
                update.Connection.Open();
                update.Parameters.AddWithValue("@email", t.Email);
                update.Parameters.AddWithValue("@userName", t.UserName);
                update.Parameters.AddWithValue("@role", t.Role);
                update.Parameters.AddWithValue("@userId", SessionClass.SessionId);
                update.Parameters.AddWithValue("@id", t.Id);

                return WriteCommand(update);
            }
        }

        public DataTable Login(string userName, string password)
        {
            _query = @"SELECT id, userName, [role], email
                        FROM [User] 
                        WHERE [status] = 1 AND userName = @userName AND [password] = HASHBYTES('MD5', @password)";
            using (SqlCommand login = CreateCommand(_query))
            {
                login.Parameters.AddWithValue("@userName", userName);
                login.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
                login.Parameters.AddWithValue("@id", SessionClass.SessionId);

                return ReadCommand(login);
            }
        }

        public int ChangePassword(string newPassword, string oldPassword)
        {
            _query = @"UPDATE [User] SET [password] = HASHBYTES('MD5', @newPassword), lastUpdate = CURRENT_TIMESTAMP, 
                            userId = @userId
                       WHERE id = @id AND email = @email AND [password] = HASHBYTES('MD5', @oldPassword)";
            using(SqlCommand change = CreateCommand(_query))
            {
                change.Connection.Open();   
                change.Parameters.AddWithValue("@newPassword", newPassword).SqlDbType = SqlDbType.VarChar;
                change.Parameters.AddWithValue("@oldPassword", oldPassword).SqlDbType = SqlDbType.VarChar;
                change.Parameters.AddWithValue("@userId", SessionClass.SessionId);
                change.Parameters.AddWithValue("@email", SessionClass.SessionEmail);
                change.Parameters.AddWithValue("@id", SessionClass.SessionId); 
                return WriteCommand(change);
            }
        }
    }
}
