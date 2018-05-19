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
    Given a binary tree, determine if it is height-balanced.
    For this problem, a height-balanced binary tree is defined as:
    A binary tree in which the depth of the two subtrees of every node never differ by more than 1.
    */
    
    public bool IsBalanced(TreeNode root) {
        var result = Height(root, 1);
        return result.IsBalanced;
    }
    
    private Result Height(TreeNode node, int level){
        if(node == null){
            return new Result() { Min = level, Max = level, IsBalanced = true };
        }
        
        level++;
        var left = Height(node.left, level);
        if(!left.IsBalanced){
            return left;
        }
        
        var right = Height(node.right, level);
        if(!right.IsBalanced){
            return right;
        }
        
        left.Min = Math.Min(left.Min, right.Min);
        left.Max = Math.Max(left.Max, right.Max);
        
        if(Math.Abs(left.Max - left.Min) > 1){
            left.IsBalanced = false;
        }
        
        // We are looking for the depth of each subtree, not the comparison between the shallowest and deepest leafs in the whole tree.
        left.Min = left.Max;
        
        return left;
    }
}

public class Result {
    public int Min { get; set; }
    
    public int Max { get; set; }
    
    public bool IsBalanced { get; set; }
    
    public override string ToString(){
        return Min + " " + Max + " " + IsBalanced;
    }
}
