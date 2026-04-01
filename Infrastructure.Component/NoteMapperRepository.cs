using DomainComponent.Interfaces;
using Infrastructure.Repository.Models;

namespace Infrastructure.Repository
{
    public class NoteMapperRepository : IAddRepository<NoteModel>
    {
        private readonly ItemsDbContext context;
        public NoteMapperRepository(ItemsDbContext context)
        {
            this.context = context;
        }



        public async Task AddAsync(NoteModel item)
        {
            await context.NotesModel.AddAsync(item);
            await context.SaveChangesAsync();
        }
    }
}
