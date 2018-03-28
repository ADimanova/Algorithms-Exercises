using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
class Solution {
    static void Main(String[] args) {
        var count = int.Parse(Console.ReadLine());
        var sb = new StringBuilder();
        var undoStack = new Stack<Tuple<int, object>>();
        for(var i = 0; i < count; i++){
            var commands = Console.ReadLine().Split(' ');
            switch(commands[0]){
                case "1":
                    var c = Append(commands[1], sb);
                    undoStack.Push(Tuple.Create(2, (object)c));
                    break;
                case "2": 
                    var charCount = int.Parse(commands[1]);
                    var removed = Remove(charCount, sb);
                    undoStack.Push(Tuple.Create(1, (object)removed));
                    break;
                case "3":
                    var n = int.Parse(commands[1]);
                    Console.WriteLine(sb[n - 1]);
                    break;
                case "4":
                    var item = undoStack.Pop();
                    if(item.Item1 == 1){
                        Append((string)item.Item2, sb);
                    }
                    else if (item.Item1 == 2){
                        Remove((int)item.Item2, sb);
                    }
                    break;
                default:
                    break;
            }
        }
    }
    
    static int Append(string input, StringBuilder sb){
        sb.Append(input);
        return input.Length;
    }
    
    static string Remove(int charCount, StringBuilder sb){
        var removed = sb.ToString(sb.Length - charCount, charCount);
        sb.Length = sb.Length - charCount;
        return removed;
    }
}
