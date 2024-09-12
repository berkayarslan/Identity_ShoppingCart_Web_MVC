using DomainLayer.Entities.Abstract;
using DomainLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories.Concrete
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        protected ProductDbContext _context;
        protected DbSet<TEntity> _dbSet;

        public BaseRepository()
        {
            _context = new ProductDbContext();
            _dbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            entity.AddedDate = DateTime.Now;
            entity.RecordStatus = DomainLayer.Enums.RecordStatus.Added;

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await FindAsync(id);
            if (entity != null)
            {
                entity.DeleteDate = DateTime.Now;
                entity.RecordStatus = DomainLayer.Enums.RecordStatus.Deleted;

                _dbSet.Update(entity);

                //_dbSet.Entry(entity).State = EntityState.Modified; // Entry e bak !!!!
                await _context.SaveChangesAsync();
            }

        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.Where(x => x.RecordStatus != DomainLayer.Enums.RecordStatus.Deleted).ToListAsync();
        }

        public IQueryable<TEntity> GetAllInclude()
        {
            return _dbSet.Where(x => x.RecordStatus != DomainLayer.Enums.RecordStatus.Deleted);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.RecordStatus = DomainLayer.Enums.RecordStatus.Updated;

            _dbSet.Update(entity);

            //_dbSet.Entry(entity).State = EntityState.Modified; // Entry e bak !!!!
            await _context.SaveChangesAsync();
        }
    }
}
