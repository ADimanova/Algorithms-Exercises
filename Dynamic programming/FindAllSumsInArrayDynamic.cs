using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        //var arr = new int[] {3, 2, 8, 4 };
        //var isFound = FindSum(arr, 6);
        
        var arr = new int[] {2, 1, 1, 1 };
        var matrix = CreateDynamicMatrix(arr, 2);
        var results = GetAllCombinations(matrix, arr);
        Console.WriteLine("Result indexes:");
        foreach(var l in results)
        {
            Console.WriteLine(string.Join(" ", l));
        }
    }
    
    static List<List<int>> GetAllCombinations(int[,] m, int[] arr)
    {
        var r = m.GetLength(0);
        var c = m.GetLength(1);
        var stack = new Stack<int>();
        var result = new List<List<int>>();
        
        GetCombUtil(m, arr, r - 1, c - 1, stack, result);
        return result;
    }
    
    static void GetCombUtil(int[,] m, int[] arr, int r, int c, Stack<int> stack, List<List<int>> result)
    {
        if(c == 0)
        {
            result.Add(new List<int>(stack));
            return;
        }
        
        if(r == 0 && m[r, c] != 0)
        {
            stack.Push(r);
            result.Add(new List<int>(stack));
            stack.Pop();
            return;
        }
        
        if(m[r, c] != m[r - 1, c])
        {
            stack.Push(r);
            GetCombUtil(m, arr, r - 1, c - arr[r], stack, result);
            stack.Pop();
        }
        
        if(m[r - 1, c] != 0)
        {
            GetCombUtil(m, arr, r - 1, c, stack, result);
        }    
    }
    
    static int[,] CreateDynamicMatrix(int[] arr, int sum)
    {
        var sumWithZero = sum + 1;
        var m = new int[arr.Length, sumWithZero];
        for(int r = 0; r < arr.Length; r++)
        {
            for(int c = 0; c < sumWithZero; c++)
            {
                if(c == 0)
                {
                    m[r, c] = 1;
                    //Console.Write($"{m[r, c]} ");
                    continue;
                }
                
                if(r == 0)
                {
                    m[r, c] = arr[r] == c ? 1 : 0;
                    //Console.Write($"{m[r, c]} ");
                    continue;
                }
                              
                var prevR = r - 1;
                if(arr[r] > c)
                {
                    m[r, c] = m[prevR, c];
                }
                else 
                {
                    m[r, c] = m[prevR, c] + m[prevR, c - arr[r]]; 
                }
                
                //Console.Write($"{m[r, c]} ");
            }  
        }
        
        return m;
    }
}
