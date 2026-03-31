using DomainComponent.Entities;

namespace Domain.Interfaces;

public interface IRepository
{

    Task<IEnumerable<Item>> GetAllAsync();
    Task AddAsync(Item item);


}
