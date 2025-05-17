namespace MvcCentroPsicopedagogico.Services
{
    public interface IKnowledgeBaseService
    {
        Task<string?> GetAnswerAsync(string question);
    }
}
