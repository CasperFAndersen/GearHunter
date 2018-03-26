using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHunter.DAL
{
    interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetById(int id);

        Task<List<TEntity>> FindAllAsync();
        Task<TEntity> FindByIdAsync(int id);
    }
}
