using MediatR;
using api.Util;

namespace api.Domain.Command
{
    public class CharactersDeleteFavCommand : IRequest<DefaultResponse>
    {
        public int Id { get; set; }
    }
}