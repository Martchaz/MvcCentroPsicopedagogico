namespace MvcCentroPsicopedagogico.Services
{
    public class KnowledgeBaseService : IKnowledgeBaseService
    {
        public Task<string?> GetAnswerAsync(string question)
        {
            // Simulación de respuestas
            if (question.Contains("horario", StringComparison.OrdinalIgnoreCase))
                return Task.FromResult<string?>("El horario de atención es de 9 a 17 hs.");

            return Task.FromResult<string?>("Lo siento, no tengo una respuesta clara para eso.");
        }
    }
}
