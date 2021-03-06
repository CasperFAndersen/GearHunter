﻿using GearHunter.Core;
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
            return dbSet.Find(email);
        }
    }
}
