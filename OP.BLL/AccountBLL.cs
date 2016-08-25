using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.IBLL;
using OP.Model;
using OP.DAL;

namespace OP.BLL
{
    public class AccountBLL : IAccountBLL
    {
        public IEnumerable<SystemUser> GetAll()
        {
            PlusContext pc = new PlusContext();
            var q = pc.SystemUser.ToList();
            return q;
        }

        public IEnumerable<SysModules> GetModules()
        {
            PlusContext pc = new PlusContext();
            var q = pc.SysModules.ToList();
            return q;
        }
    }
}
