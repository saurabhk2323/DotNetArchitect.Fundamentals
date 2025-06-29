﻿namespace Core.DesignPatterns.Structural.Bridge
{
    public class Runner
    {
        public static void Execute()
        {
            var regularEmail = new RegularNotification(new SMSSender());
            var urgentSMS = new UrgentNotification(new SMSSender());
            var promotionalEmail = new PromotionalNotification(new EmailSender());

            regularEmail.Notify("saurabh@example.com", "Daily report");
            urgentSMS.Notify("+91 1234567890", "Server Down!");
            promotionalEmail.Notify("saurabh@example.com", "Clearance sale, Flat 40% off");
        }
    }
}
