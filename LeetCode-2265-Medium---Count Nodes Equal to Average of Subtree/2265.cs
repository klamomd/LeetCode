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

public class Solution {
	public int AverageOfSubtree(TreeNode root) {
		return AverageOfSubtreeDFS(root, out _, out _);
	}

	// Returns the number of nodes in the tree where the value of the node is equal to the average of the values in its subtree.
	// Also returns (via the `out` vars) the number of nodes in the tree, and the sum of all their values.
	private int AverageOfSubtreeDFS(TreeNode root, out int treeSum, out int nodeCount) {
		// Base case: leaf node.
		if (root.left == null && root.right == null) {
			nodeCount = 1;
			treeSum = root.val;

			// Return 1 (as there is only 1 node, and its value will always equal its average).
			return 1;
		}

		int leftSum = 0,
			rightSum = 0,
			leftCount = 0,
			rightCount = 0,
			leftResult = 0,
			rightResult = 0;

		// Recurse left.
		if (root.left != null) {
			leftResult = AverageOfSubtreeDFS(root.left, out leftSum, out leftCount);
		}

		// Recurse right.
		if (root.right != null) {
			rightResult = AverageOfSubtreeDFS(root.right, out rightSum, out rightCount);
		}

		// Set the out vars.
		treeSum = leftSum + rightSum + root.val;
		nodeCount = leftCount + rightCount + 1;

		// Determine whether the root node's value equals the average
		if (root.val == treeSum / nodeCount) {
			return leftResult + rightResult + 1;
		}
		else {
			return leftResult + rightResult;
		}
	}
}