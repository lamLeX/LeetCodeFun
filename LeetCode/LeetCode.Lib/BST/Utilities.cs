using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Lib.BST
{
    public static class Utilities
    {
        public static TreeNode ConstructTreeNode(int?[] input)
        {
            if (!input.FirstOrDefault().HasValue) return null;
            var inputQueue = new Queue<int?>(input);
            var currentQueue = new Queue<TreeNode>(inputQueue.Count);
            var root = new TreeNode(inputQueue.Dequeue().Value);
            currentQueue.Enqueue(root);

            while (currentQueue.Any())
            {
                var node = currentQueue.Dequeue();

                if (inputQueue.TryDequeue(out var left) && left.HasValue)
                {
                    var newNode = new TreeNode(left.Value);
                    node.Left = newNode;
                    currentQueue.Enqueue(newNode);
                }

                if (inputQueue.TryDequeue(out var right) && right.HasValue)
                {
                    var newNode = new TreeNode(right.Value);
                    node.Right = newNode;
                    currentQueue.Enqueue(newNode);
                }
            }
            return root;
        }

        public static IEnumerable<int?> ToArray(this TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var node = queue.Dequeue();
                if (node == null)
                {
                    yield return null;
                }
                else
                {
                    yield return node.Val;
                    queue.Enqueue(node.Left);
                    queue.Enqueue(node.Right);
                }
            }
        }

        public static bool IsLeaf(this TreeNode node)
        {
            if (node == null) return false;
            return node.Left == null && node.Right == null;
        }
    }
}