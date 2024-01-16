using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities;


namespace Repositories
{
    public class Context : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Commentaire> Comments { get; set; }

        public Context(DbContextOptions<Context> options) : base (options){ }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoEF201;Integrated Security= True");
            //optionsBuilder.LogTo(Console.WriteLine);
            base.OnConfiguring(optionsBuilder);
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var c1 = new Article() { Id = 1, Theme = "testTheme", Auteur = "testAuteur" ,DateCreation=DateTime.Now, DateModification=DateTime.Now,Contenu="testcontenu"  };
            modelBuilder.Entity<Article>().HasData(c1);
            base.OnModelCreating(modelBuilder);
        }
    }
}
