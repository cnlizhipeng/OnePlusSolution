
using System.ComponentModel.DataAnnotations.Schema;

namespace OP.Model
{
    public class SystemUser
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public int EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employees Employee { get; set; }

    }
}
