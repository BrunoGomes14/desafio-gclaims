using MediatR;
using api.Domain.Command;
using api.Repository;
using api.Notifications;
using api.Util;

namespace api.Domain.Handler
{
    public class CharacterDeleteFavCommandHandler : IRequestHandler<CharactersDeleteFavCommand, DefaultResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepository _repository;

        public CharacterDeleteFavCommandHandler(IMediator mediator, IRepository repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<DefaultResponse> Handle(CharactersDeleteFavCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteFav(request.Id);
            await _mediator.Publish(new CharactersDeleteFavNotification { Id = request.Id });
                
            return await Task.FromResult(new DefaultResponse("Personagem removido dos favoritos com sucesso."));            
        }
    }
}