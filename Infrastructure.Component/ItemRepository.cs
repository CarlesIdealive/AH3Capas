using Domain.Interfaces;
using DomainComponent.Entities;
using Infrastructure.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ItemRepository : IRepository
    {
        private readonly ItemsDbContext context;

        public ItemRepository(ItemsDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Item item)
        {
            var model = new ItemModel
            {
                Id = item.Id,
                Title = item.Title,
                IsCompleted = item.IsCompleted,
                CreatedDate = DateTime.Now,
            };
            context.ItemsModel.Add(model);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await context.ItemsModel
                .Select(e => new Item(e.Id, e.Title, e.IsCompleted))
                .ToListAsync();
        }
    }
}
