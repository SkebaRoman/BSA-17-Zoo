using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIClassLibrary
{
    public static class Help
    {
        public static void ShowHelp()
        {
            Console.WriteLine("1 - To add animal, write: add [type of animal] [name of animal]");
            Console.WriteLine("Avaible types: Lion, Tiger, Elephant, Bear, Wolf, Fox");
            Console.WriteLine("\nEvery animal can have 4 state: Sated, Hungry, Sick, Dead");
            Console.WriteLine("After animal was added, by default it has: \n\nState - Sated \nHealth: Lion - 5, Tiger - 4, Elephant - 7, Bear - 6, Wolf - 4, Fox - 3");
            Console.WriteLine("\n2 - To remove animal, if it's dead, write: remove [name of animal]");
            Console.WriteLine("3 - To feed animal, write: feed [name of animal]");
            Console.WriteLine("4 - To cure animal, write: cure [name of animal]");
            Console.WriteLine("5 - To look info about animal, write: about [name of animal]");
            Console.WriteLine("6 - To look all animals, write: all");
            Console.WriteLine("7 - To clean console, write: cls");
            Console.WriteLine("8 - To close application, write exit");
            Console.WriteLine("\nYou can enter commands in lower or upper register it's doesnt't matter.");
        }
        public static void ShowLinqHelp()
        {
            Console.WriteLine("1 - Show all animals group by type");
            Console.WriteLine("2 - Show animals by state, enter by user");
            Console.WriteLine("3 - Show all sick tigers");
            Console.WriteLine("4 - Show elephant by name");
            Console.WriteLine("5 - Show names all hungry animals");
            Console.WriteLine("6 - Show most heath animal every type");
            Console.WriteLine("7 - Show count all dead animals group by type");
            Console.WriteLine("8 - Show wolfs and bears whose health is >= 3");
            Console.WriteLine("9 - Show min and max health");
            Console.WriteLine("10 - Show average animals heath in zoo");
        }
    }
}
