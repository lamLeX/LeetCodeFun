using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Lib.Trie
{
    public class Node
    {
        public List<Edge> Edges { get; } = new List<Edge>();
        public bool IsLeaf => !Edges.Any();
    }
}