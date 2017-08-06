namespace Motosoft.DocumentProcessing.App.Model.Dictionary
{
    public partial class TernarySearchTrie
    {
        private class Node
        {
            public Node(char symbol)
            {
                Symbol = symbol;
            }

            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Middle { get; set; }
            public char Symbol { get; }
            public int Counter { get; set; }
        }
    }
}