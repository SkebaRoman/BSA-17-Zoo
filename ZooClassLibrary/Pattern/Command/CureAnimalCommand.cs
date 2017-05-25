using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooClassLibrary.Pattern.Command
{
    public class CureAnimalCommand : UserCommand
    {
        private Zoo zoo;
        private string name;
        public CureAnimalCommand(Zoo zoo, string name)
        {
            this.zoo = zoo;
            this.name = name;
        }

        public override void Execute()
        {
            zoo.CureAnimal(name);
        }
    }
}
