namespace LevvaCoins.Domain.Common
{
    public sealed class PaginationOptions
    {
        private const int MinimumPageNumber = 1;
        private const int MinimumPageSize = 1;

        private int _pageSize;
        private int _pageNumber;

        public PaginationOptions(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize < MinimumPageSize ? MinimumPageSize : pageSize;
        }

        public int PageNumber
        {
            get => _pageNumber;
            set
            {
                _pageNumber = value < MinimumPageNumber ? MinimumPageNumber : value;
            }
        }
        public int PageSize
        {
            get => _pageSize;
            set
            {
                _pageSize =value < MinimumPageSize ? MinimumPageSize : value;
            }
        }
    }
}
