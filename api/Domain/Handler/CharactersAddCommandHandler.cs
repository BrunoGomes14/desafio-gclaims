using MediatR;
using api.Domain.Command;
using api.Repository;
using api.Notifications;
using api.Util;

namespace api.Domain.Handler
{
    public class CharactersAddCommandHandler : IRequestHandler<CharactersAddCommand, DefaultResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepository _repository;

        public CharactersAddCommandHandler(IMediator mediator, IRepository repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<DefaultResponse> Handle(CharactersAddCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddFav(request.Id);
            await _mediator.Publish(new CharactersAddNotification { Id = request.Id });
                
            return await Task.FromResult(new DefaultResponse("Personagem adicionado com sucesso"));            
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}