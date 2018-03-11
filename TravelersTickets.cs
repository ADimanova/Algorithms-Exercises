using System;
using System.Collections.Generic;
using System.IO;

class Solution {
    // You are given a bunch of tickets a traveler used for one of his travels. 
    // Print the towns he visited in hronological order.

    static void Main(String[] args) {       
        var input = new string[] { "Plovdiv:Varna", "Burgas:Ruse", "Varna:Burgas", "Sofia:Plovdiv" };
        var destinations = new HashSet<string>();
        var towns = new Dictionary<string, string>();
        
        for(var i = 0; i < input.Length; i++)
        {
            var parts = input[i].Split(':');
            destinations.Add(parts[1]);
            towns.Add(parts[0], parts[1]);
        }
        
        var result = new List<string>(input.Length + 1);
        foreach(var town in towns)
        {
            if(!destinations.Contains(town.Key))
            {
                var source = town.Key;
                while(towns.ContainsKey(source))
                {                                
                    result.Add(source);
                    source = towns[source];
                }
                
                result.Add(source);
                
                break;
            }
        }
        
        Console.WriteLine(string.Join(" -> ", result));
    }
}
