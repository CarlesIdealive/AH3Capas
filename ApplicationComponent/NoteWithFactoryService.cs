using ApplicationComponent.DTOs;
using ApplicationComponent.Mapper;
using DomainComponent.Entities;
using DomainComponent.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationComponent
{
    public class NoteWithFactoryService<TDTO, TExtraData> : IAddService<TDTO, TExtraData>
    {
        private readonly IRepositoryFactory<IAddRepository<Note>, TExtraData> _repositoryFactory;
        private readonly IMapper<TDTO, Note> _mapperEntity;
        private readonly IMapper<TDTO, TExtraData> _mapperExtraData;

        public NoteWithFactoryService(IMapper<TDTO, TExtraData> mapperExtraData, 
            IRepositoryFactory<IAddRepository<Note>, TExtraData> repositoryFactory, 
            IMapper<TDTO, Note> mapperEntity)
        {
            _mapperEntity = mapperEntity;
            _mapperExtraData = mapperExtraData;
            _repositoryFactory = repositoryFactory;

        }

        public async Task AddAsync(TDTO dto)
        {
            var note = _mapperEntity.Map(dto);
            TExtraData extraData = _mapperExtraData.Map(dto);
            var repository = _repositoryFactory.CreateRepository(extraData);

            await repository.AddAsync(note);
        }
    }
}
