namespace LevvaCoins.Domain.SeedWork.SearchableRepository;
public class SearchInput
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string Search { get; set; }
    public SearchInput(string search,int pageNumber, int pageSize)
    {
        Search = search;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
