using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {

    static bool[] WeightedUniformStrings(string s, int[] queries) {
        var weightSet = GetWeightedSet(s);
        Console.WriteLine(string.Join(" ", weightSet));
        var resultArr = new bool[queries.Length];
        for(var i = 0; i < queries.Length; i++){
            if(weightSet.Contains(queries[i])){
                resultArr[i] = true;
            }
        }
        
        return resultArr;
    }
    
    static HashSet<int> GetWeightedSet(string s){
        var weightSet = new HashSet<int>();
        for(var i = 1; i <= s.Length; i++){
            var uniformWeight = s[i - 1] - 'a' + 1;
            weightSet.Add(uniformWeight);
            while(i < s.Length && s[i] == s[i - 1]){
                uniformWeight += s[i] - 'a' + 1;                
                weightSet.Add(uniformWeight);
                i++;
            }
        }
        
        return weightSet;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        int queriesCount = Convert.ToInt32(Console.ReadLine());

        int[] queries = new int [queriesCount];

        for (int queriesItr = 0; queriesItr < queriesCount; queriesItr++) {
            int queriesItem = Convert.ToInt32(Console.ReadLine());
            queries[queriesItr] = queriesItem;
        }

        bool[] result = WeightedUniformStrings(s, queries);

        var yesNoResult = result.Select(c => c ? "Yes" : "No");
        textWriter.WriteLine(string.Join("\n", yesNoResult));

        textWriter.Flush();
        textWriter.Close();
    }
}
