using MediatR;

namespace api.Notifications
{
    public class CharactersAddNotification : INotification
    {  
        public int Id { get; set; }
    }
}