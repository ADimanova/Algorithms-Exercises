using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Solution {

    static void SeparateNumbers(string s) {
        long startNumber = -1;
        var isValid = false;
        var middle = s.Length / 2;
        for(var i = 1; i <= middle; i++){
            var first = long.Parse(s.Substring(0, i));
            startNumber = first;
            var sb = new StringBuilder();
            sb.Append(first);
            while(sb.Length < s.Length){
                first++;
                sb.Append(first);
                if(sb.Length == s.Length && sb.ToString() == s){
                    isValid = true;
                    break;
                }
            }
            
            if(isValid){
                Console.WriteLine("YES " + startNumber);
                return;
            }
        }
        
        Console.WriteLine("NO");
    }

    static void Main(String[] args) {
        int q = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < q; a0++){
            string s = Console.ReadLine();
            SeparateNumbers(s);
        }
    }
}
