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
    public class AccountBLL : BaseBLL,IAccountBLL
    {
        public IEnumerable<SystemUser> GetAll()
        {
            var q = baseContext.SystemUser.ToList();
            return q;
        }

        public IEnumerable<SysModules> GetModules()
        {
            var q = baseContext.SysModules.ToList();
            return q;
        }

        public IEnumerable<SysModules> GetModules(int pid)
        {
            var Nodes = from q in baseContext.SysModules
                        where q.PID == pid
                        select q;

            return Nodes.ToList().Concat(Nodes.ToList().SelectMany(s => GetModules(s.ID)));
        }
    }
}
