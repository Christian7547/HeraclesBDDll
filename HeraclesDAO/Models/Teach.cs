namespace HeraclesDAO.Models
{
    public class Teach : BaseModel
    {
        public int Id { get; set; }
        public short CoachId { get; set; }
        public short LessonId { get; set; }
        public short ScheduleId { get; set; }
        public short RoomId { get; set; }
    }
}
