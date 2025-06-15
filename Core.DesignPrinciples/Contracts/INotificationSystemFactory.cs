using Core.DesignPrinciples.Common;

namespace Core.DesignPrinciples.Contracts
{
    public interface INotificationSystemFactory
    {
        INotificationSystem GetImplementation(NotificationType type);
    }
}
