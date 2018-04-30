using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int CountWordsInCamelCase(string s) {
        int count = 0;
        if(s.Length == 0){
            return count;
        }
        
        count++;
        for(var i = 0; i < s.Length; i++){
            var currentCharCode = (int)s[i];
            if(currentCharCode >= 65 && currentCharCode <= 90){
                count++;
            }
        }
        
        return count;
    }

    static void Main(String[] args) {
        string s = Console.ReadLine();
        int result = CountWordsInCamelCase(s);
        Console.WriteLine(result);
    }
}
