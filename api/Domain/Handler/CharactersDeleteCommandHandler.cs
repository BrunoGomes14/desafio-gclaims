using MediatR;
using api.Domain.Command;
using api.Repository;
using api.Notifications;
using api.Util;

namespace api.Domain.Handler
{
    public class CharactersDeleteCommandHandler : IRequestHandler<CharactersDeleteCommand, DefaultResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepository _repository;

        public CharactersDeleteCommandHandler(IMediator mediator, IRepository repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<DefaultResponse> Handle(CharactersDeleteCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);
            await _mediator.Publish(new CharactersDeleteNotification { Id = request.Id });

            return await Task.FromResult(new DefaultResponse("Personagem removido com sucesso"));
        }
    }
}