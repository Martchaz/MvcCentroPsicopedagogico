namespace MvcCentroPsicopedagogico.Models
{
    public class Intent
    {
        public string tag { get; set; }
        public List<string> patterns { get; set; }
        public List<string> responses { get; set; }
    }

    public class ChatBotData
    {
        public List<Intent> intents { get; set; }
    }
}