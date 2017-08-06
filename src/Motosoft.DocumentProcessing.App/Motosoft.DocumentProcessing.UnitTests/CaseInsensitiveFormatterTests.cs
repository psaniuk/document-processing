using Motosoft.DocumentProcessing.App.Services.Formatters;
using Xunit;

namespace Motosoft.DocumentProcessing.UnitTests
{
    public class CaseInsensitiveFormatterTests
    {
        [Fact]
        public void given_ABC_assume_ApplyFormat_returns_abc()
        {
            var formatter = new CaseInsensitiveFormatter();
            Assert.Equal("abc", formatter.ApplyFormat("ABC"));
        }

        [Fact]
        public void given_aBc_assume_ApplyFormat_returns_abc()
        {
            var formatter = new CaseInsensitiveFormatter();
            Assert.Equal("abc", formatter.ApplyFormat("aBc"));
        }
    }
}
