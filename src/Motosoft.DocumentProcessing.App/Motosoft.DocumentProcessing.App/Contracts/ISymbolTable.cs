using Motosoft.DocumentProcessing.App.Model;

namespace Motosoft.DocumentProcessing.App.Contracts
{
    public interface ISymbolTable
    {
        int Count { get; }
        WordCounterPair[] GetAll();
        void Put(string word);
    }
}