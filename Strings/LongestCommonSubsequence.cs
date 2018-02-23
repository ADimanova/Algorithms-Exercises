using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        var s1 = new char[] { 'a', 'c', 'b', 'c', 'f'};
        var s2 = new char[] { 'a', 'b', 'c', 'd', 'a', 'f'};
        // anwer - "abcf" / 4
        
        //var s1 = "GXTXAYB".ToCharArray();
        //var s2 = "AGGTAB".ToCharArray();
        // answer - "GTAB" / 4
        
        //var s1 = "ABCDGH".ToCharArray();
        //var s2 = "AEDFHR".ToCharArray();
        // answer - "ADH" / 3

        var result = LongestSub(s1, s2);
        Console.WriteLine(result);
    }
    
    static int LongestSub(char[] s1, char[] s2)
    {
        var mRowsCount = s1.Length + 1;
        var mColsCount = s2.Length + 1;
        var m = new int[mRowsCount, mColsCount];
        for(var r = 1; r < mRowsCount; r++)
        {
            for(var c = 1; c < mColsCount; c++)
            {    
                if(s1[r - 1] == s2[c - 1])
                {
                    m[r, c] = m[r - 1, c - 1] + 1;
                }
                else 
                {
                    m[r, c] = Math.Max(m[r - 1, c], m[r, c - 1]);
                }
            }
        }     
        
        PrintMatrix(mColsCount, mRowsCount, m);
        var sameCount = m[mRowsCount -1 , mColsCount - 1];
        
        var col = mColsCount - 1;
        var row = mRowsCount - 1;
        var path = new char[sameCount];
        var pathPlace = sameCount - 1;
        while(row > 0 && col > 0)
        {
            if(m[row, col] == m[row, col - 1])
            {
                //Console.WriteLine($"l val: {m[row, col]}, r: {row}, c: {col}");
                col--;
                continue;
            }
            else if(m[row, col] == m[row - 1, col])
            {
                //Console.WriteLine($"u val: {m[row, col]}, r: {row}, c: {col}");
                row--;
                continue;
            }
            
            //Console.WriteLine($"d val: {m[row, col]}, r: {row}, c: {col}");
            path[pathPlace] = s1[row - 1];
            pathPlace--;
            col--;
            row--;
        }  
        
       string pathString = new string(path);
       Console.WriteLine(pathString);
        
        return sameCount;
    }
    
    static void PrintMatrix(int mColsCount, int mRowsCount, int[,] m)
    {
        for(var r = 0; r < mRowsCount; r++)
        {
            for(var c = 0; c < mColsCount; c++)
            {            
                Console.Write($"{m[r, c]} ");
            }
            
            Console.WriteLine();
        }
    }
}
