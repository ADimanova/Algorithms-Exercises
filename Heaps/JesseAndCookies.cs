using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static long OperationCount(long minAllowedNumber, long[] initialNumbers) {
        var minHeap = new MinHeap();
        
        for(var i = 0; i < initialNumbers.Length; i++){
            minHeap.Add(initialNumbers[i]);            
        }
        
        long operationCount = 0;
        
        var currentMin = minHeap.PeekMin();
        while(minHeap.Count >= 2 && minHeap.PeekMin() < minAllowedNumber){
            operationCount++;
            var minElement = minHeap.RemoveMin();
            var secondMinElement = minHeap.RemoveMin();
            
            var newElement = minElement + (2 * secondMinElement);
            minHeap.Add(newElement);
            currentMin = minHeap.PeekMin();
        }
        
        if(currentMin < minAllowedNumber){
            return -1;
        }
        
        return operationCount;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        long k = Convert.ToInt32(nk[1]);

        long[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), ATemp => Convert.ToInt64(ATemp));
        long result = OperationCount(k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

public class MinHeap {
    private List<long> items;
    private int lastIndex;
    
    public int Count {
        get {
            return lastIndex + 1;
        }
    }
    
    public MinHeap() {
        items = new List<long>();
        lastIndex = -1;
    }
    
    public long PeekMin(){
        return items[0];
    }
    
    public void Add(long item){
        lastIndex++;
        if(lastIndex == items.Count){
            items.Add(item);
        }
        else{
            items[lastIndex] = item;
        }
        
        HeapifyUp(lastIndex);
    }
    
    public long RemoveMin(){
        var min = items[0];
        
        Swap(0, lastIndex);
        lastIndex--;
        HeapifyDown(0);
        
        return min;
    }
    
    private void HeapifyDown(int index){
        while(HasLeftChild(index)){
            var minChildIndex = GetLeftChildIndex(index);
            if(HasRightChild(index) && items[minChildIndex] > items[GetRightChildIndex(index)]){
                minChildIndex = GetRightChildIndex(index);
            }
            
            if(items[index] < items[minChildIndex]){
                break;
            }
            
            Swap(index, minChildIndex);
            index = minChildIndex;
        }
    }
    
    private bool HasLeftChild(int index){
        return GetLeftChildIndex(index) <= lastIndex;
    }
    
    private bool HasRightChild(int index){
        return GetRightChildIndex(index) <= lastIndex;
    }
    
    private int GetLeftChildIndex(int index){
        return (index * 2) + 1;
    }
    
    private int GetRightChildIndex(int index){
        return (index * 2) + 2;
    }
    
    private void HeapifyUp(int index){
        var parentIndex = GetParentIndex(index);
        
        while(HasParent(index) && items[parentIndex] > items[index]) {
            Swap(index, parentIndex);
            index = parentIndex;
            parentIndex = GetParentIndex(index);
        }
        
    }
    
    private bool HasParent(int index){
        return index != 0;
    }
    
    private int GetParentIndex(int index){
        return (index - 1) / 2;
    }
    
    private void Swap(int index1, int index2){
        var temp = items[index1];
        items[index1] = items[index2];
        items[index2] = temp;
    }
}
