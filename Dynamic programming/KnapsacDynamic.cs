using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    //static int[] values = new int[] {60, 100, 120};
    //static int[] weights = new int[] {10, 20, 30};
    //static int expectedWeight = 50;
    //answer - 220
    
    static int[] values = new int[] {100, 20, 60, 40};
    static int[] weights = new int[] {3, 2, 4, 1};
    static int expectedWeight = 5;
    //answer - 140
    
    //static int[] values = new int[] {5, 10, 3, 2, 3};
    //static int[] weights = new int[] {4, 8, 3, 5, 2};
    //static int expectedWeight = 10;
    //answer - 13
    
    static void Main(String[] args) {
        var maxValue = GetMaxValue();
        Console.WriteLine(maxValue);
    }
    
    static int GetMaxValue()
    {
        // have case for item with no weight and bag with no capacity
        var rowsCount = weights.Length;
        var colsCount = expectedWeight + 1;
        var matrix = new int[rowsCount, colsCount];
        for(var row = 0; row < rowsCount; row++)
        {
            for(var col = 0; col < colsCount; col++)
            {
                if(col == 0)
                {
                   continue;
                }

                var prevValue = row - 1 >= 0 ? matrix[row - 1, col] : 0;
                if(weights[row] <= col)
                {
                    var wLeft = col - weights[row];
                    var prevBest = row - 1 >= 0 ? matrix[row - 1, wLeft] : 0;
                    var newValue = values[row] + prevBest;
                    var maxValue = Math.Max(newValue , prevValue);
                    matrix[row, col] = maxValue;
                }
                else {
                    matrix[row, col] = prevValue;
                } 

                Console.Write($"{matrix[row, col]} "); 
            }

            Console.WriteLine();
        }
        
        var result = matrix[rowsCount - 1, colsCount - 1];
        var itemsInBag = new List<int>();
        var currentCol = colsCount - 1;
        for(var t = rowsCount - 1, t >= 0; t--)
        {
            if(t == 0 && matrix[t, currentCol] > 0)
            {
                itemsInBag.Add(t);
                break;
            }
            
            if(matrix[t, currentCol] == 0)
            {
                break;
            }
            
            if(matrix[t, currentCol] != matrix[t - 1, currentCol])
            {
                itemsInBag.Add(t);
                currentCol = currentCol - weights[t];
            }
        }

        return result;
    }
}
