using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    /*
    A string is a pangram when it contains every letter of the alphabet.
    */
  
    static bool IsPangram(string s) {
        var foundCharCodes = new HashSet<int>();
        foundCharCodes.Add(-1);
        for(var i = 0; i < s.Length; i++){
            var code = GetCharCode(s[i]);
            foundCharCodes.Add(code);
            if(foundCharCodes.Count == 27){
                return true;
            }
        }
        
        return false;
    }
    
    static int GetCharCode(char c){
        var code = (int)c;
        if(code >= 97 && code <= 122){
            code -= 32;
        }
        
        if(code >= 65 && code <= 90){
            return code;
        }
        
        return -1;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        var result = IsPangram(s);

        textWriter.WriteLine(result ? "pangram" : "not pangram");

        textWriter.Flush();
        textWriter.Close();
    }
}
