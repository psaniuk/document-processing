namespace Motosoft.DocumentProcessing.App.Contracts
{
    public interface IDocumentReader
    {
        string ReadNextWord();
        void Load(string documentSource);
    }
}