namespace Core.DesignPatterns.Behavioral.Command
{
    public class LogCommand : ICommand
    {
        private readonly string _description;

        public LogCommand(string description)
        {
            _description = description;
        }

        public void Execute()
        {
            Console.WriteLine($"[Logger] {DateTime.Now}: {_description}");
        }
    }
}
