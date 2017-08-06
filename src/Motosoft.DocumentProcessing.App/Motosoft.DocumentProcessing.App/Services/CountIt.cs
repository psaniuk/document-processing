using Motosoft.DocumentProcessing.App.Contracts;

namespace Motosoft.DocumentProcessing.App.Services
{
    public class CountIt
    {
        private readonly IDocumentReaderFactory _documentReaderFactory;
        private readonly ISymbolTable _symbolTable;
        private readonly IView _userView;

        public CountIt(IDocumentReaderFactory documentReaderFactory, ISymbolTable symbolTable, IView userView)
        {
            _documentReaderFactory = documentReaderFactory;
            _symbolTable = symbolTable;
            _userView = userView;
        }

        public void ProcessDocument(string documentSource)
        {
            if (string.IsNullOrWhiteSpace(documentSource))
            {
                _userView.Show(new [] {"Document is empty"});
                return;
            }

            IDocumentReader docReader = _documentReaderFactory.CreateSimpleReader(documentSource);
            string word = docReader.ReadNextWord();
            while (string.IsNullOrWhiteSpace(word))
            {
                _symbolTable.Put(word);                     
                word = docReader.ReadNextWord();
            }


        }
    }
}
