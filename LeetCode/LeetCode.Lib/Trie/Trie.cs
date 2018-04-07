using System.Linq;

namespace LeetCode.Lib.Trie
{
    public class Trie
    {
        private readonly Node rootNode;
        /** Initialize your data structure here. */
        public Trie()
        {
            rootNode = new Node();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            // Begin at the root with no elements found
            Node traverseNode = rootNode;
            int elementsFound = 0;

            // Traverse until a leaf is found or it is not possible to continue
            while (traverseNode != null && !traverseNode.IsLeaf && elementsFound < word.Length)
            {
                var currentSuffix = word.Substring(elementsFound);
                var currentPrefix = word.Substring(0, elementsFound);
                // Get the next edge to explore based on the elements not yet found in word
                Edge nextEdge = (from edge in traverseNode.Edges
                                 where currentSuffix.Contains(edge.Label)
                                 select edge).FirstOrDefault();

                // Was an edge found?
                if (nextEdge != null)
                {
                    // Set the next node to explore
                    traverseNode = nextEdge.TargetNode;

                    // Increment elements found based on the label stored at the edge
                    elementsFound += nextEdge.Label.Length;

                    traverseNode.Edges.Add(new Edge(""));
                    traverseNode.Edges.Add(new Edge(word.Substring(elementsFound)));
                }
                else
                {
                    break;
                }
            }
            traverseNode?.Edges.Add(new Edge(word.Substring(elementsFound)));
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            // Begin at the root with no elements found
            Node traverseNode = rootNode;
            int elementsFound = 0;

            // Traverse until a leaf is found or it is not possible to continue
            while (traverseNode != null && !traverseNode.IsLeaf && elementsFound < word.Length)
            {
                // Get the next edge to explore based on the elements not yet found in x
                Edge nextEdge = (from edge in traverseNode.Edges
                                 where word.Substring(elementsFound).Contains(edge.Label)
                                 select edge).FirstOrDefault();


                // Was an edge found?
                if (nextEdge != null)
                {
                    // Set the next node to explore
                    traverseNode = nextEdge.TargetNode;

                    // Increment elements found based on the label stored at the edge
                    elementsFound += nextEdge.Label.Length;
                }
                else
                {
                    // Terminate loop
                    traverseNode = null;
                }
            }

            // A match is found if we arrive at a leaf node and have used up exactly x.length elements
            return (traverseNode != null && traverseNode.IsLeaf && elementsFound == word.Length);
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        //public bool StartsWith(string prefix)
        //{

        //}
    }
}