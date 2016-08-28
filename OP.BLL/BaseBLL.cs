using OP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.BLL
{
    public class BaseBLL
    {
        protected static PlusContext baseContext { get; set; }

        static BaseBLL()
        {
            baseContext = new PlusContext();
        }
    }
}
