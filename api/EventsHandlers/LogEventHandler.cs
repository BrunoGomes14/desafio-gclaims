using api.Notifications;
using MediatR;

namespace api.EventsHandlers
{
    public class LogEventHandler : INotificationHandler<CharactersAddNotification>,
                                   INotificationHandler<CharactersDeleteNotification>,
                                   INotificationHandler<CharactersDeleteFavNotification>
    {
        public Task Handle(CharactersAddNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ADICIONADO FAV: {notification.Id}");
            });
        }

        public Task Handle(CharactersDeleteNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"REMOVIDO: {notification.Id}");
            });
        }

        public Task Handle(CharactersDeleteFavNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"REMOVIDO FAV: {notification.Id}");
            });
        }
    }
}