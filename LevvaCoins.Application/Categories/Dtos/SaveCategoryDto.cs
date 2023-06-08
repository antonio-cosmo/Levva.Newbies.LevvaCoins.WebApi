namespace LevvaCoins.Application.Categories.Dtos
{
    public class SaveCategoryDto
    {
        private string _description = string.Empty;
        public string Description {
            get => _description;
            set
            {
                _description = value.ToLower();
            }
        }

    }
}
