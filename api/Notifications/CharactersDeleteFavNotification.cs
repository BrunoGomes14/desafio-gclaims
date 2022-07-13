using MediatR;

namespace api.Notifications
{
    public class CharactersDeleteFavNotification : INotification
    {
        public int Id { get; set; }
    }
}