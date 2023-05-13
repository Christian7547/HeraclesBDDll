using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeraclesDAO.Models
{
    public class User : BaseModel
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte RoleId { get; set; }    
    }
}
