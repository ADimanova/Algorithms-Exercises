using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    /*
    Create a copy of the string in reverse e.g. abc > cba
    Iterating through each string, compare the absolute difference in the ascii values of the characters 
    at positions 0 and 1, 1 and 2 and so on to the end. 
    If the list of absolute differences is the same for both pairs in the strings, for the entire string return true.
    */
    static bool HasSameReverseAbsoluteDifferences(string s){
        var normalDiffSum = 0;
        var isSame = true;
        for(var i = 1; i < s.Length; i++){
            if(Math.Abs(s[i] - s[i - 1]) != Math.Abs(s[s.Length - i] - s[s.Length - i - 1])){
                isSame = false;
                break;
            }
        }
        
        return isSame;
    }

    static void Main(String[] args) {
        int q = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < q; a0++){
            string s = Console.ReadLine();
            bool result = HasSameReverseAbsoluteDifferences(s);
            Console.WriteLine(result);
        }
    }
}
