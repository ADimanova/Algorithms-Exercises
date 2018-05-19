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
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        return BuildTree(inorder, postorder, postorder.Length - 1, postorder.Length - 1, postorder.Length);
    }
    
    public TreeNode BuildTree(int[] inorder, int[] postorder, int inorderIndex, int postorderIndex, int length){
        if(length == 0){
            return null;
        }
        
        var node = new TreeNode(postorder[postorderIndex]);
        var rightLength = 0;
        while(node.val != inorder[inorderIndex - rightLength]){
            rightLength++;
        }
        
        node.left = BuildTree(inorder, postorder, inorderIndex - 1 - rightLength, postorderIndex - 1 - rightLength, length - rightLength - 1);
        node.right = BuildTree(inorder, postorder, inorderIndex, postorderIndex - 1, rightLength);
        
        return node;
    }
}
