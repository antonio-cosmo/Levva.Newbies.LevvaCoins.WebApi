using LevvaCoins.Domain.Exceptions;
using LevvaCoins.Domain.SeedWork.Notification;

namespace LevvaCoins.Domain.Validation;
public partial class DomainValidation
{
    public DomainValidation GuidIsNotEmpty(Guid target, string fieldName)
    {
        if (target == Guid.Empty)
            AddNotification(fieldName, "should  not be empty");
        return this;
    }
}