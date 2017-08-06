namespace Motosoft.DocumentProcessing.App.Contracts
{
    public interface IWordFilter
    {
        bool Skip(string word);
    }
}
