using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooClassLibrary.Pattern.Command
{
    public class ShowAllAnimalsCommand : UserCommand
    {
        private Zoo zoo;
        public ShowAllAnimalsCommand(Zoo zoo)
        {
            this.zoo = zoo;
        }
        public override void Execute()
        {
            zoo.ShowAllAnimals();
        }
    }
}
