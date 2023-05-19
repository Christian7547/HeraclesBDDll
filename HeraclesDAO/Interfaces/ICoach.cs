using HeraclesDAO.Models;

namespace HeraclesDAO.Interfaces
{
    internal interface ICoach : IBaseInterface<Coach>
    {
        Coach GetCoach(byte id);
    }
}
