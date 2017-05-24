using ZooClassLibrary;
using UIClassLibrary;

namespace ZooConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface userInterface = new UserInterface();
            userInterface.OpenZoo(new Zoo());
        }
    }
}
