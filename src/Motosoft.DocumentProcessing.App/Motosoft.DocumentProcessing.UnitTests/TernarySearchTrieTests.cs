using System.Collections.Generic;
using System.Linq;
using Motosoft.DocumentProcessing.App.Model;
using Motosoft.DocumentProcessing.App.Model.SymbolTable;
using Xunit;

namespace Motosoft.DocumentProcessing.UnitTests
{
    public class TernarySearchTrieTests
    {
        [Fact]
        public void count_oragne_assume_0()
        {
            var trie = new TernarySearchTrie();
            Assert.Equal(0, trie.CountWord("orange"));
        }

        [Fact]
        public void put_orange_assume_count_equals_1()
        {
            var trie = new TernarySearchTrie();
            trie.Put("orange");
            Assert.Equal(1, trie.CountWord("orange"));
        }

        [Fact]
        public void put_orange_twice_assume_count_equals_2()
        {
            var trie = new TernarySearchTrie();
            trie.Put("orange");
            trie.Put("orange");
            
            Assert.Equal(2, trie.CountWord("orange"));
        }

        [Fact]
        public void put_orange_apple_peach_assume_count_peach_equals_1()
        {
            var trie = new TernarySearchTrie();
            trie.Put("orange");
            trie.Put("apple");
            trie.Put("peach");

            Assert.Equal(1, trie.CountWord("peach"));
        }

        [Fact]
        public void put_orange_apple_peach_twice_assume_count_peach_equals_2()
        {
            var trie = new TernarySearchTrie();
            trie.Put("orange");
            trie.Put("apple");
            trie.Put("peach");

            Assert.Equal(1, trie.CountWord("peach"));
        }

        [Fact]
        public void put_orange_apple_peach_assume_count_equals_3()
        {
            var trie = new TernarySearchTrie();
            trie.Put("orange");
            trie.Put("apple");
            trie.Put("peach");

            Assert.Equal(3, trie.Count);
        }

        [Fact]
        public void put_orange_apple_peach_get_all_asume_second_items_equals_orange()
        {
            var trie = new TernarySearchTrie();
            trie.Put("orange");
            trie.Put("apple");
            trie.Put("peach");

            IEnumerable<WordCounterPair> pairs = trie.GetAll();
            Assert.Equal("orange", pairs.ToArray()[1].Word);
        }


        [Fact]
        public void put_orange_apple_peach_get_all_asume_all_counte_equals_3()
        {
            var trie = new TernarySearchTrie();
            trie.Put("orange");
            trie.Put("apple");
            trie.Put("peach");

            IEnumerable<WordCounterPair> pairs = trie.GetAll();
            Assert.Equal(3, pairs.Count(item => item != null));
        }

        [Fact]
        public void put_apple_abc_aak_get_all_assume_first_item_equals_aak()
        {
            var trie = new TernarySearchTrie();
            trie.Put("orange");
            trie.Put("apple");
            trie.Put("peach");
            trie.Put("abc");
            trie.Put("aak");

            WordCounterPair[] pairs = trie.GetAll().ToArray();
            Assert.Equal("aak", pairs[0].Word);
        }
    }
}
