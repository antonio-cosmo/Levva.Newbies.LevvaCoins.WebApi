using LevvaCoins.Domain.Exceptions;

namespace LevvaCoins.Domain.Validation;
public static partial class DomainValidation
{
    public static void IsNull(string targate, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(targate))
            throw new EntityValidationException($"{fieldName} should not be null");
    }
    public static void IsNull(object targate, string fieldName)
    {
        if (targate is null)
            throw new EntityValidationException($"{fieldName} should not be null");
    }
}
