using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        var input = Console.ReadLine().Trim();
        var charCounts = new Dictionary<char, int>();
        for(var i = 0; i < input.Length; i++){
            if(!charCounts.ContainsKey(input[i])){
                charCounts.Add(input[i], 0);
            }
            
            charCounts[input[i]]++;
        }
        
        var orderedCharCounts = charCounts.OrderBy(c => c.Key)
            .Select(c => new CharCountPair(){ Character = c.Key, Count = c.Value })
            .ToArray();
        var result = new char[input.Length];
        Permute(result, orderedCharCounts, 0);
    }
    
    static void Permute(char[] result, CharCountPair[] charsLeft, int depth){
        if(depth == result.Length){
            Print(result);
            return;
        }
        
        for(var i = 0; i < charsLeft.Length; i++){
            if(charsLeft[i].Count > 0){
                result[depth] = charsLeft[i].Character;
                charsLeft[i].Count--;
                
                Permute(result, charsLeft, depth + 1);
                
                charsLeft[i].Count++;
            }
        }
    }
    
    static void Print(char[] arr){
        Console.WriteLine(string.Join("", arr));
    }
}

public class CharCountPair {
    public char Character { get; set; }
    
    public int Count { get; set; }
}
