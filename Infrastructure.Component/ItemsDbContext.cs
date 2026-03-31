using Infrastructure.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ItemsDbContext : DbContext
    {
        public DbSet<ItemModel> ItemsModel { get; set; }


        public ItemsDbContext(DbContextOptions<ItemsDbContext> options) 
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemModel>().ToTable("Item");
            base.OnModelCreating(modelBuilder);
        }






    }





}
