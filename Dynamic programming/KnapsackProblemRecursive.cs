using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    //static int[] values = new int[] {60, 100, 120};
    //static int[] weights = new int[] {10, 20, 30};
    //static int expectedWeight = 50;
    //answer - 220
    
    //static int[] values = new int[] {100, 20, 60, 40};
    //static int[] weights = new int[] {3, 2,	4, 1};
    //static int expectedWeight = 5;
    //answer - 140
    
    static int[] values = new int[] {5, 10, 3, 2, 3};
    static int[] weights = new int[] {4, 8,	3, 5, 2};
    static int expectedWeight = 10;
    //answer - 13
    
    static void Main(String[] args) {
        var maxWeight = GetMaxWeight();
        Console.WriteLine(maxWeight);
    }
    
    static int GetMaxWeight()
    {
        var memo = new Dictionary<string, int>();
        return GetMaxWeightUtil(0, expectedWeight, 0, memo);
    }
    
    static int GetMaxWeightUtil(int index, int weight, int currentValue, Dictionary<string, int> memo)
    {        
        //Console.WriteLine($"weight: {weight}; value: {currentValue}");
        if(index == weights.Length)
        {
            return currentValue;
        }
        
        var key = $"{index}:{weight}";        
        if(memo.ContainsKey(key))
        {
            //Console.WriteLine($"key: {key}; memo: {memo[key]}");
            return memo[key];
        }
        
        if(weights[index] > weight)
        {
            return GetMaxWeightUtil(index + 1, weight, currentValue, memo);
        }

        var usedItem = 
            GetMaxWeightUtil(index + 1, weight - weights[index], currentValue + values[index], memo);
        var notUsedItem = GetMaxWeightUtil(index + 1, weight, currentValue, memo);
        var maxValue = Math.Max(usedItem, notUsedItem);
        memo.Add(key, maxValue);
        
        return maxValue;
    }
}
