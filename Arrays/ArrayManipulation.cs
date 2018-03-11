using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        
        var resultArr = new long[n + 1]; 
        for(int a0 = 0; a0 < m; a0++){
            string[] tokens_a = Console.ReadLine().Split(' ');
            int a = Convert.ToInt32(tokens_a[0]);
            int b = Convert.ToInt32(tokens_a[1]);
            int k = Convert.ToInt32(tokens_a[2]);
            
            resultArr[a] += k;
            
            if(b + 1 < resultArr.Length){
                resultArr[b + 1] -= k;
            }
        }
                
        var max = long.MinValue;
        long currentSum = 0;
        for(var i = 0; i < resultArr.Length; i++){
            currentSum += resultArr[i];
            if(currentSum > max){
                max = currentSum;
            }
        }
        
        Console.WriteLine(max);
    }
}
