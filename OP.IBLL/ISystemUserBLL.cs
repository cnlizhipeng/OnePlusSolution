using OP.Model;

namespace OP.IBLL
{
    public interface ISystemUserBLL
    {
        SystemUser Login(string usernam, string pwd, string yzm);
    }
}
