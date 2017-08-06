using System.Linq;

namespace Motosoft.DocumentProcessing.App.Services.Filters
{
    public class NumberFilter: FilterBase
    {
        public override bool Skip(string word)
        {
            return base.Skip(word) || (word?.All(char.IsDigit) ?? false);
        }
    }
}
