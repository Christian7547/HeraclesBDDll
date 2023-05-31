using HeraclesDAO.Logic;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Heracles.Utilities
{
    internal class Validate
    {
        public void FieldTextValid(KeyEventArgs eventArgs)
        {
            if((int)eventArgs.Key >= 44 && (int)eventArgs.Key <= 69)
                eventArgs.Handled = false;
            else
                eventArgs.Handled = true;
        }

        public void FieldNumberValid(KeyEventArgs eventArgs)
        {
            if (((int)eventArgs.Key >= 34 && (int)eventArgs.Key <= 43) ||
                ((int)eventArgs.Key >= 74 && (int)eventArgs.Key <= 83))
                eventArgs.Handled = false;
            else
                eventArgs.Handled = true;
        }

        public void LockedSpaceKey(KeyEventArgs eventArgs, string keyPress)
        {
            if (eventArgs.Key == Key.Space)
            {
                if(keyPress.EndsWith(" "))
                {
                    eventArgs.Handled = true;
                }
            }
        }

        public bool Inputs(string isValid, byte test)
        {
            switch(test)
            {
                case 0:
                    Regex password = new Regex(@"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*\p{P})(?!.*\s).{8,16}$"); //password
                    if (password.IsMatch(isValid))
                        return true;
                    return false;
                case 1:
                    Regex textLength = new Regex(@"^(?!$)(?=[A-Za-zñÑáéíóúÁÉÍÓÚüÜ\s]{2})[A-Za-zñÑáéíóúÁÉÍÓÚüÜ\s]*$"); //names
                    if (textLength.IsMatch(isValid))
                        return true;
                    return false;
                case 2:
                    Regex ci = new Regex(@"^[0-9]+[-]?[a-zA-Z]?$"); //numbers, followed by an optional hyphen, followed by an optional letter
                    if (ci.IsMatch(isValid))
                        return true;
                    return false;
                case 3:
                    Regex phone = new Regex(@"^(7|6)\d{7}$"); //phones
                    if (phone.IsMatch(isValid))
                        return true;
                    return false;
                case 4:
                    Regex typeMembresy = new Regex(@"^(?!$)(?=[A-Za-zñÑáéíóúÁÉÍÓÚüÜ\s]{2})[A-Za-zñÑáéíóúÁÉÍÓÚüÜ\s]*$");
                    if (typeMembresy.IsMatch(isValid))
                        return true;
                    return false;
                case 5:
                    Regex prices = new Regex(@"^(?:[1-9][0-9]{1,2}|999)$");
                    if (prices.IsMatch(isValid))
                        return true;
                    return false;
                case 6:
                    Regex email = new Regex(@"^[a-zA-Z0-9]+@[a-z]+\.[a-z]+(?:\.[a-z]+)?$"); // email
                    if (email.IsMatch(isValid))
                        return true;
                    return false;
                default:
                    return false;
            }
        }

        public bool Dates(DateTime dateTime, byte action)
        {
            switch (action)
            {
                case 0:
                    //ANNUAL
                    DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    DateTime end = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month, DateTime.Now.Day);
                    if(dateTime >= start && dateTime <= end)
                    {
                        return true;
                    }
                    return false;
                case 1:
                    //MONTHLY
                    DateTime startMonthly = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    DateTime endMonthly = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);
                    if(dateTime >= startMonthly && dateTime <= endMonthly)
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        public byte SelectionAsignments(short schedule, short room)
        {
            byte found = 0;
            TeachImpl teachImpl = new TeachImpl();
            DataTable dt = teachImpl.SearchForMatches();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                if (schedule == short.Parse(dt.Rows[i][2].ToString()) //same room, same schedule
                    && room == short.Parse(dt.Rows[i][3].ToString()))
                {
                    break;
                }
                else
                {
                    if (schedule != short.Parse(dt.Rows[i][2].ToString())  //another room, another schedule
                        && room != short.Parse(dt.Rows[i][3].ToString()))
                    {
                        found = 2;
                        return found;
                    }
                    else
                    {
                        if (schedule != short.Parse(dt.Rows[i][2].ToString())
                            && room == short.Parse(dt.Rows[i][3].ToString()))
                        {
                            found = 0; //same room, another schedule 
                        }
                        else
                            found = 3;
                    }
                }
            }
            return found;
        }
    }
}
