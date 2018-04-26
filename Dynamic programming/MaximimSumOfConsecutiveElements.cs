using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    
    /*
    Given array arr containing elements arr[0], arr[2]... arr[n - 1] get the maximum sum of consecutive pairs of a new array 
    that follows the rules:
    1 <= arr2[i] <= arr[i]
    Select elements for array A such that it maximizes S (sum of difference between consecutive elements of A).
    maximize abs(arr2[0] - arr2[1]) + abs(arr2[1] - arr2[2]) + ... + abs(arr2[n-2] - arr2[n-1])
    note that any number between 1 and arr[i] can be placed on position i
    */
    static int Cost(int[] arr) {
        var maxHigh = 0;
        var maxLow = 0;
        
        for(var i = 1; i < arr.Length; i++){
            var currentHigh = arr[i] - 1; // if current remains as is, but previous is 1
            var currentLow = arr[i - 1] - 1; // if current is 1 but previous has remained as is
            
            // simultaneous update
            var high = Math.Max(maxHigh, maxLow + currentHigh);
            var low = Math.Max(maxLow, maxHigh + currentLow);
            
            maxHigh = high;
            maxLow = low;
        }
        
        return Math.Max(maxHigh, maxLow);
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < t; i++) {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), a => Convert.ToInt32(a));
            int result = Cost(arr);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
