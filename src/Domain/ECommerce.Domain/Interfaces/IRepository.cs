using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Domain.Interfaces
{
    public interface IRepository<T>
    {

        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        IEnumerable<T> ListAll();

        Task<IEnumerable<T>> ListAllAsync();

        IEnumerable<T> List(ISpecification<T> spec);

        Task<IEnumerable<T>> ListAsync(ISpecification<T> spec);

        T Add(T entity);

        Task<T> AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        int Count(); 

         Task<int> CountAsync(); 

        int Count(ISpecification<T> spec);   
        
        Task<int> CountAsync(ISpecification<T> spec);    
    }
}