using System.Linq;
using System.Text;
using Motosoft.DocumentProcessing.App.Contracts;

namespace Motosoft.DocumentProcessing.App.Services
{
    public class DocumentReader : IDocumentReader
    {
        private readonly char[] _separators;
        private readonly string _document;
        private int _index;

        public DocumentReader(string document) : this(document, new[] {' ', '.', ',', '!', '?', '-', '\'', '"'})
        {
            
        }

        public DocumentReader(string document, char[] wordSeparators)
        {
            _document = document;
            _separators = wordSeparators;
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
            return _separators.Any(separator => separator == character);
        }
    }
}
