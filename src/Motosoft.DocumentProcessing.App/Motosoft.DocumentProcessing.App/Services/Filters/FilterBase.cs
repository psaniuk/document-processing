using Motosoft.DocumentProcessing.App.Contracts;

namespace Motosoft.DocumentProcessing.App.Services.Filters
{
    public class FilterBase: IWordFilter
    {
        public virtual bool Skip(string word)
        {
            return string.IsNullOrWhiteSpace(word);
        }
    }
}
