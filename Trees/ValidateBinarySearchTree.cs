/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public bool IsValidBST(TreeNode root) {
        int? min = null;
        int? max = null;
        return IsValidBST(root, min, max);
    }
    
    public bool IsValidBST(TreeNode node, int? min, int? max){
        if(node == null){
            return true;
        }
        
        if((max != null && node.val >= max) || (min != null && node.val <= min)){
            return false;
        }
        
        return IsValidBST(node.left, min, node.val) && IsValidBST(node.right, node.val, max);
    }
}
