namespace MvcCentroPsicopedagogico.Services
{
    public interface INaturalLanguageProcessor
    {
        Task<string> ExtractIntentAsync(string message);
    }
}
