using Motosoft.DocumentProcessing.App.Contracts;

namespace Motosoft.DocumentProcessing.App.Services
{
    public class DocumentReaderFactory : IDocumentReaderFactory
    {
        public IDocumentReader CreateSimpleReader(string document)
        {
            return new DocumentReader(document);
        }
    }
}
