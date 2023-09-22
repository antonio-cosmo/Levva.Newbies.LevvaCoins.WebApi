using LevvaCoins.Domain.Exceptions;
using LevvaCoins.Domain.SeedWork.Notification;

namespace LevvaCoins.Domain.Validation;
public partial class DomainValidation
{
    public DomainValidation IsNull(string targate, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(targate))
            AddNotification(new Notification(fieldName, $"{fieldName} should not be null"));
        return this;
    }
    public DomainValidation IsNull(object targate, string fieldName)
    {
        if (targate is null)
            throw new EntityValidationException($"{fieldName} should not be null");
        return this;
    }
}
