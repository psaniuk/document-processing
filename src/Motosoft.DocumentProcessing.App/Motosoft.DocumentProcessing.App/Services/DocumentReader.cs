using System.Text;
using Motosoft.DocumentProcessing.App.Contracts;

namespace Motosoft.DocumentProcessing.App.Services
{
    public class DocumentReader : IDocumentReader
    {
        private string _document = string.Empty;
        private int _index;

        public void Load(string documentSource)
        {
            _document = documentSource;
            _index = 0;
        }

        public string ReadNextWord()
        {
            if (_document == null || _index > _document.Length - 1)
                return string.Empty;

            while (_index <= _document.Length - 1 && IsSeparator(_document[_index]))
                _index++;
             
            var wordBuilder = new StringBuilder();
            while (_index <= _document.Length - 1 && !IsSeparator(_document[_index]))
                wordBuilder.Append(_document[_index++]);

            return wordBuilder.ToString().Trim();
        }

        private bool IsSeparator(char character)
        {
            return char.IsWhiteSpace(character) || char.IsPunctuation(character);
        }
    }
}
