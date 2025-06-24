🧠 Definition
Separate abstraction from its implementation so they can vary independently.

Sometimes your class hierarchy starts looking like this:

Notification
    EmailNotification
        UrgentEmail
    SMSNotification
        UrgentSMS

👎 This explodes into N × M combinations (e.g., 5 types × 5 channels = 25 classes).
You want to separate:
    - The type of notification (abstraction)
    - From the method/channel to send it (implementation)
That’s exactly what Bridge pattern does.

🎯 2. Intent of Bridge Pattern
"Decouple abstraction from implementation so that both can vary independently."

This allows:
    - Adding new types of notifications → no change in sender logic
    - Adding new sender types → no change in notification types

🛠️ 3. Core Structure


Abstraction             Implementation
-------------           ----------------------
Notification            IMessageSender
     |                        |
UrgentNotification      EmailSender / SMSSender

🧠 How Bridge Helped
Without Bridge:

You’d write a class for every combination

Code gets tightly coupled and unmaintainable

With Bridge:

You can add new Notification types (ScheduledNotification, PromotionNotification) ✅

You can add new channels (WhatsAppSender, PushSender) ✅

No explosion of subclasses 🔥

✅ Interview Answer Sample
“Bridge allowed me to keep notification logic and sending mechanisms separate. 
I could support urgent/normal notifications and email/SMS senders independently. 
This prevented class explosion and let me extend the system without code duplication. 
It aligns with the SOLID principle of separation of concerns.”

✅ Summary: When Urgency Is Behavior, Not Just Metadata
“Urgent notifications differ not just in channel but in urgency semantics, formatting, logging, retries, and escalation paths. 
Treating it as a separate subclass lets me encapsulate that behavior cleanly — and Bridge lets me decouple the behavior from how the message is delivered.”