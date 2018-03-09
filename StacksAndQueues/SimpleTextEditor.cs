using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        var n = int.Parse(Console.ReadLine());
        var editor = new TextEditor();
        for(var i = 0; i < n; i++)
        {
            var command = Console.ReadLine();
            editor.ProcessCommand(command);
        }
    }
    
    public class TextEditor
    {      
        List<char> text;
        Stack<Command> commands;
        
        public TextEditor()
        {
            text = new List<char>();
            commands = new Stack<Command>();
        }
        
        public void ProcessCommand(string commandInput)
        {
            var items = commandInput.Split(' ');
            switch(int.Parse(items[0]))
            {
                case 1: 
                    Append(items[1]);
                    break;
                case 2: 
                    Delete(items[1]);
                    break;
                case 3:
                    Print(items[1]);
                    break;
                case 4: 
                    Undo();
                    break;
            }
        }
        
        void Append(string input)
        {
            var chars = input.ToCharArray();
            for(var i = 0; i < chars.Length; i++)
            {
                text.Add(chars[i]);
            }

            var command = new Command(1, input);
            commands.Push(command);
        }
        
        void Delete(string input)
        {
            int itter = int.Parse(input);
            var removed = new char[itter];
            for(var i = 0; i < itter; i++)
            {
                removed[i] = text[text.Count - 1];
                text.RemoveAt(text.Count - 1);
            }
            
            var command = new Command(2, string.Concat(removed));
            commands.Push(command);
        }
                
        void Print(string input)
        {
            int index = int.Parse(input) - 1; 
            Console.WriteLine(text[index]);
        }
        
        void UndoAppend(string input)
        {
            for(var i = 0; i < input.Length; i++)
            {
                text.RemoveAt(text.Count - 1);
            }
        }
        
        void UndoDelete(string input)
        {
            for(var i = input.Length - 1; i >= 0; i--)
            {               
                text.Add(input[i]);
            }
        }
        
        void Undo()
        {
            var command = commands.Pop();
            if(command.CommandType == 1)
            {
                UndoAppend(command.Value);
            }
            else if(command.CommandType == 2)
            {
                UndoDelete(command.Value);
            }
        }
        
        public struct Command
        {
            public Command(int commandType, string value)
            {
                this.CommandType = commandType;
                this.Value = value;
            }
            
            public int CommandType {get; set;}
            public string Value {get; set;}
        }
    }    
}
