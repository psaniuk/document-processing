namespace Motosoft.DocumentProcessing.App.Model.Dictionary
{
    public partial class TernarySearchTrie
    {
        private class TrieBuffer
        {
            public TrieBuffer(int count)
            {
                Items = new WordCounterPair[count];
            }

            public int Index { get; private set; }

            public WordCounterPair[] Items { get; }

            public void Add(string word, int counter)
            {
                Items[Index] = new WordCounterPair(word, counter);
                Index++;
            }
        }
    }
}