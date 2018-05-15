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
    public IList<int> InorderTraversal(TreeNode root) {
        var stack = new Stack<TreeNode>();
        var node = root;
        var result = new List<int>();        
        while(node != null || stack.Count != 0){
            if(node != null){
                stack.Push(node);
                node = node.left;
            }
            else{                
                node = stack.Pop();
                result.Add(node.val);
                node = node.right;
            }
        }
        
        return result;    
    }
}
