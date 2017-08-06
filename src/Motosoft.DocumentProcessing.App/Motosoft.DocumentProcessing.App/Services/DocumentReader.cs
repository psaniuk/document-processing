using System.Linq;
using System.Text;
using Motosoft.DocumentProcessing.App.Contracts;

namespace Motosoft.DocumentProcessing.App.Services
{
    public class DocumentReader : IDocumentReader
    {
        private readonly char[] _separators;
        private string _document;
        private int _index;

        public DocumentReader() : this(new[] {' ', '.', ',', '!', '?', '-', '\'', '"'})
        {
            
        }

        public DocumentReader(char[] wordSeparators)
        {
            _document = string.Empty;
            _separators = wordSeparators;
        }
        
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
            return _separators.Any(separator => separator == character);
        }
    }
}
