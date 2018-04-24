using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    /*
    We define subsequence as any subset of an array. We define a subarray as a contiguous subsequence in an array.

    Given an array, find the maximum possible sum among:

      all nonempty subarrays.
      all nonempty subsequences.

    Print the two values as space-separated integers on one line.

    Note that empty subarrays/subsequences should not be considered. 
    */
    static long[] MaxSubArrayAndSubSequence(int[] arr) {
        long maxSumSubSequence = arr[0];
        long maxSumSubArray = arr[0];
        long bestSumSubArray = arr[0];
        for(var i = 1; i < arr.Length; i++){
            if(maxSumSubArray > 0 && maxSumSubArray + arr[i] > 0){
                maxSumSubArray += arr[i];
            }
            else {
                maxSumSubArray = arr[i];
            }      
            
            if(maxSumSubArray > bestSumSubArray){
                bestSumSubArray = maxSumSubArray;
            }
            
            if(maxSumSubSequence < maxSumSubSequence + arr[i]){
                maxSumSubSequence += arr[i];
            }
            
            if(maxSumSubSequence < arr[i]){
                maxSumSubSequence = arr[i];
            }
        }
        
        return new long[] { bestSumSubArray,  maxSumSubSequence };
    }
    
    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            long[] result = MaxSubArrayAndSubSequence(arr);
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
