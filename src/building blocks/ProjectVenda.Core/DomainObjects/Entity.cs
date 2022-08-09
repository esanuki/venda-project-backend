using FluentValidation.Results;
using System;

namespace ProjectVenda.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();    
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
