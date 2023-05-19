using HeraclesDAO.Models;

namespace HeraclesDAO.Interfaces
{
    internal interface IMembresy : IBaseInterface<Membresy>
    {
        Membresy GetMembresy(byte id);
    }
}
