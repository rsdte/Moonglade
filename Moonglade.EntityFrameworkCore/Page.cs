using Moonglade.Domain;

namespace Moonglade.EntityFrameworkCore
{
    public class Page<TEntity> : IPage<TEntity>
    {
        public int Count { get; set; }
        public int Index { get; set; }
        public IList<TEntity> Data { get; set; }
        public Page()
        {
            Data = new List<TEntity>();
        }
    }
}
