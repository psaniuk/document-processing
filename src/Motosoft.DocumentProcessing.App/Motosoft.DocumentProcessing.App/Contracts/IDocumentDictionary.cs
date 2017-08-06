using Motosoft.DocumentProcessing.App.Model;

namespace Motosoft.DocumentProcessing.App.Contracts
{
    public interface IDocumentDictionary
    {
        int DistinctCount { get; }
        WordCounterPair[] GetAll();
        void Put(string word);
    }
}