using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        var arr = new int[] {43, 2, 3, 4};
        var isFound = FindSum(arr, 5);
        Console.WriteLine(isFound);
    }
    
    static bool FindSum(int[] arr, int sum)
    {
        return FindSumUtil(arr, sum, 0);
    }
    
    static bool FindSumUtil(int[] arr, int sum, int index)
    {
        if(sum == 0)
        {
            return true;
        }
        
        if(sum < 0 || index == arr.Length)
        {
            return false;
        }
        
        if(arr[index] > sum)
        {
            return FindSumUtil(arr, sum, index + 1);
        }
        
        return FindSumUtil(arr, sum - arr[index], index + 1) || FindSumUtil(arr, sum, index + 1);
    }
}
