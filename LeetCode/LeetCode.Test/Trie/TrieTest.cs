using Xunit;

namespace LeetCode.Test.Trie
{
    public class TrieTest
    {
        [Fact]
        public void InsertTest()
        {
            var trie = new Lib.Trie.Trie();

            trie.Insert("test");

            trie.Insert("tester");
            trie.Insert("team");
            trie.Insert("water");

        }
    }
}