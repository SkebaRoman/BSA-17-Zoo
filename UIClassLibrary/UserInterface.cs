using System;
using System.Threading.Tasks;
using ZooClassLibrary;
using ZooClassLibrary.Pattern.Command;
using ZooClassLibrary.UserException;

namespace UIClassLibrary
{
    public class UserInterface
    {
        private Zoo zoo;
        public void OpenZoo(Zoo zoo)
        {
            this.zoo = zoo;
            this.zoo.Exit += Exit;
            string textLine = string.Empty;

            while (true)
            {
                try
                {
                    Console.Write("Enter some action: ");
                    textLine = Console.ReadLine().ToLower();

                    if (textLine == "help")
                    {
                        Help.ShowHelp();
                    }
                    else
                    {
                        Invoker invoker = new Invoker();
                        invoker.SetCommand(GetCommand(textLine));
                        invoker.ExecuteCommand();
                    }

                    Console.WriteLine(new string('-', 50));
                }
                catch (ExitException)
                {
                    Exit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private bool ValidateCommand(string command)
        {
            return command.Split(' ')[0] == "add" && command.Split(' ').Length == 3 ||
                command.Split(' ')[0] == "remove" && command.Split(' ').Length == 2 ||
                command.Split(' ')[0] == "feed" && command.Split(' ').Length == 2 ||
                command.Split(' ')[0] == "cure" && command.Split(' ').Length == 2 ||
                command.Split(' ')[0] == "about" && command.Split(' ').Length == 2 ||
                command.Split(' ')[0] == "cls" && command.Split(' ').Length == 1 ||
                command.Split(' ')[0] == "all" && command.Split(' ').Length == 1 ||
                command.Split(' ')[0] == "exit" && command.Split(' ').Length == 1 ? true : false;
        }
        private UserCommand GetCommand(string command)
        {
            if (ValidateCommand(command))
            {
                switch (command.Split(' ')[0])
                {
                    case "add": return new AddAnimalCommand(zoo, command.Split(' ')[2], command.Split(' ')[1]);
                    case "remove": return new RemoveAnimalCommand(zoo, command.Split(' ')[1]);
                    case "feed": return new FeedAnimalCommand(zoo, command.Split(' ')[1]);
                    case "cure": return new FeedAnimalCommand(zoo, command.Split(' ')[1]);
                    case "about": return new AboutAnimalCommand(zoo, command.Split(' ')[1]);
                    case "all": return new ShowAllAnimalsCommand(zoo);
                    case "cls": return new CleanScreenCommand();
                    case "exit": return new ExitCommand();
                    default: throw new InvalidCommandException();
                }
            }
            else
            {
                throw new InvalidCommandException();
            }
        }

        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}
