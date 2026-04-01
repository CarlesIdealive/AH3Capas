using ApplicationComponent.DTOs;
using ApplicationComponent.Mapper;
using DomainComponent.Entities;

namespace MapperComponent
{
    public class NoteEntityMapper : IMapper<NoteDTO, Note>
    {
        public Note Map(NoteDTO data)=> new Note(data.Id, data.ItemId, data.Message);
        

    }
}
