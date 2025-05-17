using MvcCentroPsicopedagogico.Models;

public class ChatMessage
{
    public int Id { get; set; }
    public string Content { get; set; }
    public bool IsFromUser { get; set; }
    public DateTime Timestamp { get; set; }
    public int ConversationId { get; set; }
    public virtual ChatConversation Conversation { get; set; }
}
