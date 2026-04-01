using DomainComponent.Entities;
using Infrastructure.Repository.Models;

namespace Infrastructure.Repository.Mappers
{
    public static class NoteMapper
    {
        public static Note MapToDomain(this NoteModel model)
        {
            if (model == null) return null;

            return new Note(
                id : model.Id,
                message : model.Message,
                itemid : model.ItemId
            );
        }


        public static NoteModel MapToModel(this Note domain)
        {
            if (domain == null) return null;

            return new NoteModel
            {
                Id = domain.Id,
                Message = domain.Message,
                ItemId = domain.ItemId,
            };
        }

        public static IEnumerable<Note> MapToDomain(this IEnumerable<NoteModel> models)
        {
            if (models == null) return null;

            var result = new List<Note>();
            foreach (var model in models)
            {
                result.Add(MapToDomain(model));
            }
            return result;
        }

        public static IEnumerable<NoteModel> MapToModel(this IEnumerable<Note> domains)
        {
            if (domains == null) return null;

            var result = new List<NoteModel>();
            foreach (var domain in domains)
            {
                result.Add(MapToModel(domain));
            }
            return result;
        }

    }


}
