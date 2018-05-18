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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return BuildTree(preorder, inorder, 0, 0, inorder.Length);
    }
    
    private TreeNode BuildTree(int[] preorder, int[] inorder, int preorderIndex, int inorderIndex, int length){
        if(length == 0){
            return null;
        }
        
        var node = new TreeNode(preorder[preorderIndex]);
        
        var leftLength = 0;
        while(node.val != inorder[inorderIndex + leftLength]){
            leftLength++;
        }
        
        node.left = BuildTree(preorder, inorder, preorderIndex + 1, inorderIndex, leftLength);
        node.right = BuildTree(preorder, inorder, preorderIndex + 1 + leftLength, inorderIndex + 1 + leftLength, length - 1 - leftLength);
            
        return node;
    }
}
