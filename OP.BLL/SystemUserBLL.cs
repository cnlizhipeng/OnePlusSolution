using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.IBLL;
using OP.Model;

namespace OP.BLL
{
    public class SystemUserBLL : ISystemUserBLL<SystemUser>
    {
        public SystemUser Login(string usernam, string pwd, string yzm)
        {
            return new SystemUser() {  Employee=null, EmployeeID=1, ID=1, UserName="李志鹏", UserPwd="123"};
        }
    }
}
