namespace MvcCentroPsicopedagogico.Models
{
    public class ChatResponse
    {
        public required string Text { get; set; }
        public required List<QuickReply> QuickReplies { get; set; }
        public required bool RequiresHuman { get; set; }
    }

    public class QuickReply
    {
    public required string Title { get; set; }
    public required string Value { get; set; }
    }
        
    

    public class UserContext
    {
    public required string UserId { get; set; }
    }
}
