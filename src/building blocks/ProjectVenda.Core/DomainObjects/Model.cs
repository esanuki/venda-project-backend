using FluentValidation.Results;

namespace ProjectVenda.Core.DomainObjects
{
    public abstract class Model
    {
        public Model()
        {
            ValidationResult = new ValidationResult();
        }

        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
