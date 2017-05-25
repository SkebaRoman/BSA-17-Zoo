using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooClassLibrary.Pattern.Command
{
    public class AddAnimalCommand : UserCommand
    {
        private Zoo zoo;
        private string name;
        private string type;
        public AddAnimalCommand(Zoo zoo, string name, string type)
        {
            this.zoo = zoo;
            this.name = name;
            this.type = type;
        }
        public override void Execute()
        {
            zoo.AddAnimal(name, type);
        }
    }
}
