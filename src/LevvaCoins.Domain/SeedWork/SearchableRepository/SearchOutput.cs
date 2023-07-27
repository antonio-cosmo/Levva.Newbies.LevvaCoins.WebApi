namespace LevvaCoins.Domain.SeedWork.SearchableRepository;
public class SearchOutput<TEntity>
    where TEntity : Entity
{
    private const int FIRST_PAGE = 1;
    public IEnumerable<TEntity> Items { get; }
    public int PageNumber { get; }
    public int PageSize { get; }
    public int FirstPage { get; }
    public int LastPage { get; }
    public int TotalPages { get; }
    public int TotalElements { get; }
    public bool HasPreviousPage { get; }
    public bool HasNextPage { get; }

    public SearchOutput(IEnumerable<TEntity> items, int pageNumber, int pageSize, int totalElements)
    {
        Items = items;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalElements = totalElements;
        TotalPages = CalculateTotalPages(totalElements, pageSize);
        FirstPage = FIRST_PAGE;
        LastPage = TotalPages;
        HasPreviousPage = PageNumber > FIRST_PAGE;
        HasNextPage = PageNumber < TotalPages;
    }

    private static int CalculateTotalPages(int totalElements, int pageSize)
    {
        return (int)Math.Ceiling(totalElements / (double)pageSize);
    }
}
