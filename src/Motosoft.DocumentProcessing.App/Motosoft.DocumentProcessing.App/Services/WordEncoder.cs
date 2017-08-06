using System.Text;
using Motosoft.DocumentProcessing.App.Contracts;

namespace Motosoft.DocumentProcessing.App.Services
{
    public class WordEncoder : IWordEncoder
    {
        public string Encode(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            var output = new StringBuilder();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                bool capitalize = (i + 1- input.Length) %2 != 0;
                output.Append(capitalize ? char.ToUpperInvariant(input[i]) : input[i]);
            }

            return output.ToString();
        }
    }
}
