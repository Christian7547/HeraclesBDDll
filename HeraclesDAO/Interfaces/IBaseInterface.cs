using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
