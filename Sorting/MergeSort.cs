using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {

    static string[] BigSorting(string[] arr) {
        var temp = new string[arr.Length];
        
        MergeSort(arr, temp, 0, arr.Length - 1);
        return arr;
    }
    
    static void MergeSort(string[] arr, string[] temp, int left, int right){
        if(left >= right){
            return;
        }
        
        var middle = (left + right) / 2;
        
        MergeSort(arr, temp, left, middle);
        MergeSort(arr, temp, middle + 1, right);
        Merge(arr, temp, left, middle, right);
    }
    
    static void Merge(string[] arr, string[] temp, int left, int middle, int right){
        var start = left;
        var end = right;
        var tempIndex = left;
        var secondStart = middle + 1;
        while(left <= middle && secondStart <= right){
            if(Compare(arr[left], arr[secondStart]) > 0){
                temp[tempIndex] = arr[secondStart];
                secondStart++;
            }
            else{
                temp[tempIndex] = arr[left];
                left++;
            }
            
            tempIndex++;
        }
        
        while(left <= middle){
            temp[tempIndex] = arr[left];
            left++;
            tempIndex++;
        }
        
        while(secondStart <= right){
            temp[tempIndex] = arr[secondStart];
            secondStart++;
            tempIndex++;
        }
        
        for(var i = start; i <= end; i++){
            arr[i] = temp[i];
        }
    }

    static int Compare(string x, string y){
        if(x.Length > y.Length){
            return 1;
        }
        
        if(x.Length < y.Length){
            return -1;
        }
        
        for(var i = 0; i < x.Length; i++){
            if(x[i] > y[i]){
                return 1;
            }
            
            if(x[i] < y[i]){
                return -1;
            }
        }
        
        return 0;
    }
    
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string[] unsorted = new string [n];

        for (int unsortedItr = 0; unsortedItr < n; unsortedItr++) {
            string unsortedItem = Console.ReadLine();
            unsorted[unsortedItr] = unsortedItem;
        }

        string[] result = BigSorting(unsorted);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
