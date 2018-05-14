using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static int[] ComponentsInGraph(int[][] edges) {
        var disjointSet = new DisjointSet();
        
        for(var i = 0; i < edges.Length; i++){
            var nodeOne = edges[i][0];
            var nodeTwo = edges[i][1];
            
            disjointSet.MergeSets(nodeOne, nodeTwo);
        }
        
        var result = new int[2];
        result[0] = disjointSet.MinElementsCount(1);
        result[1] = disjointSet.MaxElementsCount();
        
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[][] gb = new int[n][];

        for (int gbRowItr = 0; gbRowItr < n; gbRowItr++) {
            gb[gbRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), gbTemp => Convert.ToInt32(gbTemp));
        }

        int[] result = ComponentsInGraph(gb);

        textWriter.WriteLine(string.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}

public class DisjointSet {
    private Dictionary<int, ParentCountPair> sets;
    private int maxSetCount;
    
    public DisjointSet(){
        sets = new Dictionary<int, ParentCountPair>();
    }
    
    public void MakeSet(int element){
        if(!sets.ContainsKey(element)){
            sets.Add(element, new ParentCountPair() { Parent = element, Count = 1 });
        }
    }
    
    public void MergeSets(int elementOne, int elementTwo){
        MakeSet(elementOne);
        MakeSet(elementTwo);
        
        var setOne = FindSet(elementOne);
        var setTwo = FindSet(elementTwo);
        
        if(setOne != setTwo){
            sets[setOne].Parent = setTwo;
            sets[setTwo].Count += sets[setOne].Count;
            sets[elementOne].Parent = setTwo;
            sets[elementTwo].Parent = setTwo;

            if(maxSetCount < sets[setTwo].Count) {
                maxSetCount = sets[setTwo].Count;
            }
        }        
    }                     
    
    private int FindSet(int element){
        if(sets[element].Parent == element){
            return element;
        }
        
        return FindSet(sets[element].Parent);
    }
    
    public int MaxElementsCount(){
        return maxSetCount;
    }
    
    public int MinElementsCount(int minThreshold){
        var min = int.MaxValue;
        foreach(var item in sets){
            if(item.Key == item.Value.Parent){
                if(min > item.Value.Count && item.Value.Count > minThreshold){
                    min = item.Value.Count;
                }
            }
        }
        
        return min;
    }
}

public class ParentCountPair { 
    public int Parent { get; set; }
    
    public int Count { get; set; }
}
