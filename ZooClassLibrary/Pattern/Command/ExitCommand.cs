using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.UserException;

namespace ZooClassLibrary.Pattern.Command
{
    public class ExitCommand : UserCommand
    {
        public override void Execute()
        {
            throw new ExitException();
        }
    }
}
