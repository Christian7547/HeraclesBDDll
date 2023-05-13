using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
