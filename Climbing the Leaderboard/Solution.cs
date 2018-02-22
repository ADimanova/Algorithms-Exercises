using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static int[] climbingLeaderboard(int[] scores, int[] alice) {
        var ranking = new Dictionary<int, int>();
        var positions = new Queue<int>();
        var levelsCount = 0;
        var aInd = 0;
        var aScore = alice[aInd];   
        for(var i = scores.Length - 1; i >= 0; i--)
        {
            // add all current ranking to dictionary
            // that stores which rack corresponds to what score
            if(!ranking.ContainsKey(scores[i])) 
            {
                ranking.Add(scores[i], ++levelsCount);
                
                while(scores[i] >= aScore && aInd < alice.Length)
                {
                    // for each position of Alice add the index of the 
                    // score that precedes it in scores
                    positions.Enqueue(i);
                    aInd++;
                    if(aInd < alice.Length)
                    {
                        aScore = alice[aInd];
                    }                   
                }
            }            
        }
        
        //handle case when Alice ranks 1st over multiple levels
        aInd--;
        while(aInd < alice.Length - 1)
        {         
            positions.Enqueue(-1);
            aInd++;            
        }
        
        var result = new int[positions.Count];
        var resIndx = 0;
        while(positions.Count > 0)
        {
            var pos = positions.Dequeue(); 
            if(pos == -1)
            {
                result[resIndx] = 1; 
                resIndx++;
                continue;
            }
            
            var prev = scores[pos];
            var rank = ranking[prev];
            if(prev == alice[resIndx])
            {
                // since ranking saves levels backward
                // we have to calculate the actual level
                var currentlevel = levelsCount - (rank - 1);
                result[resIndx] = currentlevel;
            }
            else 
            {
                var currentlevel = (levelsCount - (rank - 1)) + 1;
                result[resIndx] = currentlevel;
            }
            
            resIndx++;
        }

        return result;
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] scores_temp = Console.ReadLine().Split(' ');
        int[] scores = Array.ConvertAll(scores_temp,Int32.Parse);
        int m = Convert.ToInt32(Console.ReadLine());
        string[] alice_temp = Console.ReadLine().Split(' ');
        int[] alice = Array.ConvertAll(alice_temp,Int32.Parse);
        int[] result = climbingLeaderboard(scores, alice);
        Console.WriteLine(String.Join("\n", result));
    }
}
