using System;
using System.Collections.Generic;
using System.IO;

class Solution {
    static void Main(String[] args)
    {
        // there is a bug in the code; to be finished      
        int[,] graph =  {
                { 0, 6, 0, 0, 0, 0, 0, 9, 0 },
                { 6, 0, 9, 0, 0, 0, 0, 11, 0 },
                { 0, 9, 0, 5, 0, 6, 0, 0, 2 },
                { 0, 0, 5, 0, 9, 16, 0, 0, 0 },
                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                { 0, 0, 6, 0, 10, 0, 2, 0, 0 },
                { 0, 0, 0, 16, 0, 2, 0, 1, 6 },
                { 9, 11, 0, 0, 0, 0, 1, 0, 5 },
                { 0, 0, 2, 0, 0, 0, 6, 5, 0 }
                };

        var distances = DijkstraAlgo(graph, 0, 9);  
        //PrintDistances(distances);
    }
    
    public static void PrintDistances(int[] distances)
    {
        for(var d = 0; d < distances.Length; d++)
        {           
            Console.WriteLine($"Distance to vertex {d}: {distances[d]}");
        }
    }
    
    public static int[] DijkstraAlgo(int[,] graph, int source, int vertexesCount)
    {
        var distances = new int[vertexesCount];
        var traversedNodes = new bool[vertexesCount];
        
        for(var i = 0; i < vertexesCount; i++)
        {
            distances[i] = int.MaxValue;
        }
        
        distances[source] = 0;
        
        for(var i = 0; i < vertexesCount; i++)
        {
            var sourceIndex = MinDistance(distances, traversedNodes, vertexesCount);
            traversedNodes[sourceIndex] = true;

            for(var destIndex = 0; destIndex < vertexesCount; destIndex++)
            {
                if(!traversedNodes[destIndex] && graph[sourceIndex, destIndex] != 0 &&
                   distances[sourceIndex] != int.MaxValue &&
                   distances[destIndex] > distances[sourceIndex] + graph[sourceIndex, destIndex])
                {
                    distances[destIndex] = distances[sourceIndex] + graph[sourceIndex, destIndex];
                }
            }
            
            PrintDistances(distances);
            Console.WriteLine();
        }
        
        return distances;
    }
    
    public static int MinDistance(int[] distances, bool[] traversedNodes, int vertexesCount)
    {
        var minValue = int.MaxValue;
        int minIndex = 0;
        for(var i = 0; i < vertexesCount; i++)
        {
            if(!traversedNodes[i] && distances[i] < minValue)
            {
                minIndex = i;
                minValue = distances[0];
            }             
        }
               
        return minIndex;
    }
}      
