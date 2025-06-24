using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Behavioral.Command
{
    public class Runner
    {
        public static void Execute()
        {

            var queue = new CommandQueueInvoker();

            // Simulate Order + Notification + Logging
            string orderId = "ORD124";
            string product = "Apple Watch Ultra";
            string customer = "saurabh@example.com";

            queue.AddCommand(new OrderCommand(orderId, product));
            queue.AddCommand(new NotifyCommand(customer, $"Your order {orderId} has been placed."));
            queue.AddCommand(new LogCommand($"Order {orderId} placed for {product} by {customer}."));

            // Later: background job calls
            queue.ProcessAll();
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    public class OrderCommand : ICommand
    {
        private readonly string _orderId;
        private readonly string _productId;

        public OrderCommand(string orderId, string productId)
        {
            _orderId = orderId;
            _productId = productId;
        }

        public void Execute()
        {
            Console.WriteLine($"[OrderService] Order {_orderId} placed for {_productId}.");
        }
    }

    public class NotifyCommand : ICommand
    {
        private readonly string _recipient;
        private readonly string _message;

        public NotifyCommand(string recipient, string message)
        {
            _recipient = recipient;
            _message = message;
        }

        public void Execute()
        {
            Console.WriteLine($"[NotificationService] Sent to {_recipient}: {_message}");
        }
    }

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
