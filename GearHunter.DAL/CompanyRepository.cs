using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GearHunter.Core;

namespace GearHunter.DAL
{
    public class CompanyRepository : GenericRepository<Company>
    {
        private DbSet<Company> dbSet;

        public CompanyRepository(GearHunterDbContext context) : base(context)
        {
            this.dbSet = context.Set<Company>();
        }
        public Company GetByEmail(string email)
        {
            return dbSet.Find(email);
        }


    }
}
