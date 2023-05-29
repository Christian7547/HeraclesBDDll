﻿using System;
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
                    Regex textLength = new Regex(@"^[A-Z][a-záéíóúñ]{1,}( [A-Z][a-záéíóúñ]*)?$"); //names
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
                    Regex typeMembresy = new Regex(@"^[A-Z][a-zA-Z]{4,10}$");
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
    }
}