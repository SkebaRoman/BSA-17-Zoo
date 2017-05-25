namespace ZooClassLibrary.Pattern.Command
{
    public class Invoker
    {
        private UserCommand command;

        public void SetCommand(UserCommand command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }
}
