using FluentValidation.Results;
using ProjectVenda.Core.DomainObjects;

namespace ProjectVenda.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T obj) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
