using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static void Main(String[] args) {
        //Given a sorted array and a number x, find a pair in array whose sum is closest to x.
        
        //var arr = new int[] {2, 3, 15, 18, 23, 25, 30};
        //var expectedSum = 44;
        
        //var arr = new int[] {1, 3, 5, 6, 8, 12, 15, 18, 22, 44};
        //var expectedSum = 20;
        
        var arr = new int[] {1, 4, 7, 10};
        var expectedSum = 15;
        
        var bestSum = 0;
        var i = 0;
        var j = arr.Length - 1;
        var bestI = i;
        var bestJ = j;
        while (i != j)
        {
            var newSum = arr[i] + arr[j];

            if(expectedSum == newSum)
            {
                bestSum = newSum;
                bestI = i;
                bestJ = j;
                break;
            }

            if(Math.Abs(expectedSum - newSum) < Math.Abs(expectedSum - bestSum))
            {
                bestSum = newSum;
                bestI = i;
                bestJ = j;
            }
            
            if(expectedSum > newSum)
            {
                i++;                
            }
            else if(expectedSum < newSum)
            {
                j--;                
            }
        }
        
        Console.WriteLine(
            $"Sum of {arr[bestI]} and {arr[bestJ]} gives the closest sum of {bestSum}.");
    }
}
