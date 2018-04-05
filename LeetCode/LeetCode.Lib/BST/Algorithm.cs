namespace LeetCode.Lib.BST
{
    public static class Algorithm
    {
        public static int SumOfLeftLeaves(this TreeNode root)
        {
            if (root == null) return 0;

            if (root.Left.IsLeaf())
            {
                return root.Left.Val + SumOfLeftLeaves(root.Right);
            }
            else
            {
                return SumOfLeftLeaves(root.Left) + SumOfLeftLeaves(root.Right);
            }
        }

        public static TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;
            if (root.Val == key)
            {
                return ConstructNewNode(root);
            }

            if (root.Val > key)
            {
                root.Left = DeleteNode(root.Left, key);
            }
            //if (root.val < key)
            else
            {
                root.Right = DeleteNode(root.Right, key);
            }

            return root;

            TreeNode ConstructNewNode(TreeNode nodeToDelete)
            {
                if (nodeToDelete.Left == null || nodeToDelete.Right == null)
                    return nodeToDelete.Left ?? nodeToDelete.Right;

                nodeToDelete.Right.Left = nodeToDelete.Left;
                return nodeToDelete.Right;

            }
        }

    }
}