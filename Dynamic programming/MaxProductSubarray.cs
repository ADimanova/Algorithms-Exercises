public class Solution {
    /*
    Given an integer array nums, find the contiguous subarray within an array (containing at least one number) which has the largest product.

    Example 1:

    Input: [2,3,-2,4]
    Output: 6
    Explanation: [2,3] has the largest product 6.

    Example 2:

    Input: [-2,0,-1]
    Output: 0
    Explanation: The result cannot be 2, because [-2,-1] is not a subarray.
    */
    public int MaxProduct(int[] nums) {
        var minResult = nums[0];
        var maxResult = nums[0];
        var result = nums[0];
        for(var i = 1; i < nums.Length; i++){
            if(nums[i] < 0){
                var temp = minResult;
                minResult = maxResult;
                maxResult = temp;
            }
            
            minResult = Math.Min(nums[i], minResult * nums[i]);
            maxResult = Math.Max(nums[i], maxResult * nums[i]);
            
            if(maxResult > result){
                result = maxResult;
            }
        }
        
        return result;
    }
}
