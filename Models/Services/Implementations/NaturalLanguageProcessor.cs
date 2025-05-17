namespace MvcCentroPsicopedagogico.Services
{
    public class NaturalLanguageProcessor : INaturalLanguageProcessor
    {
        public Task<string> ExtractIntentAsync(string message)
        {
            if (message.Contains("turno", StringComparison.OrdinalIgnoreCase))
                return Task.FromResult("Turno_Consulta");

            if (message.Contains("ayuda", StringComparison.OrdinalIgnoreCase))
                return Task.FromResult("Ayuda");

            return Task.FromResult("Otro");
        }
    }
}
