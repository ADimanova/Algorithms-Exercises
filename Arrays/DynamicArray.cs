using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        var inputs = Console.ReadLine().Split(' ');
        var n = int.Parse(inputs[0]);
        var q = int.Parse(inputs[1]);
        
        var lastAnswer = 0;
        var sequences = new List<List<int>>(n);
        for(var i = 0; i < n; i++)
        {
            sequences.Add(new List<int>());
        }
        
        List<int> currentSeq;
        var input = Console.ReadLine();
        while(input != null)
        {
            var command = Array.ConvertAll(input.Split(' '), int.Parse);

            switch(command[0])
            {
                case 1: 
                    currentSeq = GetSequence(sequences, command[1], lastAnswer);
                    currentSeq.Add(command[2]);
                    break;
                case 2:
                    currentSeq = GetSequence(sequences, command[1], lastAnswer);
                    var index = command[2] % currentSeq.Count;
                    lastAnswer = currentSeq[index];
                    Console.WriteLine(lastAnswer);
                    break;
                default:
                break;
            }
            
            input = Console.ReadLine();
        }
    }
    
    static List<int> GetSequence(List<List<int>> sequences, int x, int lastAnswer)
    {
        var seqIndex = (x ^ lastAnswer) % sequences.Count;
        return sequences[seqIndex];
    }
}
