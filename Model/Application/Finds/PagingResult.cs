using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Application.Finds
{
    public class PagingResult<T>
    {
        public T Items { get; }
        public int TotalCount { get; }
        public int Offset { get; }

        public PagingResult(T items, int totalCount, int offset)
        {
            Items = items;
            TotalCount = totalCount;
            Offset = offset;
        }
    }
}
