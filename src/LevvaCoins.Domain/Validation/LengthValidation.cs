using LevvaCoins.Domain.Exceptions;

namespace LevvaCoins.Domain.Validation;
public partial class DomainValidation
{
    public DomainValidation HasLessThan(int target, double minLength, string fieldName)
    {
        if (target < minLength)
            throw new EntityValidationException($"{fieldName} should be greater than {minLength}");
        return this;

    }
    public DomainValidation HasLessThan(decimal target, decimal minLength, string fieldName)
    {
        if (target < minLength)
            throw new EntityValidationException($"{fieldName} should be greater than {minLength}");
        return this;

    }
    public DomainValidation HasLessThan(string? target, double minLength, string fieldName)
    {
        if (target is null) return this;

        if (target.Length < minLength)
            throw new EntityValidationException($"{fieldName} should be greater than {minLength}");
        return this;

    }

    public DomainValidation HasGreaterThan(int target, double maxLength, string fieldName)
    {
        if (target > maxLength)
            throw new EntityValidationException($"{fieldName} should be less than {maxLength}");
        return this;

    }
    public DomainValidation HasGreaterThan(decimal target, decimal maxLength,  string fieldName)
    {
        if (target > maxLength)
            throw new EntityValidationException($"{fieldName} should be less than {maxLength}");
        return this;
    }

    public DomainValidation HasGreaterThan(string? target, decimal maxLength, string fieldName)
    {
        if (target is null) return this;

        if (target.Length > maxLength)
            throw new EntityValidationException($"{fieldName} should be less than {maxLength}");
        return this;
    }
}