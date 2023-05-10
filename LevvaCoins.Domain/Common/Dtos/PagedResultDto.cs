using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Domain.Common.Dtos
{
    public class PagedResultDto<TEntity>
    {
        public IEnumerable<TEntity> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int FirstPage { get; set; }
        public int LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalElements { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public PagedResultDto(
          ICollection<TEntity> items,
          int pageNumber,
          int pageSize,
          int totalElements
        )
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalElements = totalElements;
            TotalPages = (int)Math.Ceiling(totalElements / (double)pageSize);
            FirstPage = 1;
            LastPage = TotalPages;
            HasPreviousPage = PageNumber > 1;
            HasNextPage = PageNumber < TotalPages;

        }
    }
}
