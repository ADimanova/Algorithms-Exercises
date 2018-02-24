using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        var arr = new int[] {3, 2, 8, 2, 7, 5, 12, 9};  // answer = 5
        var isFound = FindSum(arr, 10);
        Console.WriteLine(isFound);
    }
    
    static int FindSum(int[] arr, int sum)
    {
        var memo = new Dictionary<string, int>();
        return FindSumUtil(arr, sum, 0, memo);
    }
    
    static int FindSumUtil(int[] arr, int sum, int index, Dictionary<string, int> memo)
    {
        var key = $"{sum}:{index}";
        if(memo.ContainsKey(key))
        {
            //Console.WriteLine($"Duplicate key: {key}, memo: {memo[key]}");
            return memo[key];
        }
        
        if(sum == 0)
        {
            return 1;
        }
        
        if(sum < 0 || index == arr.Length)
        {
            return 0;
        }
        
        var toReturn = 0;
        if(arr[index] > sum)
        {
            toReturn = FindSumUtil(arr, sum, index + 1, memo);
        }
        
        toReturn = FindSumUtil(arr, sum - arr[index], index + 1, memo) +
            FindSumUtil(arr, sum, index + 1, memo);
        
        memo.Add(key, toReturn);
        //Console.WriteLine($"key: {key}, memo: {memo[key]}");
        
        return toReturn;
    }
}
