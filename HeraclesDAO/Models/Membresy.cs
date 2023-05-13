using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeraclesDAO.Models
{
    public class Membresy : BaseModel
    {
        public byte Id { get; set; }
        public string TypeMembresy { get; set; }
        public float Price { get; set; }
    }
}
