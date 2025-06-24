namespace Core.DesignPatterns.Behavioral.Command
{
    public class CommandQueueInvoker
    {
        private readonly Queue<ICommand> _commands = new();

        public void AddCommand(ICommand command) => _commands.Enqueue(command);

        public void ProcessAll()
        {
            while (_commands.Count > 0)
            {
                var cmd = _commands.Dequeue();
                cmd.Execute();
            }
        }
    }
}
