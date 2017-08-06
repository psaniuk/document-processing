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
        private readonly IWordEncoder _wordEncoder;
        private readonly IWordFilter[] _filters;
        private readonly IWordFormatter[] _formatters;

        public CountIt(IDocumentReader documentReader, IDocumentDictionary documentDictionary, IView userView, IWordEncoder wordEncoder,
            IWordFilter[] filters, IWordFormatter[] formatters)
        {
            _documentReader = documentReader;
            _documentDictionary = documentDictionary;
            _userView = userView;
            _wordEncoder = wordEncoder;
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

                int wordsCounter = AddToDictionary(documentSource);
                WordCounterPair[] pairs = _documentDictionary.GetAll();
                ShowTotal(wordsCounter);
                ShowWordsWithCounters(pairs);
                ShowEncoded(pairs);
            }
            catch (Exception exception)
            {
                throw new DocumentCountException("Unexpected error", exception);
            }     
            
        }

        private void ShowEncoded(WordCounterPair[] pairs)
        {
            _userView.Show(Environment.NewLine);
            foreach (WordCounterPair wordCounterPair in pairs)
                _userView.Show(_wordEncoder.Encode(wordCounterPair.Word));
        }

        private void ShowTotal(int wordsCounter)
        {
            _userView.Show($"Number of words: {wordsCounter}");
        }

        private void ShowWordsWithCounters(WordCounterPair[] pairs)
        {
            foreach (WordCounterPair pair in pairs)
                _userView.Show(pair);
        }

        private int AddToDictionary(string documentSource)
        {
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

            return wordsCounter;
        }
    }
}
