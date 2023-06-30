using LevvaCoins.Domain.Shared.Validations;
using LevvaCoins.Domain.Shared.ValueObjects;

namespace LevvaCoins.Domain.ValueObjects
{
    public class Description : ValueObject
    {
        private const int MIN_DESCRIPTION_LENGTH = 3;
        private string _text = null!;
        public string Text
        {
            get => _text;
            private set
            {
                _text = value.ToLower();
            }
        }

        public Description(string text)
        {
            Text = text;
            AddNotifications(
                    new ValidationRule().Requires()
                        .HasGreaterThan(Text, MIN_DESCRIPTION_LENGTH, nameof(Text), $"should have more than {MIN_DESCRIPTION_LENGTH} characters")
                        .IsNotNull(Text, nameof(Text), "should not be null")
                );
        }
    }
}
