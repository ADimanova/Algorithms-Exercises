using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        var n = int.Parse(Console.ReadLine());
        var dict = new Dictionary<string, int>();
        for(var i = 0; i < n; i++){
            var str = Console.ReadLine();
            if(!dict.ContainsKey(str)){
                dict[str] = 0;
            }
            
            dict[str]++;
        }
        
        var operations = int.Parse(Console.ReadLine());
        for(var i = 0; i < operations; i++){
            var query = Console.ReadLine();
            if(dict.ContainsKey(query)){
                Console.WriteLine(dict[query]);        
            }
            else{
                Console.WriteLine(0);
            }
        }
    }
}
