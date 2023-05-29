using System;

namespace HeraclesDAO.Models
{
    public class Inscription
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int MemberId { get; set; }
        public short MembresyId { get; set; }
    }
}
