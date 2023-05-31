namespace RCA.Core
{
    public interface IBusiness<T> where T : class
    {
        IQueryable<T> Queryable();
        T GetById(long id);
    }
}