
/*
Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

Note:

The solution set must not contain duplicate triplets.
*/
public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        var result = new List<IList<int>>();
        
        if(nums.Length < 3){
            return result;
        }
        
        var uniqueNumCount = new Dictionary<int, int>();
        for(var i = 0; i < nums.Length; i++){
            if(!uniqueNumCount.ContainsKey(nums[i])){
                uniqueNumCount.Add(nums[i], 0);
            }
            
            if(uniqueNumCount[nums[i]] < 3){
                uniqueNumCount[nums[i]]++;
            }
        }
        
        var max3Nums = new List<int>();
        foreach(var count in uniqueNumCount){
            for(var i = 0; i < count.Value; i++){
                max3Nums.Add(count.Key);
            }
        }
        
        nums = max3Nums.ToArray();
                
        var uniqueSet = new HashSet<string>();
        Array.Sort(nums);
        for(var i = 0; i < nums.Length - 2; i++){
            var front = i + 1;
            var back = nums.Length - 1;
            while(front != back){
                var sum = nums[i] + nums[front] + nums[back];
                if(sum > 0){
                    back--;
                }
                else if(sum < 0){
                    front++;
                }
                else {
                    var key = GetKey(nums[i], nums[front], nums[back]);
                    if(!uniqueSet.Contains(key)){
                        result.Add(new List<int> { nums[i], nums[front], nums[back] });
                        uniqueSet.Add(key);
                    }
                    
                    front++;
                }
            }
        }
        
        return result;
    }
    
    private string GetKey(int a, int b, int c){
        if(a > b){
            var temp = a;
            a = b;
            b = temp;
        }
        
        if(a > c){
            var temp = a;
            a = c;
            c = temp;
        }
        
        if(b > c){
            var temp = c;
            c = b;
            b = temp;
        }
        
        return $"{a} {b} {c}";
    }
}
