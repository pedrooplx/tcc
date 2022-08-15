using System.Collections;
using System.Collections.Generic;

namespace TCC.API.Extensions.Pagination
{
    public class Page
    {
        public IList Data { get; set; }
        public PageInfo Pagination { get; set; }
        
        public Page(IList data, PageInfo pageInfo)
        {
            Data = data;
            Pagination = pageInfo;
        }
    }

    public class Page<T>
    {
        public IList<T> Data { get; set; }
        public PageInfo Pagination { get; set; }
        
        public Page(IList<T> data, PageInfo pageInfo)
        {
            Data = data;
            Pagination = pageInfo;
        }

        public static implicit operator Page(Page<T> pagination)
        {
            return new Page(
                (IList)pagination.Data,
                pagination.Pagination);
        }
    }
}
