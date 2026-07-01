using Microsoft.EntityFrameworkCore.Query;
using System.Reflection;

namespace IIMSASTHA.Models
{
    public class PaginatedList<T>
    {

        public List<T> Items { get; set; }

        public int TotalItems { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {

            PageIndex = pageIndex;

            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            Items = items;
            
        }

        public bool HasPreviousPage => (PageIndex > 1);

        public bool HasNextPage => (PageIndex < TotalPages);

        public int FirstItemIndex => (PageIndex - 1) * PageSize + 1;

        public int LastItemIndex => Math.Min(PageIndex * PageSize, TotalItems);

        
    }
}
