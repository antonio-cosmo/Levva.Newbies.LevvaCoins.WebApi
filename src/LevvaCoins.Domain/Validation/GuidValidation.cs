using LevvaCoins.Domain.Exceptions;

namespace LevvaCoins.Domain.Validation;
public static partial class DomainValidation
{
    public static void GuidIsNotEmpty(Guid target, string fieldName)
    {
        if (target == Guid.Empty)
            throw new EntityValidationException($"{fieldName} should  not be empty");
    }
}