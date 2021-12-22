using System;
using System.Collections.Generic;
using System.Linq;

namespace XCore.Entities.Extensions
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }
        public PagedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageIndex,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
            AddRange(items);
        }
        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
