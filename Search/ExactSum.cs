using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int[] FindExactSumIndexes(int total, int[] arr) {
        var matchingIndexMap = new Dictionary<int, int>();
        for(var i = 0; i < arr.Length; i++){
            if(matchingIndexMap.ContainsKey(arr[i])){
                return new int[] { matchingIndexMap[arr[i]] + 1, i + 1 };
            }
            
            matchingIndexMap[total - arr[i]] = i;
        }
        
        return null;
    }

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            int m = Convert.ToInt32(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
            int[] result = FindExactSumIndexes(m, arr);
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
