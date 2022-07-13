using MediatR;
using api.Util;

namespace api.Domain.Command
{
    public class CharactersDeleteCommand : IRequest<DefaultResponse>
    {
        public int Id { get; set; }
    }
}