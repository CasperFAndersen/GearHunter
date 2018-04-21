using GearHunter.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHunter.DAL
{ 
    public class IndividualRepository : GenericRepository<Individual>
    {

        private DbSet<Individual> dbSet;
        public IndividualRepository(GearHunterDbContext context) : base(context)
        {
            this.dbSet = context.Set<Individual>();
        }
        public Individual GetByEmail(string email)
        {
          /*  Individual individual = new Individual();

            foreach (var item in GetAll())
            {
                if (item.Email.Equals(email))
                {
                    individual = item;
                    break;
                }
            }
            return individual; */

           return dbSet.FirstOrDefault(x => x.Email == email); 
        }

    }
}
