using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    /*
    
    The house cannot be sold at a price greater than or equal to the price it was purchased at (i.e., it must be resold at a loss).
    The house cannot be resold within the same year it was purchased.

    Find and print the minimum loss.

    Note: It's guaranteed that a valid answer exists.
    */
    static long MinimumLoss(long[] price) {
        long minLoss = long.MaxValue;
        
        var indexMap = new Dictionary<long, int>();
        for(var i = 0; i < price.Length; i++){
            indexMap[price[i]] = i;
        }
        
        Array.Sort(price);
        
        for(var i = 1; i < price.Length; i++){
            
            if(indexMap[price[i]] < indexMap[price[i - 1]]){
                if(minLoss > price[i] - price[i - 1]){
                    minLoss = price[i] - price[i - 1];
                }
            }
        }
        
        return minLoss;
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] price_temp = Console.ReadLine().Split(' ');
        long[] price = Array.ConvertAll(price_temp,Int64.Parse);
        var result = MinimumLoss(price);
        Console.WriteLine(result);
    }
}
