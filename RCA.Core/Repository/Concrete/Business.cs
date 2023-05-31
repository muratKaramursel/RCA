namespace RCA.Core
{
    public class Business<T> : IBusiness<T> where T : class
    {
        protected readonly IRepository<T> _repository;

        public Business(IRepository<T> repository)
        {
            _repository = repository;
        }

        public T GetById(long id)
        {
            T data = _repository.GetById(id);

            return data ?? throw new Exception("Entity not found");
        }
        public IQueryable<T> Queryable()
        {
            return _repository.Queryable();
        }
    }
}