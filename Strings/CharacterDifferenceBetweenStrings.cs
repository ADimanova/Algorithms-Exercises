using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int DifferenceCount(string s1, string s2){
        var s1OccurenceMap = new Dictionary<char, int>();
        var s2OccurenceMap = new Dictionary<char, int>();
        
        var minLength = s1.Length > s2.Length ? s2.Length : s1.Length;
        for(var i = 0; i < minLength; i++){
            if(!s1OccurenceMap.ContainsKey(s1[i])){
                s1OccurenceMap.Add(s1[i], 0);
            }
            
            if(!s2OccurenceMap.ContainsKey(s2[i])){
                s2OccurenceMap.Add(s2[i], 0);
            }
            
            s1OccurenceMap[s1[i]]++;
            s2OccurenceMap[s2[i]]++;
        }
        
        var largerStringMap = s1.Length > s2.Length ? s1OccurenceMap : s2OccurenceMap;
        var largerString = s1.Length > s2.Length ? s1 : s2;
        
        for(var i = minLength; i < largerString.Length; i++){
            if(!largerStringMap.ContainsKey(largerString[i])){
                largerStringMap.Add(largerString[i], 0);
            }
            
            largerStringMap[largerString[i]]++;
        }
        
        return GetDictionaryDifferenceCount(s1OccurenceMap, s2OccurenceMap);
    }
    
    static int GetDictionaryDifferenceCount(Dictionary<char, int> map1, Dictionary<char, int> map2){
        var count = 0;
        var countedSet = new HashSet<char>();
        foreach(var item in map1) {
            if(!map2.ContainsKey(item.Key)){
                count += map1[item.Key];
            }
            else{
                count += Math.Abs(map1[item.Key] - map2[item.Key]);
                countedSet.Add(item.Key);
            }
        }
        
        foreach(var item in map2){
            if(countedSet.Contains(item.Key)){
                continue;
            }
            
            if(!map1.ContainsKey(item.Key)){
                count += map2[item.Key];
            }
            else{
                count += Math.Abs(map1[item.Key] - map2[item.Key]);
            }
        }
        
        return count;
    }

    static void Main(String[] args) {
        string s1 = Console.ReadLine();
        string s2 = Console.ReadLine();
        int result = DifferenceCount(s1, s2);
        Console.WriteLine(result);
    }
}
