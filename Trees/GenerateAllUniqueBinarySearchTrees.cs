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
    public IList<TreeNode> GenerateTrees(int n) {
        if(n < 1){
            return new List<TreeNode>();
        }
        
        return GenerateTrees(1, n);
    }
    
    public IList<TreeNode> GenerateTrees(int start, int end){
        var list = new List<TreeNode>();
        if(start > end){
            list.Add(null);
            return list;
        }
        
        for(var i = start; i <= end; i++){
            var left = GenerateTrees(start, i - 1);
            var right = GenerateTrees(i + 1, end);
            
            foreach(var l in left){
                foreach(var r in right){
                    var node = new TreeNode(i);
                    node.left = l;
                    node.right = r;
                    list.Add(node);
                }
            }
        }
        
        return list;
    }
}
