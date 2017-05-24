using System;
using System.Threading.Tasks;
using ZooClassLibrary;
using ZooClassLibrary.Pattern;

namespace UIClassLibrary
{
    public class UserInterface
    {
        private Zoo zoo;
        public void OpenZoo(Zoo zoo)
        {
            string textLine = string.Empty;
            this.zoo = zoo;

            while (true)
            {
                try
                {
                    Console.Write("Enter some action: ");
                    textLine = Console.ReadLine().ToLower();

                    Receiver receiver = new Receiver(zoo, textLine);
                    Command command = new ConcreteCommand(receiver);
                    Invoker invoker = new Invoker();

                    invoker.SetCommand(command);
                    invoker.ExecuteCommand();

                    Console.WriteLine(new string('-', 50));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
