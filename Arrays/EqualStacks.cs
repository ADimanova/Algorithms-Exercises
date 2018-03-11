using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        Console.ReadLine();
        var inputA = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        var inputB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        var inputC = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);    
        
        var sumA = SumArray(inputA);
        var sumB = SumArray(inputB);
        var sumC = SumArray(inputC);
        
        var indexA = 0;
        var indexB = 0;
        var indexC = 0;
        
        while(indexA < inputA.Length && 
            indexB < inputB.Length &&
            indexC < inputC.Length)
        {
            if(sumA == sumB && sumB == sumC)
            {
                Console.WriteLine(sumA);
                return;
            }

            if(sumA >= sumB && sumA >= sumC)
            {
                sumA = sumA - inputA[indexA];
                indexA++;
            }
            else if(sumB >= sumA && sumB >= sumC)
            {
                sumB = sumB - inputB[indexB];
                indexB++; 
            }
            else if(sumC >= sumA && sumC >= sumB)
            {
                sumC = sumC - inputC[indexC];
                indexC++; 
            }
        }

        Console.WriteLine(0);
    }
    
    static int SumArray(int[] arr)
    {
        var sum = 0;
        for(var i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        
        return sum;
    }
}
