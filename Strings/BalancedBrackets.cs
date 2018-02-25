using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {    
    static string isBalanced(string s) {
        var stack = new Stack<char>();
        var dict = new Dictionary<char, char>
        {
            { '}', '{' },
            { ')', '(' },
            { ']', '[' },
        };
                  
        for(var i = 0; i < s.Length; i++)
        {               
            // if opening bracket - push in stack
            // if closing bracket - pop from stack, 
                // get closing stack opening from dict
                // if closing bracker is not oposite to poped bracker - fail
            // if no more brackets to be read and items in stack - fail
            // if no more items in stack and closing bracker is read - fail  
            
            var bracket = s[i];
            if(!dict.ContainsKey(bracket))
            {
                stack.Push(bracket);
            }
            else 
            {
                if(stack.Count == 0)
                {
                    return "NO";
                }
                
                var item = stack.Pop();
                var opposite = dict[bracket];
                if(item != opposite)
                {
                    return "NO";
                }
            }
        
        }
        
        if(stack.Count > 0)
        {
            return "NO";
        }
        
        return "YES";  
    }

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            string s = Console.ReadLine();
            string result = isBalanced(s);
            Console.WriteLine(result);
        }
    }
}
