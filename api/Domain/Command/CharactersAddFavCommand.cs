using MediatR;
using api.Util;

namespace api.Domain.Command
{
    public class CharactersAddFavCommand : IRequest<DefaultResponse>
    {  
        public int Id { get; set; }
    }
}