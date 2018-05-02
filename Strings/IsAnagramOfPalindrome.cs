using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static bool CanBePalindrome(string s){
        var chars = new HashSet<char>();
        var charWithoutPairCount = 0;
        
        for(var i = 0; i < s.Length; i++){
            if(!chars.Contains(s[i])){
                charWithoutPairCount++;
                chars.Add(s[i]);
            }
            else{
                charWithoutPairCount--;
                chars.Remove(s[i]);
            }
        }
        
        var isOdd = s.Length % 2 != 0;
        if(isOdd){
            return charWithoutPairCount == 1;
        }
        
        return charWithoutPairCount == 0;
    }

    static void Main(String[] args) {
        string s = Console.ReadLine();
        var result = CanBePalindrome(s);
        Console.WriteLine(result ? "YES" : "NO");
    }
}
