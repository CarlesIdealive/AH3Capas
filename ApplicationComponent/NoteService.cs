using DomainComponent.Entities;
using DomainComponent.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationComponent
{
    public class NoteService : ICommonService<Note>
    {

        private readonly ICommonRepository<Note> _repository;
        public NoteService(ICommonRepository<Note> repository)
        {
            _repository = repository;
        }


        public async Task AddAsync(Note entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task<IEnumerable<Note>> GetAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
