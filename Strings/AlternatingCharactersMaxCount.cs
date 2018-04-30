using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    /* 
    Given a string with characters, find a combination of two characters that, after removing all other characters from the string
    provide a string with alternating characters (abab for example). Print the maximum possible length for such two characters in the string.
    */
    static int AlternatingCharacterStringCount(string s) {
        var viableMap = new Dictionary<char, bool>();
        var indexMap = new Dictionary<char, List<int>>();
        
        for(var i = 0; i < s.Length; i++){
            var current = s[i];
            if(!viableMap.ContainsKey(current)){
                viableMap.Add(current, true);
                indexMap.Add(current, new List<int>());
            }
            
            if(viableMap[current]){
                if(indexMap[current].Count > 0){
                    var prevIndex = indexMap[current][indexMap[current].Count - 1];
                    if(prevIndex == i - 1){
                        viableMap[current] = false;
                    }
                    else{
                        indexMap[current].Add(i);
                    }
                }
                else{
                    indexMap[current].Add(i);
                }
            }
        }
        
        var viableCharacters = viableMap.Where(c => c.Value).Select(c => c.Key).ToArray();
        
        return GetMaxCount(viableCharacters, indexMap);    
    }
    
    static int GetMaxCount(char[] viableCharacters, Dictionary<char, List<int>> indexMap){
        var maxCount = 0;
        for(var i = 0; i < viableCharacters.Length; i++){
            var current = viableCharacters[i];
            for(var k = i + 1; k < viableCharacters.Length; k++){
                var possible = viableCharacters[k];                
                
                if(indexMap[current].Count + indexMap[possible].Count <= maxCount){
                    continue;
                }
                
                var lengthDifference = Math.Abs(indexMap[current].Count - indexMap[possible].Count);
                if(lengthDifference <= 1){                    
                    var large = indexMap[current];
                    var small = indexMap[possible];
                    if(large.Count < small.Count){
                        var swapTemp = large;
                        large = small;
                        small = swapTemp;
                    }
                    
                    var isViableCombination = true;
                    var largerFirst = large[0] < small[0];     
                    if(!largerFirst && lengthDifference != 0){
                        continue;
                    }
                    
                    for(var h = 1; h < large.Count; h++){
                        if(h != small.Count){
                            if(true){
                                if((large[h - 1] > small[h - 1] || large[h] < small[h - 1] || large[h] > small[h]) == largerFirst){
                                    isViableCombination = false;
                                    break;
                                }
                            }
                        }
                        else{
                            if(!(large[h] > small[h - 1] && large[h - 1] < small[h - 1])){
                                isViableCombination = false;
                                break;
                            }
                        }
                    }
                    
                    if(isViableCombination) {
                        maxCount = large.Count + small.Count;
                    }
                }
            }
        }
        
        return maxCount;
    }

    static void Main(String[] args) {
        int l = Convert.ToInt32(Console.ReadLine());
        string s = Console.ReadLine();
        int result = AlternatingCharacterStringCount(s);
        Console.WriteLine(result);
    }
}
