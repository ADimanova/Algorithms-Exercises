public class Solution {
    public int LengthOfLIS(int[] nums) {
        var length = 1;
        if(nums.Length == 0){
            return 0;
        }
        
        var bestResults = new int[nums.Length];
        
        for(var i = 1; i < nums.Length; i++){
            for(var k = 0; k < i; k++){
                if(nums[i] > nums[k]){
                    bestResults[i] = bestResults[k] + 1 > bestResults[i] ? bestResults[k] + 1 : bestResults[i];
                    
                    if(length < bestResults[i] + 1){
                        length = bestResults[i] + 1;
                    }
                }
            }
        }
        
        return length;
    }
}
