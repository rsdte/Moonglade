using Moonglade.Domain;

namespace Moonglade.EntityFrameworkCore
{
    public class Page<TEntity> : IPage<TEntity>
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 当前页数据。
        /// </summary>
        public IList<TEntity> Data { get; set; }
        public Page()
        {
            Data = new List<TEntity>();
        }
    }
}
