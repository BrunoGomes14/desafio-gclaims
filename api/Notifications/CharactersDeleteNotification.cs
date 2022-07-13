using MediatR;

namespace api.Notifications
{
    public class CharactersDeleteNotification : INotification
    {
        public int Id { get; set; }
    }
}