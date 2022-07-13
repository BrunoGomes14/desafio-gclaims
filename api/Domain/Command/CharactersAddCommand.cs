using MediatR;
using api.Util;

namespace api.Domain.Command
{
    public class CharactersAddCommand : IRequest<DefaultResponse>
    {  
        public int Id { get; set; }
    }
}