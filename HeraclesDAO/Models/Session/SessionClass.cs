using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HeraclesDAO.Models.Session
{
    public static class SessionClass
    {
        public static int SessionId { get; set; }
        public static string SessionEmail { get; set; }
        public static string SessionUserName { get; set; }
        public static string SessionRole { get; set; }
    }
}
