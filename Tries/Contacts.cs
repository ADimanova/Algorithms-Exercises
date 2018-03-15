using System;
using System.Collections.Generic;
using System.IO;

class Solution {
    static void Main(String[] args) {
        var trie = new Trie();
        
        var commandsCount = int.Parse(Console.ReadLine());
        for(var i = 0; i < commandsCount; i++)
        {
            var command = Console.ReadLine();
            ProcessComamnd(command, trie);
        }
    }
    
    static void ProcessComamnd(string command, Trie trie)
    {
        var parts = command.Split(' ');
        switch(parts[0])
        {
            case "add":
                trie.Insert(parts[1]);
                break;
            case "find":
                var count = trie.FindWords(parts[1]);
                Console.WriteLine(count);
                break;
            defaut: break;
        }
    }
    
    public class Trie
    {
        private Node root;
        
        public Trie()
        {
            this.root = new Node('*');
        }
        
        public int FindWords(string prefix)
        {
            var currentNode = this.root;
            char currentChar;
            for(var i = 0; i < prefix.Length; i++)
            {
                currentChar = prefix[i];
                if(currentNode.Children.ContainsKey(currentChar))
                {
                    currentNode = currentNode.Children[currentChar];
                }
                else 
                {
                    return 0;
                }
            }
            
            return currentNode.WordCount;
        }
        
        public void Insert(string word)
        {     
            var currentNode = this.root;
            char currentChar;
            for(var i = 0; i < word.Length; i++)
            {              
                currentChar = word[i];
                if(currentNode.Children.ContainsKey(currentChar))
                {
                    currentNode = currentNode.Children[currentChar];
                }
                else 
                {
                    currentNode.Children.Add(currentChar, new Node(currentChar));
                    currentNode = currentNode.Children[currentChar];
                }
                
                currentNode.WordCount++;
            }
            
            currentNode.IsEndOfWord = true;
        }
    }
    
    public class Node
    {
        public Node(char value)
        {
            this.Value = value;
            this.Children = new Dictionary<char, Node>();
        }
        
        public char Value { get; set; }
        public bool IsEndOfWord { get; set; }
        public int WordCount { get; set; }
        public Dictionary<char, Node> Children { get; set; }
        
        public bool IsLeaf()
        {
            return this.Children.Count == 0;
        }
    }
}
