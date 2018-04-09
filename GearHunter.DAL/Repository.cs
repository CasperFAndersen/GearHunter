using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHunter.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private GearHunterDbContext context;
        private DbSet<TEntity> dbSet;
        public Repository(GearHunterDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public List<TEntity> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        //Async Methods

        public async Task<List<TEntity>> FindAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

    }
}
