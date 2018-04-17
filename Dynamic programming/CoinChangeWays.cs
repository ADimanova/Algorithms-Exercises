using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static long GetWays(long amount, long[] coins){
        var resultMatrix = new long[coins.Length, amount + 1];
        
        for(var row = 0; row < resultMatrix.GetLength(0); row++){
            for(var col = 0; col < resultMatrix.GetLength(1); col++){
                
                if(col == 0){
                    resultMatrix[row, col] = 1;
                    continue;
                }
                
                if(row != 0){
                    resultMatrix[row, col] += resultMatrix[row - 1, col];
                }
                
                var currentCoinDenomination = coins[row];
                if(currentCoinDenomination <= col){
                    resultMatrix[row, col] +=  resultMatrix[row, col - currentCoinDenomination];
                }
            }
        }
        
        return resultMatrix[resultMatrix.GetLength(0) - 1, resultMatrix.GetLength(1) - 1];
    }

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        string[] c_temp = Console.ReadLine().Split(' ');
        long[] c = Array.ConvertAll(c_temp,Int64.Parse);
        long ways = GetWays(n, c);
        Console.WriteLine(ways);
    }
}
