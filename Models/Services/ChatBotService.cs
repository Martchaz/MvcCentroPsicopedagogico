using System.Text.Json;
using MvcCentroPsicopedagogico.Models;

namespace MvcCentroPsicopedagogico.Services
{
    public class ChatBotService
    {
        private readonly string _jsonPath;
        private ChatBotData _chatData;

        public ChatBotService(IWebHostEnvironment env)
        {
            _jsonPath = Path.Combine(env.WebRootPath, "data", "intents.json");
            LoadIntents();
        }

        private void LoadIntents()
        {
            var json = File.ReadAllText(_jsonPath);
            _chatData = JsonSerializer.Deserialize<ChatBotData>(json);
        }

        public string GetResponse(string message)
        {
            var intent = _chatData.intents.FirstOrDefault(i =>
                i.patterns.Any(p => message.ToLower().Contains(p.ToLower()))
            );

            if (intent != null && intent.responses.Any())
            {
                var rnd = new Random();
                return intent.responses[rnd.Next(intent.responses.Count)];
            }

            return "Lo siento, no entendí tu pregunta.";
        }
    }
}
