using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    
    static bool ContainsSubsequence(string s, string stringToMatch) {
        var matchIndex = 0;
        for(var i = 0; i < s.Length && matchIndex < stringToMatch.Length; i++){
            if(s[i] == stringToMatch[matchIndex]){
                matchIndex++;
            }
        }
        
        return matchIndex == stringToMatch.Length;
    }

    static void Main(String[] args) {
        int q = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < q; a0++){
            string s = Console.ReadLine();
            string stringToMatch = "somestring";
            bool result = ContainsSubsequence(s, stringToMatch);
            Console.WriteLine(result ? "YES" : "NO");
        }
    }
}
