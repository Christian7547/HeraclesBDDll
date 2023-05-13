using HeraclesDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeraclesDAO.Interfaces
{
    internal interface IMembresy : IBaseInterface<Membresy>
    {
        Membresy GetMembresy(byte id);
    }
}
