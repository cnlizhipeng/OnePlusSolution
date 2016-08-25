using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Model;

namespace OP.IBLL
{
    public interface IAccountBLL
    {
        IEnumerable<SystemUser> GetAll();

        IEnumerable<SysModules> GetModules();
    }
}
