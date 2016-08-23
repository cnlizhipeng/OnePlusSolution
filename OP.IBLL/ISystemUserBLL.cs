using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.IBLL
{
    public interface ISystemUserBLL<T> where T:class
    {
        T Login(string usernam, string pwd, string yzm);
    }
}
