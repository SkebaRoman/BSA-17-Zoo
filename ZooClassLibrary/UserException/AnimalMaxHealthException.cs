using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooClassLibrary.UserException
{
    public class AnimalMaxHealthException: Exception
    {
        public override string Message
        {
            get
            {
                return string.Format("Animal Max Health Exception");
            }
        }
    }
}
