using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Behavioral.Observer
{
    public class Runner
    {
        public static void Execute()
        {
            var subject = new OrderPlaceSubject();
            var inventoryObserver = new InventoryObserver();
            var billingObserver = new BillingObserver();
            var notificationObserver = new NotificationObserver();

            subject.Attach(inventoryObserver);
            subject.Attach(billingObserver);
            subject.Attach(notificationObserver);

            subject.Notify("Order#123");

            subject.Detach(billingObserver);
            subject.Detach(inventoryObserver);

            subject.Notify("Order#123 Placed");
        }
    }
}
