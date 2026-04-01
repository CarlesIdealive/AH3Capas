using ApplicationComponent.DTOs;
using ApplicationComponent.Mapper;
using Infrastructure.Repository.Models;

namespace MapperComponent
{
    public class NoteModelMapper : IMapper<NoteDTO, NoteModel>
    {
        public NoteModel Map(NoteDTO data)=> new()
        {
            Id = data.Id,
            ItemId = data.ItemId,
            Message = data.Message,
            Color = data.Color,
            CreatedDate = DateTime.Now
        };

    }
}
