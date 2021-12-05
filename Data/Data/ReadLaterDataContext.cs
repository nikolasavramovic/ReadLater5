using Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReadLater5.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ReadLaterDataContext : IdentityDbContext

    {
        public ReadLaterDataContext(DbContextOptions<ReadLaterDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bookmark>()
                .HasOne(e => e.Category)
                .WithMany(e =>e.Bookmarks)
                .HasForeignKey(e => e.CategoryId);
                //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Bookmarks)
                .WithOne(e => e.Category)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookmark_Categories_CategoryId"); ;

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Bookmark> Bookmark { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
