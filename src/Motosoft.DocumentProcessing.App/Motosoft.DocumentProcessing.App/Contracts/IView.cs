using Motosoft.DocumentProcessing.App.Model;

namespace Motosoft.DocumentProcessing.App.Contracts
{
    public interface IView
    {
        void Show(WordCounterPair pair);
        void Show(string str);
    }
}