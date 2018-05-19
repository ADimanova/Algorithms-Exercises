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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        if(root == null){
            return new List<IList<int>>();
        }
        
        var rightLeftStack = new Stack<TreeNode>();
        var leftRightStack = new Stack<TreeNode>();
        
        var result = new List<IList<int>>();
        
        rightLeftStack.Push(root);
        
        var rightLeft = true;
        var currentList = new List<int>();
        
        while(rightLeftStack.Count > 0 || leftRightStack.Count > 0){
            var previousRightLeft = rightLeft;
            rightLeft = rightLeft ? rightLeftStack.Count != 0 : leftRightStack.Count == 0;
            if(previousRightLeft != rightLeft){
                result.Add(currentList);
                currentList = new List<int>();
            }
            
            var node = default(TreeNode);
            if(rightLeft){
                node = rightLeftStack.Pop();
                if(node.left != null){
                    leftRightStack.Push(node.left);                    
                }
                
                if(node.right != null){
                    leftRightStack.Push(node.right);
                }
            }
            else{
                node = leftRightStack.Pop();
                if(node.right !=null){
                    rightLeftStack.Push(node.right);
                }
                
                if(node.left != null){
                    rightLeftStack.Push(node.left);
                }
            }
            
            currentList.Add(node.val);            
        }
        
        result.Add(currentList);
        return result;
    }
}
