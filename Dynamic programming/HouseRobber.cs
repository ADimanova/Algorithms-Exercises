public class Solution {
    /*
    You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

    Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.
    */    
    public int Rob(int[] nums) {
        if(nums.Length == 0){
            return 0;
        }
        
        var result = new int[nums.Length];
        
        for(var i = 0; i < nums.Length; i++){
            if(i > 1){
                result[i] = Math.Max(result[i - 1], result[i - 2] + nums[i]);
            }
            else if (i == 1){
                result[i] = Math.Max(nums[i], result[i - 1]);
            }
            else{
                result[i] = nums[i];
            }
        }
        
        return result[nums.Length - 1];
    }
}
