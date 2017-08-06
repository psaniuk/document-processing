using Motosoft.DocumentProcessing.App.Contracts;

namespace Motosoft.DocumentProcessing.App.Services.Formatters
{
    public class CaseInsensitiveFormatter: IWordFormatter
    {
        public string ApplyFormat(string word)
        {
            return word?.ToLowerInvariant() ?? string.Empty;
        }
    }
}