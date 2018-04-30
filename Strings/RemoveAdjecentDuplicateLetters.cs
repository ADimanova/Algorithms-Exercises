using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Solution {

    static string RemoveDuplicateAdjacentLetters(string s){
        var sb = new StringBuilder();
        var changesCount = 1;
        while(changesCount != 0){
            changesCount = 0;
            for(var i = 1; i < s.Length; i++){
                if(s[i] == s[i - 1]){
                    i++;
                    changesCount++;
                    if(i + 1 == s.Length){
                        sb.Append(s[i]);
                    }
                }
                else{
                    sb.Append(s[i - 1]);
                    if(i == s.Length - 1){
                        sb.Append(s[i]);
                    }
                }
            }
            
            s = sb.ToString();
            sb.Clear();
        }
                
        return s;
    }
    
    static void Main(String[] args) {
        string s = Console.ReadLine();
        string result = RemoveDuplicateAdjacentLetters(s);
        Console.WriteLine(string.IsNullOrEmpty(result) ? "Empty String" : result);
    }
}
