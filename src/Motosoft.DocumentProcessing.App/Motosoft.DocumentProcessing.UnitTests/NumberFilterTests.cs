using Motosoft.DocumentProcessing.App.Services.Filters;
using Xunit;

namespace Motosoft.DocumentProcessing.UnitTests
{
    public class NumberFilterTests
    {
        [Fact]
        public void given_empty_string_assume_skip_equals_true()
        {
            var filter = new NumberFilter();
            Assert.Equal(true, filter.Skip("   "));
        }

        [Fact]
        public void given_3446_assume_skip_returns_true()
        {
            var filter = new NumberFilter();
            Assert.Equal(true, filter.Skip("34567"));
        }

        [Fact]
        public void given_abc_assume_skip_returns_false()
        {
            var filter = new NumberFilter();
            Assert.Equal(false, filter.Skip("abc"));
        }

        [Fact]
        public void given_abc123_assume_skipr_returns_false()
        {
            var filter = new NumberFilter();
            Assert.Equal(false, filter.Skip("abc123"));
        }
    }
}
