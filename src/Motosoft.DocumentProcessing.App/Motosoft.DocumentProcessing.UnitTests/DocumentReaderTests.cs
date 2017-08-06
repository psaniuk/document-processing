using Motosoft.DocumentProcessing.App;
using Motosoft.DocumentProcessing.App.Services;
using Xunit;

namespace Motosoft.DocumentProcessing.UnitTests
{
    public class DocumentReaderTests
    {
        [Fact]
        public void given_document_with_whitespaces_assume_ReadNextWord_returns_empty_string()
        {
            var reader = new DocumentReader("     ");
            Assert.Equal(string.Empty, reader.ReadNextWord());
        }

        [Fact]
        public void given_document_with_two_words_and_whitespaces_assume_ReadNextWords_equals_first_word()
        {
            var reader = new DocumentReader("           abc,    apple    ");
            Assert.Equal("abc", reader.ReadNextWord());
        }

        [Fact]
        public void given_document_without_any_word_assume_RedNextWorkd_equals_empty()
        {
            var reader = new DocumentReader("   ,  !!!! ,,,   ..  ?");
            Assert.Equal(string.Empty, reader.ReadNextWord());
        }

        [Fact]
        public void give_document_with_5_words_execute_ReadNextWord_3_times_assume_result_equals_3d_word_from_doc()
        {
            var reader = new DocumentReader("Abc, ght. TTTk    fgh   lkj  ");
            reader.ReadNextWord();
            reader.ReadNextWord();

            Assert.Equal("TTTk", reader.ReadNextWord());
        }


        [Fact]
        public void given_test_sentence_read_to_the_end_assume_number_of_words_equals_25()
        {
            var document = "The big brown fox number 4 jumped over the lazy dog. THE BIG BROWN FOX JUMPED OVER THE LAZY DOG. The Big Brown Fox 123.";
            var reader = new DocumentReader(document);

            int counter = 0;
            while (!string.IsNullOrWhiteSpace(reader.ReadNextWord()))
                counter++;

            Assert.Equal(25, counter);
        }
    }
}
