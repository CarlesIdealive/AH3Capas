using ApplicationComponent.Mapper;
using DomainComponent.Entities;
using DomainComponent.Interfaces;

namespace ApplicationComponent
{
    //Trabajamos con Mappers
    public class NoteMapperService<TDTO, TModel> : IAddService<TDTO, TModel>
    {
        private readonly IAddRepository<TModel> _repository;
        private readonly IMapper<TDTO, Note> _mapperEntity;
        private readonly IMapper<TDTO, TModel> _mapperModel;


        public NoteMapperService(IAddRepository<TModel> repository,
            IMapper<TDTO, Note> mapperEntity,
            IMapper<TDTO, TModel> mapperModel)
        {
            _repository = repository;
            _mapperEntity = mapperEntity;
            _mapperModel = mapperModel;
        }



        public async Task AddAsync(TDTO dto)
        {
            var note = _mapperEntity.Map(dto);
            //Se aplican reglas al modelo de entidad
            // Por ejemplo 
            if (note.Message.Length > 3)
                throw new Exception("El mensaje XXXX");


            var noteModel = _mapperModel.Map(dto);

            await _repository.AddAsync(noteModel);

        }
    
    
    }
}
