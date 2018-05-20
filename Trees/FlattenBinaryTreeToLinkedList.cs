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
    /*
    Given a binary tree, flatten it to a linked list in-place.

    For example, given the following tree:

        1
       / \
      2   5
     / \   \
    3   4   6

    The flattened tree should look like:

    1
     \
      2
       \
        3
         \
          4
           \
            5
             \
              6
    */
    public void Flatten(TreeNode node) {
        if(node == null){
            return;
        }
        
        if(node.left != null){
            var left = node.left;
            node.left = null;
            var right = node.right;
            node.right = left;
            if(right != null){
                AttachToRight(node.right, right);
            }
        }
        
        Flatten(node.right);
    }
    
    private void AttachToRight(TreeNode target, TreeNode nodeToAttach){
        if(target.right != null){
            AttachToRight(target.right, nodeToAttach);
        }
        else{
            target.right = nodeToAttach;
        }
    }
}
