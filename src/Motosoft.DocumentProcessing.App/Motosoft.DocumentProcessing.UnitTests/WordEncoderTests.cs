using Motosoft.DocumentProcessing.App.Services;
using Xunit;

namespace Motosoft.DocumentProcessing.UnitTests
{
    public class WordEncoderTests
    {
        [Fact]
        public void encode_big_assume_result_is_gIb()
        {
            var wordEncoder = new WordEncoder();
            Assert.Equal("gIb", wordEncoder.Encode("big"));           
        }

        [Fact]
        public void encode_number_assume_result_is_rEbMuN()
        {
            var wordEncoder = new WordEncoder();
            Assert.Equal("rEbMuN", wordEncoder.Encode("number"));
        }

        [Fact]
        public void encode_empty_string_assume_result_is_empty()
        {
            var wordEncoder = new WordEncoder();
            Assert.Equal(string.Empty,  wordEncoder.Encode("    "));
        }

        [Fact]
        public void encode_jumped_assume_result_equals_dEpMuJ()
        {
            var wordEncoder = new WordEncoder();
            Assert.Equal("dEpMuJ", wordEncoder.Encode("jumped"));
        }
    }
}
