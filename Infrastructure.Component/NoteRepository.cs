using DomainComponent.Entities;
using DomainComponent.Interfaces;
using Infrastructure.Repository.Mappers;
using Infrastructure.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class NoteRepository : ICommonRepository<Note>
    {

        private readonly ItemsDbContext context;

        public NoteRepository(ItemsDbContext context)
        {
            this.context = context;
        }



        public async Task AddAsync(Note item)
        {
            var modelNote = item.MapToModel();
            context.NotesModel.Add(modelNote);
            await context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            List<NoteModel> noteModels = await context.NotesModel.ToListAsync();
            return noteModels.MapToDomain();
        }


    }
}
