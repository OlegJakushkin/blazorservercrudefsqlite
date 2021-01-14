using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace blazorservercrudefsqlite.Data
{

    public class ProductDbContext : DbContext
    {
        #region Contructor

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        #endregion

        #region Overidden methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Org>().HasData(GetProducts());
            modelBuilder.Entity<Relation>().HasKey(rt => new { rt.UserId, rt.OrgId });
            modelBuilder.Entity<Relation>()
                .HasOne(rt => rt.User)
                .WithMany(r => r.Relations)
                .HasForeignKey(rt => rt.OrgId).IsRequired();
            modelBuilder.Entity<Relation>()
                .HasOne(rt => rt.Org)
                .WithMany(r => r.Relations)
                .HasForeignKey(rt => rt.UserId).IsRequired();
            modelBuilder.Entity<User>().HasData(GetUsers());

            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region Public properties

        public DbSet<Org> Orgs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Relation> Relations { get; set; }
        #endregion


        #region Private methods

        private List<Org> GetProducts()
        {
            return new List<Org>
            {
                new Org {Id = 1001, Name = "MS"},
                new Org {Id = 1002, Name = "SPBU"},
                new Org {Id = 1003, Name = "APPL"},
                new Org {Id = 1004, Name = "GOOGL"}
            };
        }

        private List<User> GetUsers()
        {
            var ul = new List<User>
            {
                new User {Id = 1001, Name = "Vasia"},
                new User {Id = 1002, Name = "Dasha"},
                new User {Id = 1003, Name = "Petia"},
                new User {Id = 1004, Name = "Masha"}
            };


            //ul.First().Orgs.Add(new Org { Id = 1005, Name = "AMD" });

            return ul;
        }

        #endregion
    }
}