using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
class Solution {
    
    public static List<char> Alphabet { get; set; }

    static int SherlockAndAnagrams(string s){
        var anagramCount = 0;
        var charCounts = GetEmptyAlphabetDictionary();
        var anagramCountMap = new Dictionary<string, int>();
        
        for(var length = 0; length < s.Length - 1; length++){
            for(var i = 0; i + length < s.Length; i++){
                if(i == 0){
                    for(var k = i; k + length < s.Length; k++){
                        charCounts[s[k]]++;
                    }
                }
                else{
                    charCounts[s[i - 1]]--;
                    charCounts[s[i + length]]++;
                }
                
                var key = SerializeDictionary(charCounts);
                if(!anagramCountMap.ContainsKey(key)){
                    anagramCountMap[key] = 0;
                }

                anagramCount += anagramCountMap[key];
                anagramCountMap[key]++;
            }
            
            ResetDictionary(charCounts);
        }
        
        
        return anagramCount;
    }
    
    static Dictionary<char, int> GetEmptyAlphabetDictionary(){
        var alphabetDictionary = new Dictionary<char, int>(){
            { 'a', 0 },
            { 'b', 0 },
            { 'c', 0 },
            { 'd', 0 },
            { 'e', 0 },
            { 'f', 0 },
            { 'g', 0 },
            { 'h', 0 },
            { 'i', 0 },
            { 'j', 0 },
            { 'k', 0 },
            { 'l', 0 },
            { 'm', 0 },
            { 'n', 0 },
            { 'o', 0 },
            { 'p', 0 },
            { 'q', 0 },
            { 'r', 0 },
            { 's', 0 },
            { 't', 0 },
            { 'u', 0 },
            { 'v', 0 },
            { 'w', 0 },
            { 'x', 0 },
            { 'y', 0 },
            { 'z', 0 }
        };
        
        return alphabetDictionary;
    }
    
    static void ResetDictionary(Dictionary<char, int> alphabetDictionary){
        if(Alphabet == null){
            Alphabet = alphabetDictionary.Keys.ToList();
        }
        
        foreach(var key in Alphabet){
            alphabetDictionary[key] = 0;
        }
    }
    
    static string SerializeDictionary(Dictionary<char, int> alphabetDictionary){
        var sb = new StringBuilder(20);
        foreach(var pair in alphabetDictionary){
            if(pair.Value != 0){
                sb.Append($"{pair.Key}:{pair.Value}");
            }
        }
        
        return sb.ToString();
    }

    static void Main(String[] args) {
        int q = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < q; a0++){
            string s = Console.ReadLine();
            int result = SherlockAndAnagrams(s);
            Console.WriteLine(result);
        }
    }
}
