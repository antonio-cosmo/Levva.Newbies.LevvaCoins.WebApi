using LevvaCoins.Domain.SeedWork;
using LevvaCoins.Domain.Validation;

namespace LevvaCoins.Domain.ValueObjects
{
    public class Description : ValueObject
    {
        private const int MIN_DESCRIPTION_LENGTH = 3;
        public string Text { get; private set; }

        public Description(string text)
        {
            Text = text;
            Validate();
        }
        private void Validate()
        {
            DomainValidation.HasLessThan(Text, MIN_DESCRIPTION_LENGTH, nameof(Text));
            DomainValidation.IsNull(Text, nameof(Text));
        }
    }
}
