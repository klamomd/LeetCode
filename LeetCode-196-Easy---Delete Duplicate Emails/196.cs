/*
	Definition for a binary tree node.
	public class TreeNode {
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
			this.val = val;
			this.left = left;
			this.right = right;
		}
	}
*/

/* // First approach. Unperformant for both CPU and memory.
public class Solution {
	public int SumOfLeftLeaves(TreeNode root) {
		HashSet<TreeNode> leftNodes = new();
		HashSet<TreeNode> leafNodes = new();
		
		DFS(root, ref leftNodes, ref leafNodes);
		
		// Return sum of all nodes that are both left nodes and leaf nodes.
		return leftNodes
			.Where(leafNodes.Contains)
			.Sum(n => n.val);
	}
	
	// Given a root node, iterates through all nodes in the tree. Left nodes and leaf nodes are added to the provided sets.
	private void DFS(TreeNode root, ref HashSet<TreeNode> leftNodes, ref HashSet<TreeNode> leafNodes)
	{
		// Empty tree.
		if (root == null)
		{
			return;
		}
		
		// Leaf node.
		if (root.left == null && root.right == null)
		{
			leafNodes.Add(root);
			return;
		}
		
		// Add left child to set of left nodes, but only if it exists.
		if (root.left != null)
		{
			leftNodes.Add(root.left);
		}
		
		// Recurse down left side.
		DFS(root.left, ref leftNodes, ref leafNodes);
		
		// Recurse down right side.
		DFS(root.right, ref leftNodes, ref leafNodes);
	}
} */

// Second attempt.
public class Solution {
	public int SumOfLeftLeaves(TreeNode root, bool isLeft=false) {
		// Empty tree.
		if (root == null)
		{
			return 0;
		}
		
		// Leaf node. Return value if also a left node, otherwise 0.
		if (root.left == null && root.right == null)
		{
			return isLeft ? root.val : 0;
		}
		
		// Recurse on children.
		return SumOfLeftLeaves(root.left, true) + SumOfLeftLeaves(root.right, false);
	}
}