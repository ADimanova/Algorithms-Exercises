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
    Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.
    */
    public IList<IList<int>> PathSum(TreeNode node, int sum) {
        if(node == null){
            return new List<IList<int>>();
        }
        
        return PathSum(node, sum, new Stack<int>());
    }
    
    private List<IList<int>> PathSum(TreeNode node, int sum, Stack<int> current){
        
        sum -= node.val;
        var result = new List<IList<int>>();      
        current.Push(node.val);
        if(node.left == null && node.right == null){
            if(sum == 0){
                result.Add(current.Reverse().ToList());
            }
        }
        
        if(node.left != null){
            var left = PathSum(node.left, sum, current);
            foreach(var l in left){
                result.Add(l);   
            }
        }
        
        if(node.right != null){
            var right = PathSum(node.right, sum, current);
            
            foreach(var r in right){
                result.Add(r);
            }
        }
        
        current.Pop();
        return result;
    }
}
