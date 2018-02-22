using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static void Main(String[] args) {
        int[] arr = new int[] {1, 2, 4, 5, 6, 7}; //even
        //int[] arr = new int[] {1, 2, 4, 5, 6}; // odd
        //int[] arr = new int[] {1};
        //int[] arr = new int[] {};
        
        var searchedValue = 1;
        var isFound = BinarySearchRec(arr, searchedValue);
        Console.WriteLine($"Recursive answer: {isFound}");
        
        isFound = BinarySearchIter(arr, searchedValue);
        Console.WriteLine($"Iterative answer: {isFound}");
    }
    
    static bool BinarySearchIter(int[] arr, int number)
    {
        var left = 0;
        var right = arr.Length - 1;
        var midIndex = 0;
        
        while(left <= right)
        {
            midIndex = left + ((right - left) / 2);
            if(arr[midIndex] == number)
            {
                return true;
            }
            
            if(number < arr[midIndex])
            {
                right = midIndex - 1;         
            }
            else
            {
                left = midIndex + 1;
            }
        }
        
        return false;
    }
    
    static bool BinarySearchRec(int[] arr, int number)
    {
        return BinarySearchRecUtil(arr, number, 0, arr.Length - 1);
    }
    
    static bool BinarySearchRecUtil(int[] arr, int number, int left, int right)
    {        
        var midIndex = left + ((right - left) / 2);
        // optimized for no overflow over: (left + right) / 2
        // ex: 2, 4, 5, 6, 7 -> mid = 5 (index 2)
        // ex: 2, 4, 6, 7 -> mid = 4 (index 1)    
        
        if(left > right)
        {
            return false;
        }
        
        if(arr[midIndex] == number)
        {
            return true;
        }
        
        if(number < arr[midIndex])
        {
            return BinarySearchRecUtil(arr, number, left, midIndex - 1);            
        }
        else
        {
            return BinarySearchRecUtil(arr, number, midIndex + 1, right);
        }
    }
}
