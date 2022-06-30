using FluentValidation.Results;
using MediatR;
using ProjectVenda.Core.DomainObjects;
using System.Threading.Tasks;

namespace ProjectVenda.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T obj) where T : Event
        {
            await _mediator.Publish(obj);
        }

        public async Task<bool> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}
