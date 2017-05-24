using System;
using ZooClassLibrary.UserException;

namespace ZooClassLibrary.Pattern
{
    public class Receiver
    {
        private Zoo zoo;
        private string action;
        public Receiver(Zoo zoo, string action)
        {
            this.zoo = zoo;
            this.action = action;
        }
        private bool ValidateAction()
        {
            return action.Split(' ')[0] == "add" && action.Split(' ').Length == 3 ||
                action.Split(' ')[0] == "remove" && action.Split(' ').Length == 2 ||
                action.Split(' ')[0] == "feed" && action.Split(' ').Length == 2 ||
                action.Split(' ')[0] == "cure" && action.Split(' ').Length == 2 ||
                action.Split(' ')[0] == "about" && action.Split(' ').Length == 2 ||
                action.Split(' ')[0] == "help" && action.Split(' ').Length == 1 ||
                action.Split(' ')[0] == "cls" && action.Split(' ').Length == 1 ||
                action.Split(' ')[0] == "all" && action.Split(' ').Length == 1  ? true : false;
        }
        public void Action()
        {
            if (ValidateAction())
            {
                switch (action.Split(' ')[0])
                {
                    case "add":
                        {
                            zoo.AddAnimal(action.Split(' ')[2], action.Split(' ')[1]);
                            Console.WriteLine("Animal was added.");
                            break;
                        }
                    case "remove":
                        {
                            zoo.RemoveAnimal(action.Split(' ')[1]);
                            Console.WriteLine("Animal was removed.");
                            break;
                        }
                    case "cure":
                        {
                            zoo.CureAnimal(action.Split(' ')[1]);
                            Console.WriteLine("Animal was cured");
                            break;
                        }
                    case "feed":
                        {
                            zoo.FeedAnimal(action.Split(' ')[1]);
                            Console.WriteLine("Animal was fed.");
                            break;
                        }
                    case "about":
                        {
                            Console.WriteLine(zoo.AboutAnimal(action.Split(' ')[1]));
                            break;
                        }
                    case "all":
                        {
                            zoo.ShowAllAnimals();
                            break;
                        }
                    case "help":
                        {
                            Help.ShowHelp();
                            break;
                        }
                    case "cls":
                        {
                            Console.Clear();
                            break;
                        }
                    default: throw new InvalidCommandException();
                }
            }
            else
            {
                throw new InvalidCommandException();
            }
        }
    }
}
