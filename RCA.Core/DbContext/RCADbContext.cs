using Microsoft.EntityFrameworkCore;
using RCA.Model;

namespace RCA.Core
{
    public class RCADbContext : DbContext
    {
        #region Override Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationHelper.ParseConfigrationValue("ConnectionStrings:MSSQL", out string connectionString);

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Country Data
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    IsActive = true,
                    Name = "Türkiye"
                }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 2,
                    IsActive = true,
                    Name = "İngiltere"
                }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 3,
                    IsActive = true,
                    Name = "İtalya"
                }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 4,
                    IsActive = true,
                    Name = "Fransa"
                }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 5,
                    IsActive = true,
                    Name = "Almanya"
                }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 6,
                    IsActive = true,
                    Name = "Hollanda"
                }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 7,
                    IsActive = true,
                    Name = "Belçika"
                }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country
                {

                    Id = 8,
                    IsActive = true,
                    Name = "Finlandiya"
                }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country
                {

                    Id = 9,
                    IsActive = true,
                    Name = "Yunanistan"
                }
            );


            modelBuilder.Entity<Country>().HasData(
                new Country
                {

                    Id = 10,
                    IsActive = true,
                    Name = "İsveç"
                }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country
                {

                    Id = 11,
                    IsActive = true,
                    Name = "İsviçre"
                }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country
                {

                    Id = 12,
                    IsActive = true,
                    Name = "Rusya"
                }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country
                {

                    Id = 13,
                    IsActive = true,
                    Name = "Bulgaristan"
                }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country
                {

                    Id = 14,
                    IsActive = true,
                    Name = "Norveç"
                }
            );
            #endregion Country Data

            base.OnModelCreating(modelBuilder);
        }
        #endregion Override Methods

        #region DBSets
        public DbSet<Country> Countries { get; set; }
        #endregion DBSets
    }
}