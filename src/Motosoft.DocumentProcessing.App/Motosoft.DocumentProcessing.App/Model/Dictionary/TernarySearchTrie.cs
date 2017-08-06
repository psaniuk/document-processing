using System;
using System.Text;
using Motosoft.DocumentProcessing.App.Contracts;

namespace Motosoft.DocumentProcessing.App.Model.Dictionary
{
    public partial class TernarySearchTrie : IDocumentDictionary
    {
        private Node _root;

        public void Put(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                throw new ArgumentNullException();

            _root = Put(_root, word, 0);
        }

        public int DistinctCount { get; private set; }

        public WordCounterPair[] GetAll()
        {
            if (_root == null)
                return new WordCounterPair[0];

            var buffer = new TrieBuffer(DistinctCount);
            GetAll(_root, buffer, new StringBuilder());

            return buffer.Items;
        }

        public int CountWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                throw new ArgumentNullException();

            if (_root == null)
                return 0;

            Node node = Get(_root, word, 0);
            return node?.Counter ?? 0;
        }

        private Node Get(Node node, string word, int index)
        {
            if ((index == word.Length - 1) || (node == null))
                return node;

            if (word[index] > node.Symbol)
                return Get(node.Right, word, index);

            if (word[index] < node.Symbol)
                return Get(node.Left, word, index);

            return Get(node.Middle, word, ++index);
        }

        private void GetAll(Node node, TrieBuffer buffer, StringBuilder wordBuilder)
        {
            if ((buffer.Index == DistinctCount) || (node == null))
                return;

            if (node.Left != null)
            {
                if (node == _root)
                    wordBuilder.Clear();
            
                GetAll(node.Left, buffer, new StringBuilder(wordBuilder.ToString()));
            }


            if (node.Middle != null)
            {
                wordBuilder.Append(node.Symbol);
                GetAll(node.Middle, buffer, wordBuilder);

               /* if (wordBuilder.Length > 0)
                    wordBuilder.Remove(wordBuilder.Length - 1, 1);*/
            }

            if (node.Right != null)
            {
                if (node == _root)
                    wordBuilder.Clear();
                else
                {
                    if (wordBuilder.Length > 0)
                        wordBuilder.Remove(wordBuilder.Length - 1, 1);
                }

                GetAll(node.Right, buffer, new StringBuilder(wordBuilder.ToString()));
            }

            if (node.Counter > 0)
            {
                wordBuilder.Append(node.Symbol);
                buffer.Add(wordBuilder.ToString(), node.Counter);
            }

            if (wordBuilder.Length > 0)
                wordBuilder.Remove(wordBuilder.Length - 1, 1);
        }

        private Node Put(Node node, string word, int index)
        {
            if (node == null)
                node = new Node(word[index]);

            if (index < word.Length - 1)
            {
                if (word[index] > node.Symbol)
                    node.Right = Put(node.Right, word, index);
                else if (word[index] < node.Symbol)
                    node.Left = Put(node.Left, word, index);
                else
                    node.Middle = Put(node.Middle, word, ++index);
            }
            else
            {
                if (node.Counter == 0)
                    DistinctCount++;

                node.Counter += 1;
            }

            return node;
        }
    }
}