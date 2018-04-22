using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int GetMinimumTransmitterCount(int[] arr, int radius) {
        Array.Sort(arr);
        
        var count = 1;
        var lastToCover = arr[0];
        var lastPlaced = arr[0];
        var i = 1;
        
        while(i < arr.Length){
            if(arr[i] - lastToCover > radius){
                while(i < arr.Length && arr[i] - lastPlaced <= radius){
                   i++;
                }
                
                if(i < arr.Length){
                    lastPlaced = arr[i];
                    lastToCover = arr[i];
                    count++;
                }
            }
            else {
               lastPlaced = arr[i];
            }
            
            i++;
        }
        
        return count;
    }

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        string[] x_temp = Console.ReadLine().Split(' ');
        int[] x = Array.ConvertAll(x_temp,Int32.Parse);
        int result = GetMinimumTransmitterCount(x, k);
        Console.WriteLine(result);
    }
}
