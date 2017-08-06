using Motosoft.DocumentProcessing.App.Contracts;

namespace Motosoft.DocumentProcessing.App.Services.Formatters
{
    public class CaseInsensitiveFormatter: IWordFormatter
    {
        public string Apply(string word)
        {
            return word?.ToLowerInvariant() ?? string.Empty;
        }
    }
}