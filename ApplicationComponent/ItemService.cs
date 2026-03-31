using Domain.Interfaces;
using DomainComponent.Entities;

namespace ApplicationComponent
{
    public class ItemService : IService
    {
        private readonly IRepository _repository;
        public ItemService(IRepository repository)
        {
            _repository = repository;
        }



        public async Task AddAsync(string title)
        {
            Item newItem = new Item(0,title,false);
            await _repository.AddAsync(newItem);
        }

        public async Task<IEnumerable<Item>> GetAsync()
        {
           return await _repository.GetAllAsync();
        }
    }
}
