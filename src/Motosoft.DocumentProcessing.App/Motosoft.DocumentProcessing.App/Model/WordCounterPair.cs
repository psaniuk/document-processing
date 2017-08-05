namespace Motosoft.DocumentProcessing.App.Model
{
    public class WordCounterPair
    {
        public WordCounterPair(string word, int counter)
        {
            Word = word;
            Counter = counter;
        }

        public string Word { get; }
        public int Counter { get; }
    }
}
