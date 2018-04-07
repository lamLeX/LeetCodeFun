using System.Reflection.PortableExecutable;

namespace LeetCode.Lib.Trie
{
    public class Edge
    {
        public string Label;
        public Node TargetNode;

        public Edge(string label)
        {
            Label = label;
            TargetNode = new Node();
        }
    }
}