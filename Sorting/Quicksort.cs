using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static void Main(String[] args) {
        int[] arr = new int[] {1, 4, 2, 12, 3, 15}; //even
        //int[] arr = new int[] {1, 4, 2, 12, 3}; // odd
        //int[] arr = new int[] {1};
        //int[] arr = new int[] {};  
        
        var resultArr = QuickSort(arr);
        Console.WriteLine(string.Join(" ", resultArr));
    }
    
    static int[] QuickSort(int[] arr)
    {
        QuickSortUtil(arr, 0, arr.Length - 1);
        return arr;
    }
    
    static void QuickSortUtil(int[] arr, int left, int right)
    {   
        if(left >= right)
        {
            return;
        }
        
        var pivotIndex = left + ((right - left) / 2);
        var index = Partition(arr, arr[pivotIndex], left, right);
        
        QuickSortUtil(arr, left, index - 1);
        QuickSortUtil(arr, index, right);
    }
    
    static int Partition(int[] arr, int pivot, int left, int right)
    {      
        while(left <= right)
        {
            while(arr[left] < pivot)
            {
                left++;
            }

            while(arr[right] > pivot)
            {
                right--;
            }
            
            if(left <= right)
            {               
                Swap(arr, left, right);
                // equality "left <= right" is needed so that left and right
                // can be increased beyond the pivot's index and the cycle can break
                left++; 
                right--;
            }
        }    
        
        return left;
    }
    
    static void Swap(int[] arr, int left, int right)
    {
        var temp = arr[left];
        arr[left] = arr[right];
        arr[right] = temp;
    }
}
