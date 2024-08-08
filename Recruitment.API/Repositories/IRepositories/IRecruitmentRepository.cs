using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.API.Repositories
{
    public interface IRecruitmentRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All { get; }
        Task<IEnumerable<TEntity>> SelectAll();
        Task<TEntity> SelectById(object id);
        TEntity Insert(TEntity item);
        void Update(TEntity item);
        void Delete(object id);
        void SaveChanges();
    }
}