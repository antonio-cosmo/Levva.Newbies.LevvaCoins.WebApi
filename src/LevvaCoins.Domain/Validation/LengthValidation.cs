using LevvaCoins.Domain.Exceptions;

namespace LevvaCoins.Domain.Validation;
public static partial class DomainValidation
{
    public static void HasLessThan(int target, double minLength, string fieldName)
    {
        if (target < minLength)
            throw new EntityValidationException($"{fieldName} should be greater than {minLength}");
    }
    public static void HasLessThan(decimal target, decimal minLength, string fieldName)
    {
        if (target < minLength)
            throw new EntityValidationException($"{fieldName} should be greater than {minLength}");
    }
    public static void HasLessThan(string? target, double minLength, string fieldName)
    {
        if (target is null) return;

        if (target.Length < minLength)
            throw new EntityValidationException($"{fieldName} should be greater than {minLength}");
    }

    public static void HasGreaterThan(int target, double maxLength, string fieldName)
    {
        if (target > maxLength)
            throw new EntityValidationException($"{fieldName} should be less than {maxLength}");
    }
    public static void HasGreaterThan(decimal target, decimal maxLength,  string fieldName)
    {
        if (target > maxLength)
            throw new EntityValidationException($"{fieldName} should be less than {maxLength}");
    }

    public static void HasGreaterThan(string? target, decimal maxLength, string fieldName)
    {
        if (target is null) return;

        if (target.Length > maxLength)
            throw new EntityValidationException($"{fieldName} should be less than {maxLength}");
    }
}