namespace MvcCentroPsicopedagogico.Models
{
    public class ChatConversation
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public virtual ICollection<ChatMessage> Messages { get; set; }
    }
}