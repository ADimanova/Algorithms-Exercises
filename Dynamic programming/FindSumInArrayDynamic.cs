using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        var arr = new int[] {3, 2, 8, 4 };
        var isFound = FindSum(arr, 6);
        Console.WriteLine($"Sum found: {isFound}");
    }
    
    static bool FindSum(int[] arr, int sum)
    {
        var sumWithZero = sum + 1;
        var m = new bool[arr.Length, sumWithZero];
        for(int r = 0; r < arr.Length; r++)
        {
            for(int c = 0; c < sumWithZero; c++)
            {
                if(c == 0)
                {
                    m[r, c] = true;
                    Console.Write(m[r, c] ? "T " : "F ");
                    continue;
                }
                
                if(r == 0)
                {
                    m[r, c] = arr[r] == c ? true : false;
                    Console.Write(m[r, c] ? "T " : "F ");
                    continue;
                }
                
                var prevR = r - 1;
                if(m[prevR, c])
                {
                    m[r, c] = true;
                }
                else {
                    if(arr[r] > c)
                    {
                        m[r, c] = false;
                    }
                    else
                    {
                        m[r, c] = m[prevR, c - arr[r]];
                    }                       
                }
                
                Console.Write(m[r, c] ? "T " : "F ");
            }  
            
            Console.WriteLine();
        }
        
        return m[arr.Length - 1, sum];
    }
}
