using System;
using System.Linq;
using Motosoft.DocumentProcessing.App.Contracts;
using Motosoft.DocumentProcessing.App.Exceptions;
using Motosoft.DocumentProcessing.App.Model;

namespace Motosoft.DocumentProcessing.App.Services
{
    public class CountIt
    {
        private readonly IDocumentReader _documentReader;
        private readonly IDocumentDictionary _documentDictionary;
        private readonly IView _userView;
        private readonly IWordFilter[] _filters;
        private readonly IWordFormatter[] _formatters;

        public CountIt(IDocumentReader documentReader, IDocumentDictionary documentDictionary, IView userView, IWordFilter[] filters, IWordFormatter[] formatters)
        {
            _documentReader = documentReader;
            _documentDictionary = documentDictionary;
            _userView = userView;
            _filters = filters;
            _formatters = formatters;
        }

        public void Count(string documentSource)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(documentSource))
                {
                    _userView.Show("Document is empty.");
                    return;
                }

                _documentReader.Load(documentSource);

                int wordsCounter = 0;
                string word = _documentReader.ReadNextWord();
                while (!string.IsNullOrWhiteSpace(word))
                {
                    if (_filters.Any(filter => filter.Skip(word)))
                    {
                        word = _documentReader.ReadNextWord();
                        continue;
                    }

                    foreach (IWordFormatter formatter in _formatters)
                        word = formatter.ApplyFormat(word);
                
                    _documentDictionary.Put(word);

                    wordsCounter++;
                    word = _documentReader.ReadNextWord();
                }

                WordCounterPair[] pairs = _documentDictionary.GetAll();

                _userView.Show($"Number of words: {wordsCounter}");
                foreach (WordCounterPair pair in pairs)
                    _userView.Show(pair);
            }
            catch (Exception exception)
            {
                throw new DocumentCountException("Unexpected error", exception);
            }     
            
        }
    }
}
