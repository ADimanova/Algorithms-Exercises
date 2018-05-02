using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    /*
    You are given a string containing characters and only. 
    Your task is to change it into a string such that every two consecutive characters are different. 
    To do this, you are allowed to delete one or more characters in the string.
    Your task is to find the minimum number of required deletions.
    */
    static int ConsecutiveSameCharacterCount(string s){
        var count = 0;
        for(var i = 1; i < s.Length; i++){
            if(s[i] == s[i - 1]){
                count++;
            }
        }
        
        return count;
    }

    static void Main(String[] args) {
        int q = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < q; a0++){
            string s = Console.ReadLine();
            int result = ConsecutiveSameCharacterCount(s);
            Console.WriteLine(result);
        }
    }
}
