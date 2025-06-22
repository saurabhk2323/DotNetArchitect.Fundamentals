namespace Core.DesignPatterns.Behavioral.Observer
{
    public class OrderPlaceSubject : ISubject
    {
        private readonly List<IObserver> _observers = new();
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string eventData)
        {
            foreach (var observer in _observers)
                observer.Update(eventData);
        }
    }
}
