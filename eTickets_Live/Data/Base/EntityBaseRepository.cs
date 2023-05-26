namespace eTickets_Live.Data.Base
{
    // Tüm işlemleri yapacak bölümleri içeren kısım

    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()

    {
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
