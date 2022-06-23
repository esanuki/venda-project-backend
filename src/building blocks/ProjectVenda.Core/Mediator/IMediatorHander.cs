using FluentValidation.Results;
using ProjectVenda.Core.DomainObjects;
using System.Threading.Tasks;

namespace ProjectVenda.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T obj) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
