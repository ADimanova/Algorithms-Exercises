using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        var heap = new MaxHeap();
        var arr = new int[] {30, 2, 50, 5, 60, 43, 14, 0, -12};
        foreach(var item in arr)
        {
            heap.Insert(item);
        }
        
        PrintHeap(heap);
        
        while(heap.Items.Count > 0)
        {
            Console.WriteLine(heap.RemoveTop());
            PrintHeap(heap);
        }
    }
    
    public static void PrintHeap(MaxHeap heap)
    {
        foreach(var item in heap.Items)
        {
            Console.Write($"{item} ");
        }
        
        Console.WriteLine();
    }
    
    public class MaxHeap
    {
        List<int> heap = new List<int>();
        
        public List<int> Items
        {
            get
            {
                return heap;
            }
        }
        
        public void Insert(int element)
        {
            //if no elements in heap, add to root
            //add last element to heap
            //while item's parent is smaller or no more parents, swap items
            
            heap.Add(element);
            
            var count = heap.Count;
            if(count == 1)
            {               
                return;
            }     
            
            var position = count;
            var parentPosition = position / 2;
            while(position != 1 && heap[position - 1] > heap[parentPosition - 1])
            {
                SwapItems(position - 1, parentPosition - 1);
                position = parentPosition;
                parentPosition = position / 2;
            }
        }
        
        public int RemoveTop()
        {
            //swap last and first item in list
            //remove last item and save it to return
            //reorder heap down
   
            var lastIndex = heap.Count - 1;
            SwapItems(0, lastIndex);
            var lastItem = heap[lastIndex];
            heap.RemoveAt(lastIndex);
            ReorderDown();
            
            return lastItem;
        }
        
        private void ReorderDown()
        {
            //1. check if el is biger than its children,
            //if so return
            //2. if not, swap it with the bigger of the two
            //3. continue swapping until 1. or no more children
            
            var position = 1;
            var leftChildPos = position * 2;
            var rightChildPos = leftChildPos + 1;
            while(leftChildPos <= heap.Count)
            {
                var hasRightChild = rightChildPos <= heap.Count;
                if(heap[position - 1] > heap[leftChildPos - 1] &&
                  (!hasRightChild ||
                      heap[position - 1] > heap[rightChildPos - 1]))
                {
                    return;
                }

                var largerElPos = !hasRightChild ||
                    heap[leftChildPos - 1] > heap[rightChildPos - 1] ?
                    leftChildPos :
                    rightChildPos;

                SwapItems(largerElPos - 1, position - 1);
                position = largerElPos;
                leftChildPos = position * 2;
                rightChildPos = leftChildPos + 1;
            }
        }
        
        private void SwapItems(int position, int parentPosition)
        {
            var temp = heap[position];
            heap[position] = heap[parentPosition];
            heap[parentPosition] = temp;
        }       
    }
}
