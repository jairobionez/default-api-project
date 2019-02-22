using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using DefaultProject.Domain.Entities;
using DefaultProject.Infra.Data.Mapping;

namespace DefaultProject.Infra.Data.Context
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(): base("DefaultConnection")
        { }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Configurations.Add(new UserMapp());

            base.OnModelCreating(modelBuilder);
        }
    }
}