namespace RCA.Core
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Queryable();
        T GetById(long id);
    }
}