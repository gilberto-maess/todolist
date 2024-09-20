using FluentValidation.Results;

namespace Domain.Exceptions;

public class DomainException : Exception
{
    public DomainException(string? message) : base(message)
    {
    }

    public DomainException(ValidationResult validationResult)
        : base(string.Join(",", validationResult.Errors))
    {

    }
}