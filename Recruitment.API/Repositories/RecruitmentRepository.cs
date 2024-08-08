using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Recruitment.API.Data;

namespace Recruitment.API.Repositories
{
    public class RecruitmentRepository<TEntity> : IRecruitmentRepository<TEntity> where TEntity : class
    {
        protected readonly RecruitmentDbContext context;
        public RecruitmentRepository(RecruitmentDbContext context)
        {
            this.context = context;
        }
        public IQueryable<TEntity> All => this.context.Set<TEntity>();

        public void Delete(object id)
        {
            var entity = context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public TEntity Insert(TEntity item)
        {
            context.Set<TEntity>().Add(item);
            context.SaveChanges();
            return item;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> SelectAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> SelectById(object id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}