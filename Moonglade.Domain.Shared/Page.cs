namespace Moonglade.Domain.Shared
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
