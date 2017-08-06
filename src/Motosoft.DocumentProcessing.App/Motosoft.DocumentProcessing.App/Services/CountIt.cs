using System.Linq;
using Motosoft.DocumentProcessing.App.Contracts;
using Motosoft.DocumentProcessing.App.Model;

namespace Motosoft.DocumentProcessing.App.Services
{
    public class CountIt
    {
        private readonly IDocumentReader _documentReader;
        private readonly ISymbolTable _symbolTable;
        private readonly IView _userView;
        private readonly IWordFilter[] _filters;
        private readonly IWordFormatter[] _formatters;

        public CountIt(IDocumentReader documentReader, ISymbolTable symbolTable, IView userView, IWordFilter[] filters, IWordFormatter[] formatters)
        {
            _documentReader = documentReader;
            _symbolTable = symbolTable;
            _userView = userView;
            _filters = filters;
            _formatters = formatters;
        }

        public void ProcessDocument(string documentSource)
        {
            if (string.IsNullOrWhiteSpace(documentSource))
            {
                _userView.Show("Document is empty.");
                return;
            }

            _documentReader.Load(documentSource);
            string word = _documentReader.ReadNextWord();
            while (string.IsNullOrWhiteSpace(word))
            {
                if (string.IsNullOrWhiteSpace(word))
                    continue;

                if (_filters.Any(filter => filter.Skip(word)))
                    continue;

                foreach (IWordFormatter formatter in _formatters)
                    word = formatter.ApplyFormat(word);
                
                _symbolTable.Put(word);                     
                word = _documentReader.ReadNextWord();
            }

            WordCounterPair[] pairs = _symbolTable.GetAll();

            _userView.Show($"Number of words: {_symbolTable.Count}");
            foreach (WordCounterPair pair in pairs)
                _userView.Show(pair);          
            
                      
        }
    }
}
