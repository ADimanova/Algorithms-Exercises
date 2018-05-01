using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int RepeatedStringLetterDifferenceCount(string s, string repeatedString) {
        var differenceCount = 0;
        
        for(var i = 0; i < s.Length; i++){
            for(var r = 0; r < repeatedString.Length && i < s.Length; r++){
                if(s[i] != repeatedString[r]){
                    differenceCount++;
                }
                
                if(r != repeatedString.Length - 1){
                    i++;
                }
            }
        }
        
        return differenceCount;
    }

    static void Main(String[] args) {
        string s = Console.ReadLine();
        var repeatedString = "SOS";
        int result = RepeatedStringLetterDifferenceCount(s, repeatedString);
        Console.WriteLine(result);
    }
}
