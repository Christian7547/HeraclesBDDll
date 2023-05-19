using HeraclesDAO.Models;
using System.Data;

namespace HeraclesDAO.Interfaces
{
    internal interface IUser : IBaseInterface<User>
    {
        DataTable Login(string username, string password);
        int ChangePassword(string newPassword, string oldPassword);
    }
}
