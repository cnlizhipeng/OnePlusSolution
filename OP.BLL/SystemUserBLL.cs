using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.IBLL;
using OP.Model;

namespace OP.BLL
{
    public class SystemUserBLL : ISystemUserBLL
    {
        public SystemUser Login(string usernam, string pwd, string yzm)
        {
            if (usernam.Equals("李志鹏") && pwd.Equals("123"))
                return new SystemUser() { Employee = null, EmployeeID = 1, ID = 1, UserName = "李志鹏", UserPwd = "123" };
            else
                return null;
        }
    }
}
