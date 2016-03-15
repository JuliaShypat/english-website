using EnglishWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EnglishWebsite.DAL
{
    public class EnglishWebsiteContext : DbContext 
    {
        public EnglishWebsiteContext() : base("EnglishWebsiteContext") 
        { 
        }

        public DbSet<SingleWord> SingleWords { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}