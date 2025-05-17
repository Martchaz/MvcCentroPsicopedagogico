using MvcCentroPsicopedagogico.Models.ChatBot;
using MvcCentroPsicopedagogico.Models;
using MvcCentroPsicopedagogico.Data;
using Microsoft.EntityFrameworkCore;
using MvcCentroPsicopedagogico.Services; // <-- clave

namespace MvcCentroPsicopedagogico.Services
{
    public class ChatBotService
    {
        private readonly MvcCentroPsicopedagogicoContext _context;
        private readonly IKnowledgeBaseService _knowledgeService;
        private readonly IAppointmentService _appointmentService;
        private readonly INaturalLanguageProcessor _nlpProcessor;

        public ChatBotService(
            MvcCentroPsicopedagogicoContext context,
            IKnowledgeBaseService knowledgeService,
            IAppointmentService appointmentService,
            INaturalLanguageProcessor nlpProcessor)
        {
            _context = context;
            _knowledgeService = knowledgeService;
            _appointmentService = appointmentService;
            _nlpProcessor = nlpProcessor;
        }

        public async Task<ChatResponse> ProcessMessageAsync(string message, UserContext userContext)
        {
            var intent = await _nlpProcessor.ExtractIntentAsync(message);

            switch (intent)
            {
                case "Turno_Consulta":
                    var opciones = await _appointmentService.GetAvailableAppointmentsAsync(userContext);
                    return new ChatResponse
                    {
                        Text = "Estas son las opciones de turnos disponibles:",
                        QuickReplies = opciones.Select(o => new QuickReply
                        {
                            Title = o.ToString(),
                            Value = o.Id.ToString()
                        }).ToList(),
                        RequiresHuman = false
                    };

                case "Ayuda":
                    var respuesta = await _knowledgeService.GetAnswerAsync(message);
                    return new ChatResponse
                    {
                        Text = respuesta ?? "No encontré una respuesta clara, ¿podés reformularlo?",
                        QuickReplies = new List<QuickReply>(),
                        RequiresHuman = respuesta == null
                    };

                default:
                    return new ChatResponse
                    {
                        Text = "No entendí tu mensaje. ¿Podés ser más específico?",
                        QuickReplies = new List<QuickReply>(),
                        RequiresHuman = true
                    };
            }
        }

        public async Task<List<ChatMessage>> GetConversationHistoryAsync(string userId)
        {
            return await _context.ChatMessages
                .Include(m => m.Conversation)
                .Where(m => m.Conversation.UserId == userId)
                .OrderBy(m => m.Timestamp)
                .ToListAsync();
        }
    }
}
