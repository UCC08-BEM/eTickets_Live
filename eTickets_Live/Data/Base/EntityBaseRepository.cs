using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace eTickets_Live.Data.Base
{
    // Tüm işlemleri yapacak bölümleri içeren kısım. Tüm modellere hizmet edeceği için Generic(T) tipinde tanımlanmıştır ve IEntityBaseRepository interfaceinden implement edilmiştir.

    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()

    {
        // İlk olarak yapılması gereken AppDbContext ayarlamalarını buraya yapmam gerekiyor

        private readonly AppDbContext _context;

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context; 
        }


        public void Add(T entity)
        {
            // T olarak tüm model yapıları parametre olarak gelecek. Dolayısıyla hangi modelden geldiğimi metot çalışma öncesi Set etmem gerekiyor.
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // delete işlemi için id parametresinin hangi modelden geldiğini öğrenmem gerekiyor.
            // 
            var entity=_context.Set<T>().FirstOrDefault(x => x.Id == id); // nereden geldiği öğreniyorum ve silinecek kayıdı da öğrenmiş oluyorum.

            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State=EntityState.Deleted; // Silinecek olarak işaretledi.
            _context.SaveChanges(); // sildi.
        }

        public IEnumerable<T> GetAll() => _context.Set<T>().ToList(); // ilgili modelin(movie modeli hariç diğer tüm modeller için uygun) Tüm kayıtları getirir.
        

        // movie modeli için uygun.
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id); // İlgili seçilen kayıdı getirir.
        }

        public void Update(int id, T entity) // ilgili modeldeki ilgili kayıdı günceller
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);

            entityEntry.State = EntityState.Modified; // Güncellendi olarak işaretledi.
            
            _context.SaveChanges(); // güncelledi.
        }
    }
}
