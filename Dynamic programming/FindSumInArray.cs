using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        var arr = new int[] {3, 2, 8, 4, 2, 3, 4, 4, 8, 34, 2, 3, 43, 12, 342, 43, 54, 2};
        var isFound = FindSum(arr, 50);
        Console.WriteLine(isFound);
    }
    
    static bool FindSum(int[] arr, int sum)
    {
        var memo = new Dictionary<string, bool>();
        return FindSumUtil(arr, sum, 0, memo);
    }
    
    static bool FindSumUtil(int[] arr, int sum, int index, Dictionary<string, bool> memo)
    {
        var key = $"{sum}:{index}";
        if(memo.ContainsKey(key))
        {
            //Console.WriteLine($"Duplicate key: {key}, memo: {memo[key]}");
            return memo[key];
        }
        
        if(sum == 0)
        {
            return true;
        }
        
        if(sum < 0 || index == arr.Length)
        {
            return false;
        }
        
        var toReturn = false;
        if(arr[index] > sum)
        {
            toReturn = FindSumUtil(arr, sum, index + 1, memo);
        }
        
        toReturn = FindSumUtil(arr, sum - arr[index], index + 1, memo) || FindSumUtil(arr, sum, index + 1, memo);
        memo.Add(key, toReturn);
        //Console.WriteLine($"key: {key}, memo: {memo[key]}");
        
        return toReturn;
    }
}
