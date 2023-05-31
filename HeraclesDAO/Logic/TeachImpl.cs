using HeraclesDAO.Interfaces;
using HeraclesDAO.Models;
using HeraclesDAO.Models.Session;
using System.Data;
using System.Data.SqlClient;

namespace HeraclesDAO.Logic
{
    public class TeachImpl : BaseImpl, ITeach
    {
        public DataTable Select()
        {
            DataTable dt;
            _query = @"SELECT T.id AS ID, CONCAT(C.names,' ',C.lastName,' ',C.secondLastName) AS Coach, L.name AS Lesson, 
                            CONCAT(S.day,'  ',S.startHour,' - ',S.finishHour) AS Schedule, R.name AS 'Room'
                        FROM Teach T
                        INNER JOIN Coach C ON C.id = T.coachId
                        INNER JOIN Lesson L ON L.id = T.lessonId
                        INNER JOIN Schedule S ON S.id = T.scheduleId
                        INNER JOIN Room R ON R.id = T.roomId
                        WHERE T.[status] = 1";

            using(SqlCommand select = CreateCommand(_query))
            {
                dt = ReadCommand(select);
            }
            return dt;
        }

        public int Insert(Teach t)
        {
            int success;
            _query = @"INSERT INTO Teach(coachId, lessonId, scheduleId, roomId, userId) 
                        VALUES(@coachId, @lessonId, @scheduleId, @roomId, @userId)";
            using(SqlCommand  insert = CreateCommand(_query))
            {
                insert.Connection.Open();

                insert.Parameters.AddWithValue("@coachId", t.CoachId);
                insert.Parameters.AddWithValue("@lessonId", t.LessonId);
                insert.Parameters.AddWithValue("@scheduleId", t.ScheduleId);
                insert.Parameters.AddWithValue("@roomId", t.RoomId);
                insert.Parameters.AddWithValue("@userId", SessionClass.SessionId);

                success = WriteCommand(insert);
            }
            return success;
        }

        public int Update(Teach t)
        {
            int success;
            _query = @"UPDATE Teach SET coachId = @coach, lessonId = @lesson, scheduleId = @schedule, 
                            roomId = @room, lastUpdate = CURRENT_TIMESTAMP, userId = @userId 
                       WHERE id = @id";
            using (SqlCommand update = CreateCommand(_query))
            {
                update.Connection.Open();

                update.Parameters.AddWithValue("@id", t.Id);
                update.Parameters.AddWithValue("@coach", t.CoachId);
                update.Parameters.AddWithValue("@lesson", t.LessonId);
                update.Parameters.AddWithValue("@schedule", t.ScheduleId);
                update.Parameters.AddWithValue("@room", t.RoomId);
                update.Parameters.AddWithValue("@userId", SessionClass.SessionId);

                success = WriteCommand(update);
            }
            return success;
        }

        public int Delete(Teach t)
        {
            int deleted;
            _query = @"UPDATE Teach SET [status] = 0, lastUpdate = CURRENT_TIMESTAMP, userId = @user WHERE id = @id";
            using (SqlCommand delete = CreateCommand(_query))
            {
                delete.Connection.Open();
                
                delete.Parameters.AddWithValue("@id", t.Id);
                delete.Parameters.AddWithValue("@user", SessionClass.SessionId);

                deleted = WriteCommand(delete);
            }
            return deleted;
        }

        public DataTable SearchForMatches()
        {
            DataTable dt;
            _query = @"SELECT coachId, lessonId, scheduleId, roomId FROM Teach WHERE [status] = 1";

            using (SqlCommand select = CreateCommand(_query))
            {
                dt = ReadCommand(select);
            }
            return dt;
        }
    }
}
