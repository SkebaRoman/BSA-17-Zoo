using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooClassLibrary.Pattern.Command
{
    public class RemoveAnimalCommand : UserCommand
    {
        private Zoo zoo;
        private string name;
        public RemoveAnimalCommand(Zoo zoo, string name)
        {
            this.zoo = zoo;
            this.name = name;
        }
        public override void Execute()
        {
            zoo.RemoveAnimal(name);
        }
    }
}
