using System;

namespace HeraclesDAO.Logic.CreateUser
{
    public class NewUser
    {
        public string GenerateUserName(string name, string lastName, string email)
        {
            string characters = "0123456789_-.@$";
            string newName = name.Substring(0, 1).ToLower();
            string newLastName = lastName.Substring(0, 1).ToLower();
            string newEmail = email.Substring(0, 5).ToLower();
            string newCharacters = "";
            Random random = new Random();

            for(int i = 0; i < 4; i++)
            {
                int s = random.Next(0, characters.Length);
                newCharacters = newCharacters + characters[s];
            }
            
            string UserName = string.Concat(newName, newLastName, newEmail, newCharacters);
            return UserName;
        }

        public string GeneratePassword()
        {
            string characters = @"ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789_-.@*$";
            string password = "";
            Random random = new Random();

            for (int i = 0; i < 8; i++)
            {
                int s = random.Next(0, characters.Length);
                password = password + characters[s];
            }
            return password;
        }
    }
}
