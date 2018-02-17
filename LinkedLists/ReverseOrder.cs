using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static void Main(String[] args) {
        var linkedList = new LinkedList();
        linkedList.Add(new Node(5));    
        for(var i = 4; i > 0; i--)
        {
            linkedList.Add(i);
        }
        
        var newLinkedList = new LinkedList();
        var removed = linkedList.RemoveTop();
        while(removed != null)
        {
            newLinkedList.Add(removed);
            removed = linkedList.RemoveTop();
        }
        
        removed = newLinkedList.RemoveTop();
        while(removed != null)
        {
            Console.WriteLine(removed.Value); 
            removed = newLinkedList.RemoveTop();
        }
    }
    
    class LinkedList
    {
        public Node StartNode {get; set;}
        
        public void Add(int value)
        {
            var newNode = new Node(value);
            this.Add(newNode);
        }
        
        public void Add(Node node)
        {
            if(this.StartNode == null)
            {
                this.StartNode = node;
                return;
            }

            node.NextNode = this.StartNode;
            this.StartNode = node;                    
        }
        
        public Node RemoveTop()
        {
            var removedNode = this.StartNode;
            if(removedNode != null)
            {
                this.StartNode = this.StartNode.NextNode; 
                removedNode.NextNode = null;
            }
            
            return removedNode;
        }
    }
    
    class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }
        
        public int Value {get; set;}
        public Node NextNode {get; set;}
    }
}
