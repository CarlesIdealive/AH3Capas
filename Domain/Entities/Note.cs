namespace DomainComponent.Entities
{
    public class Note
    {

        public int Id { get; set; }
        public int ItemId { get; private set; }
        public string Message { get; set; }

        public Note(int id, int itemid, string message)
        {
            UpdateMessage(message);
            Id = id;
            ItemId = itemid;
        }


        public void UpdateMessage(string newMessage)
        {
            if (string.IsNullOrWhiteSpace(newMessage))
            {
                throw new ArgumentException("El mensaje no puede estar vacío.");
            }
            if (newMessage.Length > 100)
            {
                throw new ArgumentException("El mensaje no puede superar los 100 caracteres");
            }
            Message = newMessage;


        }



    }
}
