using System;
using System.Collections.Generic;
using System.Text;
using Motosoft.DocumentProcessing.App.Contracts;

namespace Motosoft.DocumentProcessing.App.Model.SymbolTable
{
    public partial class TernarySearchTrie: ISymbolTable
    {
        private Node _root;
        
        public void Put(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                throw new ArgumentNullException();

            _root = Put(_root, word, 0);
            Count++;
        }

        public int Count { get; private set; }
        public WordCounterPair[] GetAll()
        {
            if (_root == null)
                return new WordCounterPair[0];

            var buffer = new TrieBuffer(Count);
            GetAll(_root, buffer, new StringBuilder());

            return buffer.Items;
        }

        private void GetAll(Node node, TrieBuffer buffer, StringBuilder wordBuilder)
        {
            if (buffer.Index == Count || node == null)
                return;
            
            if (node.Counter > 0)
            {
                wordBuilder.Append(node.Symbol);
                buffer.Add(wordBuilder.ToString(), node.Counter);
            }

            if (node.Left != null)
                GetAll(node.Left, buffer, new StringBuilder(wordBuilder.ToString()));
            

            if (node.Middle != null)
            {
                wordBuilder.Append(node.Symbol);
                GetAll(node.Middle, buffer, wordBuilder);
            }
            
            if (node.Right != null)
                GetAll(node.Right, buffer, new StringBuilder(wordBuilder.ToString()));
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
            if (index == word.Length - 1 || node == null)
                return node;

            if (word[index] > node.Symbol)
                return Get(node.Right, word, index);

            if (word[index] < node.Symbol)
                return Get(node.Left, word, index);

            return Get(node.Middle, word, ++index);
        }

        private Node Put(Node node, string word, int index)
        {
            if (node == null)
                node = new Node(word[index]);

            if (index < word.Length - 1)
            {
                if (word[index] > node.Symbol)
                    node.Right = Put(node.Right, word, index);
                else if (word[index] <node.Symbol)
                    node.Left = Put(node.Left, word, index);
                else
                    node.Middle = Put(node.Middle, word, ++index);
            }
            else
            {
                node.Counter += 1;
            }

            return node;
        }
    }
}