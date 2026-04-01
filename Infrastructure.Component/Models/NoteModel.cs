using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Color { get; set; }

        public ItemModel Item { get; set; }
    }
}
