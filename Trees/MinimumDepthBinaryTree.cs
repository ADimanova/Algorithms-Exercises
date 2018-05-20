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
    Given a binary tree, find its minimum depth.
    The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
    */
    public int MinDepth(TreeNode root) {    
        if(root == null){
            return 0;
        }
        
        var dequeue = new Queue<TreeNode>();
        var enqueue = new Queue<TreeNode>();
        dequeue.Enqueue(root);
        
        var level = 1;        
        while(dequeue.Count > 0 || enqueue.Count > 0){
            if(dequeue.Count == 0){
                var temp = dequeue;
                dequeue = enqueue;
                enqueue = temp;
                level++;
            }
            
            var node = dequeue.Dequeue();
            if(IsLeaf(node)){
                break;
            }
            
            if(node.left != null){
                enqueue.Enqueue(node.left);
            }
            
            if(node.right != null){
                enqueue.Enqueue(node.right);
            }
        }
        
        return level;
    }
    
    private bool IsLeaf(TreeNode node){
        if(node.left == null && node.right == null){
            return true;
        }
        
        return false;
    }
}
