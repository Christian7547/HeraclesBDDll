using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HeraclesWeb.Utilities
{
    public class ValidateWeb
    {
        public bool Inputs(string isValid, byte action)
        {
            switch(action)
            {
                case 1:
                    Regex password = new Regex(@"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*\p{P})(?!.*\s).{8,16}$"); //password
                    if (password.IsMatch(isValid))
                        return true;
                    return false;
                default:
                    return false;

            }
        }
    }
}