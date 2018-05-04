using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    /*
    Split the string in half. If the halves are not the same size, return -1. 
    Count the number of changes that have to be made to one of the strings, so the two strings become anagrams of eachother.
    */

    static int ChangesToMakeAnagram(string s1, string s2){
        if (s1.Length != s2.Length){
            return -1;
        }
        
        var chars1 = new Dictionary<char, int>();
        var chars2 = new Dictionary<char, int>();
        for(var i = 0; i < s1.Length; i++){
            if(!chars1.ContainsKey(s1[i])){
                chars1[s1[i]] = 0;
            }
            
            if(!chars2.ContainsKey(s2[i])){
                chars2[s2[i]] = 0;
            }
            
            chars1[s1[i]]++;
            chars2[s2[i]]++;
        }
        
        var matchingChars = 0;
        foreach(var pair in chars1){
            if(chars2.ContainsKey(pair.Key)){
                if(pair.Value > chars2[pair.Key]){
                    matchingChars += chars2[pair.Key];
                }
                else if (pair.Value <= chars2[pair.Key]){
                    matchingChars += pair.Value;
                }
            }
        }
        
        return s1.Length - matchingChars;
    }
    
    static string[] SplitInHalf(string s){
        if(s.Length % 2 != 0){
            return null;
        }
        
        var result = new string[2];
        result[0] = s.Substring(0, s.Length / 2);
        result[1] = s.Substring(s.Length / 2);
        
        return result;
    }

    static void Main(String[] args) {
        int q = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < q; a0++){
            string s = Console.ReadLine();
            var split = SplitInHalf(s);
            if (split == null){
                Console.WriteLine(-1);
            }
            else{
                int result = ChangesToMakeAnagram(split[0], split[1]);
                Console.WriteLine(result);
            }
        }
    }
}
