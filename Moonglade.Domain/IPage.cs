namespace Moonglade.Domain
{
    public interface IPage<TEntity>
    {
        public int Count { get;set;}
        public int Index { get;set;}
        public int Size { get; set; }
        public IList<TEntity> Data { get; set; }
    }
}
