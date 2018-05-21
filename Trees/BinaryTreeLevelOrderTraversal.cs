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
    Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

    For example:
    Given binary tree [3,9,20,null,null,15,7],

        3
       / \
      9  20
        /  \
       15   7

    return its level order traversal as:

    [
      [3],
      [9,20],
      [15,7]
    ]

    */
    public IList<IList<int>> LevelOrder(TreeNode root) {
        var result = new List<IList<int>>();
        if(root == null){
            return result;
        }        
        
        var enqueue = new Queue<TreeNode>();
        var dequeue = new Queue<TreeNode>();
        
        dequeue.Enqueue(root);
        var levelList = new List<int>();
        while(enqueue.Count > 0 || dequeue.Count > 0){
            if(dequeue.Count == 0){
                var temp = dequeue;
                dequeue = enqueue;
                enqueue = temp;
                result.Add(levelList);
                levelList = new List<int>();
            }
            
            var node = dequeue.Dequeue();    
            levelList.Add(node.val);
            
            if(node.left != null){
                enqueue.Enqueue(node.left);
            }
            
            if(node.right != null){
                enqueue.Enqueue(node.right);
            }
        }
        
        result.Add(levelList);       
        return result;
    }
}
