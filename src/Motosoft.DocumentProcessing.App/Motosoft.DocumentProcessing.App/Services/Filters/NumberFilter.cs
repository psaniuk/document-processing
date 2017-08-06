using System.Linq;
using Motosoft.DocumentProcessing.App.Contracts;

namespace Motosoft.DocumentProcessing.App.Services.Filters
{
    public class NumberFilter: IWordFilter
    {
        public bool Skip(string word)
        {
            return word?.All(char.IsDigit) ?? false;
        }
    }
}
