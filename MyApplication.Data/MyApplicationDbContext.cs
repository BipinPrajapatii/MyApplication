using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApplication.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Data
{
    public class MyApplicationDbContext : IdentityDbContext<User>
    {
        public MyApplicationDbContext(DbContextOptions <MyApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<User>(entity => entity.Property(m => m.Id).HasMaxLength(100));
            builder.Entity<User>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(100));
            builder.Entity<User>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(100));

            builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(100));
            builder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(100));

            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(100));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(100));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(100));
            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(100));

            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(100));

            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(100));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(100));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(100));

            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(100));
            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(100));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(100));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(100));

            //Create Companies
            CreateCompany(builder);
        }
        public DbSet<ExceptionLogger> ExceptionLoggers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        private void CreateCompany(ModelBuilder builder)
        {
            builder.Entity<Company>().HasData(new Company()
            {
                //Surat Company
                Address1 = "Address Line 1",
                Address2 = "Address Line 2",
                City = "Surat",
                Country = "India",
                Email = "noemail@noemail.com",
                EndDate = DateTime.UtcNow.AddDays(365),
                FirstName = "Surat",
                LastName = "Contact",
                MaxUser = 5,
                Id = 1,
                Name = "Surat Company",
                PhoneNo = "1234567890",
                StartDate = DateTime.UtcNow,
                State = "Gujarat",
                ZipCode = "395000"
            },
            new Company()
            {
                //Mumbai Company
                Address1 = "Address Line 1",
                Address2 = "Address Line 2",
                City = "Mumbai",
                Country = "India",
                Email = "nocontact@nocontact.com",
                EndDate = DateTime.UtcNow.AddDays(120),
                FirstName = "Mumbai",
                LastName = "Contact",
                MaxUser = 3,
                Id = 2,
                Name = "Mumbai Company",
                PhoneNo = "1234567890",
                StartDate = DateTime.UtcNow,
                State = "Maharastra",
                ZipCode = "411000"
            });
        }
    }
}
