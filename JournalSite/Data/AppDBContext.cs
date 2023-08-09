using JournalSite.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JournalSite.Data
{
    public class AppDBContext : IdentityDbContext<IdentityUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options) { }
        public DbSet<PostItem> PostItems { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Article> Arcticles { get; set; }
        public DbSet<Entities.File> Files { get; set; }
        public DbSet<Archive_year> Archive_Years { get; set; }
        public DbSet<Archive_number> Archive_Numbers { get; set; }
        public DbSet<Archive_articles> Archive_Articles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "ab8ab668-45de-473f-8b83-03fab356d8bc",
                Name = "admin",
                NormalizedName= "ADMIN"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "04aabfe0-ed61-46d2-8f8c-ffa5955d2007",
                Name = "moderator",
                NormalizedName = "MODERATOR"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "85a10752-0d93-46b1-9083-cd6a6dbaf7ec",
                Name = "user",
                NormalizedName = "USER"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "d2feb6b1-216b-4e2e-a65c-59a63dd08607",
                UserName= "admin",
                NormalizedUserName = "ADMIN",
                Email = "m@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "adf18b32-aa40-457d-ace6-65892cbda144",
                UserName = "moderator",
                NormalizedUserName = "MODERATOR",
                Email = "moderator@email.com",
                NormalizedEmail = "MODERATOR@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "moderpassword"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "ab8ab668-45de-473f-8b83-03fab356d8bc",
                UserId = "d2feb6b1-216b-4e2e-a65c-59a63dd08607"
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "04aabfe0-ed61-46d2-8f8c-ffa5955d2007",
                UserId = "adf18b32-aa40-457d-ace6-65892cbda144"
            });
        }
    }
}
