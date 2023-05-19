using System.Data;

namespace HeraclesDAO.Interfaces
{
    internal interface IBaseInterface<T>
    {
        DataTable Select();
        int Insert(T t);
        int Update(T t);
        int Delete(T t);
    }
}
