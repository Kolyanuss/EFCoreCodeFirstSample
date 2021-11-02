using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreCodeFirstSample.Models
{
    public class MyAppContext : DbContext
    {
        public DbSet<Films> Films { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Description> Description { get; set; }

        public MyAppContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<ListFilms>().HasKey(u => new { u.IdFilms, u.IdUser });

            modelBuilder.Entity<ListFilms>()
                .HasOne(p => p.Films)
            .WithMany(t => t.ListFilms)
            .HasForeignKey(p => p.IdFilms);

            modelBuilder.Entity<ListFilms>()
                .HasOne(p => p.User)
            .WithMany(t => t.ListFilms)
            .HasForeignKey(p => p.IdUser);



            modelBuilder.Entity<Films>().HasData(
            new Films
            {
                Id = 1,
                NameFilm = "Hellowin",
                ReleaseData = new DateTime(1979, 04, 25),
                Country = "USA",
                DescriptionId = 0,

            },
            new Films
            {
                Id = 2,
                NameFilm = "Strangers",
                ReleaseData = new DateTime(2021, 10, 26),
                Country = "Ukraine",
                DescriptionId = 1,
            });
        }
    }
}
