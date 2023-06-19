using HeraclesDAO.Interfaces;
using HeraclesDAO.Models;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using HeraclesDAO.Models.Session;

namespace HeraclesDAO.Logic
{
    public class MemberImpl : BaseImpl
    {
        public DataTable Select()
        {
            _query = @"SELECT id AS ID, names AS 'Names', lastName AS 'LastName', secondLastName AS 'SecondLastName' 
                            FROM Member 
                            WHERE [status] = 1
                            ORDER BY 2"; 
            using(SqlCommand select = CreateCommand(_query))
            {
                return ReadCommand(select);
            }
        }

        public int Delete(Member member)
        {
            int success;
            _query = @"UPDATE Member SET [status] = 0, lastUpdate = CURRENT_TIMESTAMP, userId = @userId WHERE id = @id";
            using(SqlCommand delete = CreateCommand(_query))
            {
                delete.Connection.Open();
                delete.Parameters.AddWithValue("@id", member.Id);
                delete.Parameters.AddWithValue("@userId", SessionClass.SessionId);

                success = WriteCommand(delete);           
            }
            return success;
        }

        public DataTable GetMeasures(int memberId)
        {
            _query = @"SELECT weight, chest, arm, leg, waist FROM Measures WHERE memberId = @id";
            using(SqlCommand  getMeasures = CreateCommand(_query))
            {
                getMeasures.Parameters.AddWithValue("@id", memberId);
                return ReadCommand(getMeasures);
            }
        }

        public int Insert(Member member, Measures measures)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            string query = @"INSERT INTO Member (names, lastName, secondLastName, userId) 
                            VALUES (@name, @lastName, @secondLastName, @user)";
            string queryMeasures = @"INSERT INTO Member (memberId, weight, chest, arm, leg, waist) 
                                    VALUES (@memberId, @weight, @chest, @arm, @leg, @waist)";
            bool success;
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand insert = new SqlCommand(query);
                SqlCommand insertMeasures = new SqlCommand(queryMeasures);

                insert.Parameters.AddWithValue("@name", member.Name);
                insert.Parameters.AddWithValue("@lastName", member.LastName);
                insert.Parameters.AddWithValue("@secondLastName", member.SecondLastName);
                insert.Parameters.AddWithValue("@user", SessionClass.SessionId);

                DataTable dataTable = FindLastId(@"'Member'");
                member.Id = int.Parse(dataTable.Rows[0][0].ToString());

                insertMeasures.Parameters.AddWithValue("@memberId", member.Id + 1);
                insertMeasures.Parameters.AddWithValue("@weight", measures.Weight);
                insertMeasures.Parameters.AddWithValue("@chest", measures.ChestMeasure);
                insertMeasures.Parameters.AddWithValue("@arm", measures.ArmMeasure);
                insertMeasures.Parameters.AddWithValue("@leg", measures.LegMeasure);
                insertMeasures.Parameters.AddWithValue("@waist", measures.Waist);

                commands.Add(insert);
                commands.Add(insertMeasures);
                success = ExecuteAnyCommands(transaction, commands);    
            }
            if (success)
                return 1;
            return 0;
        }

        public int Update(Member member, Measures measures)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            string query = @"UPDATE Member SET names = @names, lastName = @lastName, secondLastName = @second, 
                                lastUpdate = CURRENT_TIMESTAMP, userId = @user
                                WHERE id = @id";
            string queryMeasures = @"UPDATE Measures SET [weight] = @weight, chest = @chest, arm = @arm, leg = @leg, 
                                waist = @waist
                                WHERE memberId = @memberId";

            bool success;
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand updateMember = new SqlCommand(query);
                SqlCommand updateMeasures = new SqlCommand(queryMeasures);

                updateMember.Parameters.AddWithValue("@names", member.Name);
                updateMember.Parameters.AddWithValue("@lastName", member.LastName);
                updateMember.Parameters.AddWithValue("@secondLastName", member.SecondLastName);
                updateMember.Parameters.AddWithValue("@user", SessionClass.SessionId);
                updateMember.Parameters.AddWithValue("@id", member.Id);

                updateMeasures.Parameters.AddWithValue("@memberId", member.Id);
                updateMeasures.Parameters.AddWithValue("@weight", measures.Weight);
                updateMeasures.Parameters.AddWithValue("@chest", measures.ChestMeasure);
                updateMeasures.Parameters.AddWithValue("@arm", measures.ArmMeasure);
                updateMeasures.Parameters.AddWithValue("@leg", measures.LegMeasure);
                updateMeasures.Parameters.AddWithValue("@waist", measures.Waist);

                commands.Add(updateMember);
                commands.Add(updateMeasures);
                success = ExecuteAnyCommands(transaction, commands);
            }
            if (success)
                return 1;
            return 0;
        }
    }
}
