using DomainComponent.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationComponent
{
    public interface ICommonService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task AddAsync(TEntity entity);

    }
}
