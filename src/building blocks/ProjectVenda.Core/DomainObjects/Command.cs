using FluentValidation.Results;
using MediatR;
using System;

namespace ProjectVenda.Core.DomainObjects
{
    public abstract class Command : Message, IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.UtcNow;
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
