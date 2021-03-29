using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje classlarını bağlamak.
    public class RentCarContext:DbContext
    {
        //Veritabanı ile ilişkilerdirme
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database = MyReCapProject1; Trusted_Connection=true");
            //Başına @ koyunca \ normal olarak algılar. Eğer koymasaydık altını çizerdi
            //Veya \\ bu şekilde 2 tane koyabiliriz.
            //base.OnConfiguring(optionsBuilder);
        }
        //Tablo ile ilişkilendirmme (Eşleştirme)
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        
        public DbSet<User>  Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }

    }
}
