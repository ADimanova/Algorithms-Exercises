using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] tokens_n1 = Console.ReadLine().Split(' ');
        int n1 = Convert.ToInt32(tokens_n1[0]);
        int n2 = Convert.ToInt32(tokens_n1[1]);
        int n3 = Convert.ToInt32(tokens_n1[2]);
        string[] h1_temp = Console.ReadLine().Split(' ');
        int[] h1 = Array.ConvertAll(h1_temp,Int32.Parse);
        string[] h2_temp = Console.ReadLine().Split(' ');
        int[] h2 = Array.ConvertAll(h2_temp,Int32.Parse);
        string[] h3_temp = Console.ReadLine().Split(' ');
        int[] h3 = Array.ConvertAll(h3_temp,Int32.Parse);
        
        var stackA = new Stack<int>(h1.Reverse());
        var stackB = new Stack<int>(h2.Reverse());
        var stackC = new Stack<int>(h3.Reverse());
        
        var sumA = h1.Sum();
        var sumB = h2.Sum();
        var sumC = h3.Sum();    
        
        int currentSum = sumA;
        while(sumA > 0 && sumB > 0 && sumC > 0 &&
             (sumA != sumB || sumB != sumC))
        {
            var maxSum = Math.Max(sumA, Math.Max(sumB, sumC));

            if(maxSum == sumA)
            {
                var item = stackA.Pop();
                sumA -= item;
                currentSum = sumA;
            }         
            else if(maxSum == sumB)
            {
                var item = stackB.Pop();
                sumB -= item;
                currentSum = sumB;
            }
            else
            {
                var item = stackC.Pop();
                sumC -= item;
                currentSum = sumC;
            }
        }
        
        Console.WriteLine(currentSum);
    }
}
