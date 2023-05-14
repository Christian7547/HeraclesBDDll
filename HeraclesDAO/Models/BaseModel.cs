using System;

namespace HeraclesDAO.Models
{
    public class BaseModel
    {
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public byte Status { get; set; }
        public int UserId { get; set; }
    }
}
