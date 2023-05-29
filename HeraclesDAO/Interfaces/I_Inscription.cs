using HeraclesDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeraclesDAO.Interfaces
{
    internal interface I_Inscription
    {
        DataTable Select();
        int Insert(Member m, Inscription i);
        int Update(Inscription i, Member m);
        int Delete(Inscription m);
    }
}
