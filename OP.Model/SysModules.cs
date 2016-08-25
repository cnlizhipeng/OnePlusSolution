using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Model
{
    public class SysModules
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public Guid KeyGuid { get; set; }
        public string ModuleName { get; set; }
        public int ViewOrder { get; set; }
        public bool Web { get; set; }
        public bool Cs { get; set; }
    }
}
