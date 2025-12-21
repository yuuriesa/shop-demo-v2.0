using ShopDemo.Utils;

namespace ShopDemo.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> GetAll(PaginationFilter paginationFilter);
    }
}