using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        var queryCount = int.Parse(Console.ReadLine());
        var minHeap = new MinHeap();
        for(var i = 0; i < queryCount; i++){
            var query = Console.ReadLine().Split(new[] { ' ' });
            
            switch(query[0]){
                case "1":
                    minHeap.Add(int.Parse(query[1]));
                    break;
                case "2":
                    minHeap.Remove(int.Parse(query[1]));
                    break;
                case "3":
                    Console.WriteLine(minHeap.Peek());
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}

public class MinHeap{
    private List<int> heap;
    private Dictionary<int, int> indexMap;
    private int lastIndex;
    
    public MinHeap(){
        this.heap = new List<int>();
        this.indexMap = new Dictionary<int, int>();
        this.lastIndex = -1;
    }
    
    public void Add(int element){
        this.lastIndex++;
        if(this.heap.Count == this.lastIndex){
            this.heap.Add(element);
        }
        else{
            this.heap[this.lastIndex] = element;
        }
        
        this.indexMap[element] = this.lastIndex;
        
        HeapifyUp(this.lastIndex);
    }
    
    public int RemoveTop(){
        if(this.lastIndex == -1){
            throw new InvalidOperationException();
        }
        
        var top = this.heap[0];
        
        this.heap[0] = heap[this.lastIndex];
        this.lastIndex--;
        
        HeapifyDown(0);
        this.indexMap.Remove(top);
        return top;
    }
    
    public int Remove(int element){
        var index = this.indexMap[element];
        var elementAtLast = this.heap[this.lastIndex];
        Swap(index, this.lastIndex);
        this.lastIndex--;
        
        HeapifyUp(index);
        if(this.heap[index] == elementAtLast){
            HeapifyDown(index);
        }
        
        this.indexMap.Remove(element);
        return element;
    }
    
    public int Peek(){
        if(this.lastIndex == -1){
            throw new InvalidOperationException();
        } 
        
        return this.heap[0];
    }
    
    private void HeapifyUp(int index){        
        var parentIndex = GetParentIndex(index);
        
        while(HasParent(index) && this.heap[index] < this.heap[parentIndex]){
            Swap(index, parentIndex);
            index = parentIndex;
            parentIndex = GetParentIndex(index);
        }        
    }
    
    private void Swap(int index1, int index2){
        var temp = this.heap[index1];
        this.heap[index1] = this.heap[index2];
        this.heap[index2] = temp;
        
        this.indexMap[this.heap[index1]] = index1;
        this.indexMap[this.heap[index2]] = index2;
    }
    
    private int GetParentIndex(int index){
        return (index - 1) / 2;
    }
    
    private bool HasParent(int index){
        return index != 0;
    }
    
    private void HeapifyDown(int index){
        while(HasLeftChild(index)){
            var smallerChildIndex = GetLeftChildIndex(index);
            if(HasRightChild(index) && this.heap[smallerChildIndex] > this.heap[GetRightChildIndex(index)]){
                smallerChildIndex = GetRightChildIndex(index);
            }
            
            if(this.heap[index] < this.heap[smallerChildIndex]){
                break;
            }
            
            Swap(index, smallerChildIndex);
            index = smallerChildIndex;
        }
    }
    
    private int GetRightChildIndex(int index){
        return (index * 2) + 2;
    }
    
    private int GetLeftChildIndex(int index){
        return (index * 2) + 1;
    }
    
    private bool HasLeftChild(int index){
        return GetLeftChildIndex(index) <= this.lastIndex;
    }
    
    private bool HasRightChild(int index){
        return GetRightChildIndex(index) <= this.lastIndex;
    }
}
