using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static void Main(String[] args) {
        //Given a sorted array and a number x, find a pair in array whose sum is closest to x.
        var arr = new int[] {2, 3, 15, 18, 23, 25, 30};
        var expectedSum = 44;
        
        var bestSum = 0;
        var i = 0;
        var j = arr.Length - 1;
        var bestI = i;
        var bestJ = j;
        while (i != j)
        {
            var newSum = arr[i] + arr[j];

            if(expectedSum == newSum)
                break;
            if(expectedSum > newSum)
                i++;
            if(expectedSum < newSum)
                j--;

            if(Math.Abs(expectedSum - newSum) < Math.Abs(expectedSum - bestSum))
            {
                bestSum = newSum;
                bestI = i;
                bestJ = j;
            }     
        }
        
        Console.WriteLine(
            $"Sum of {arr[bestI]} and {arr[bestJ]} gives the closest sum of {bestSum}.");
    }
}
