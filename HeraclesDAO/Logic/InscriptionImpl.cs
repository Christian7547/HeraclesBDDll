using HeraclesDAO.Interfaces;
using HeraclesDAO.Models;
using HeraclesDAO.Models.Session;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HeraclesDAO.Logic
{
    public class InscriptionImpl : BaseImpl, I_Inscription
    {
        public int Delete(Inscription m)
        {
            int success;
            _query = @"UPDATE Inscription SET [status] = 0, lastUpdate = CURRENT_TIMESTAMP, userId = @userId WHERE id = @id";
            using (SqlCommand delete = CreateCommand(_query))
            {
                delete.Connection.Open();
                delete.Parameters.AddWithValue("@id", m.Id);
                delete.Parameters.AddWithValue("@userId", SessionClass.SessionId);
                success = WriteCommand(delete);
            }
            return success;
        }

        public int Insert(Member m, Inscription i)
        {
            List<SqlCommand> commands = new List<SqlCommand>();

            string queryMember = @"INSERT INTO Member(names, lastName, secondLastName, userId) 
                                    VALUES(@names, @lastName, @second, @userId)";
            string queryInscription = @"INSERT INTO Inscription(startDate, endDate, membresyId, memberId, userId)
                                    VALUES(@start, @end, @membresy, @member, @userId)";
            bool success;
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand insertMember = new SqlCommand(queryMember);
                SqlCommand insertInscription = new SqlCommand(queryInscription);

                insertMember.Parameters.AddWithValue("@names", m.Name);
                insertMember.Parameters.AddWithValue("@lastName", m.LastName);
                insertMember.Parameters.AddWithValue("@second", m.SecondLastName);
                insertMember.Parameters.AddWithValue("@userId", SessionClass.SessionId);

                DataTable dt = FindLastId(@"'Member'");
                m.Id = short.Parse(dt.Rows[0][0].ToString());

                insertInscription.Parameters.AddWithValue("@start", i.Start);
                insertInscription.Parameters.AddWithValue("@end", i.Finish);
                insertInscription.Parameters.AddWithValue("@membresy", i.MembresyId);
                insertInscription.Parameters.AddWithValue("@member", m.Id + 1);
                insertInscription.Parameters.AddWithValue("@userId", SessionClass.SessionId);

                commands.Add(insertMember);
                commands.Add(insertInscription);

                success = ExecuteAnyCommands(transaction, commands);
            }
            if (success)
                return 1;
            return 0;
        }

        public DataTable Select()
        {
            DataTable dt;
            _query = @"SELECT I.id AS ID, M.id AS MemberId, M.names AS 'Name', M.lastName AS 'LastName', M.secondLastName AS 'SecondLastName', My.[type] AS 'Type' ,I.startDate AS 'Start', I.endDate AS 'Finish'
                        FROM Inscription I
                        INNER JOIN Member M ON M.id = I.memberId
						INNER JOIN Membresy My ON My.id = I.membresyId
                        WHERE I.[status] = 1";
            using (SqlCommand select = CreateCommand(_query))
            {
                dt = ReadCommand(select);
            }
            return dt;
        }

        public int Update(Inscription i, Member m)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            string queryInscription = @"UPDATE Inscription SET membresyId = @membresy, startDate = @start, endDate = @end, 
                                        lastUpdate = CURRENT_TIMESTAMP, userId = @userId 
                                        WHERE id = @id";
            string queryMember = @"UPDATE Member SET names = @names, lastName = @lastName, secondLastName = @second, 
                                        lastUpdate = CURRENT_TIMESTAMP, userId = @userId
                                        WHERE id = @id";
            bool success;
            using(SqlConnection connection = CreateConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand updateMember = new SqlCommand(queryMember);
                SqlCommand updateInscription = new SqlCommand(queryInscription);

                updateMember.Parameters.AddWithValue("@id", m.Id);
                updateMember.Parameters.AddWithValue("@names", m.Name);
                updateMember.Parameters.AddWithValue("@lastName", m.LastName);
                updateMember.Parameters.AddWithValue("@second", m.SecondLastName);
                updateMember.Parameters.AddWithValue("@userId", SessionClass.SessionId);

                updateInscription.Parameters.AddWithValue("@id", i.Id);
                updateInscription.Parameters.AddWithValue("@membresy", i.MembresyId);
                updateInscription.Parameters.AddWithValue("@start", i.Start);
                updateInscription.Parameters.AddWithValue("@end", i.Finish);
                updateInscription.Parameters.AddWithValue("@userId", SessionClass.SessionId);

                commands.Add(updateMember);
                commands.Add(updateInscription);

                success = ExecuteAnyCommands(transaction, commands);
            }
            if (success)
                return 1;
            return 0;
        }
    }
}