using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int minimumMoves(char[,] grid, int startX, int startY, int goalX, int goalY) {
        return RecurceGrid(grid, startX, startY, goalX, goalY);
    }    
    
    static int RecurceGrid(char[,] grid, int sX, int sY, int gX, int gY)
    {
        var size = grid.GetLength(0);
        var matrix = new int[size, size];
        var q = new Queue<Tuple<int, int>>();
        matrix[sX, sY] = 0;
        q.Enqueue(Tuple.Create<int, int>(sX, sY));
        
        while(q.Count > 0)
        {
            var el = q.Dequeue();
            var result = 0;
            result = Move(0, -1, el, q, matrix, grid, sX, sY, gX, gY);
            if(result > 0)
            {
                return result;
            }
            result = Move(-1, 0, el, q, matrix, grid, sX, sY, gX, gY);
            if(result > 0)
            {
                return result;
            }
            result = Move(0, 1, el, q, matrix, grid, sX, sY, gX, gY);
            if(result > 0)
            {
                return result;
            }
            result = Move(1, 0, el, q, matrix, grid, sX, sY, gX, gY);
            if(result > 0)
            {
                return result;
            }
        }
        
        return 0;
    }
    
    private static int Move(int rDir, int cDir, Tuple<int, int> el, Queue<Tuple<int, int>> q, int[,] matrix, char[,] grid, int sX, int sY, int gX, int gY)
    {
        var row = el.Item1 + rDir;
        var col = el.Item2 + cDir;
        var size = matrix.GetLength(0);
        
        while(row >= 0 && row < size &&
             col >= 0 && col < size &&
             grid[row, col] != 'X')
        {
            if(sX == col && sY == row)
            {
                break;
            }
            
            if(matrix[row, col] != 0)
            {
                row = row + rDir;
                col = col + cDir;
                continue;
            }
            
            matrix[row, col] = matrix[el.Item1, el.Item2] + 1;

            if(col == gX && row == gY)
            {
                return matrix[row, col];
            }
               
            q.Enqueue(Tuple.Create<int, int>(row, col));
            row = row + rDir;
            col = col + cDir;
        }
        
        return 0;
    }
    
    static void PrintMatrix(int[,] m)
    {
        var n = m.GetLength(0);
        for(var i = 0; i < n; i++)
        {
            for(var j = 0; j < n; j++)
            {
                Console.Write($"{m[i, j]} ");
            } 
            
            Console.WriteLine();
        }   
    }
    
    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine()); 
        char[,] grid = new char[n,n];
        for(var i = 0; i < n; i++)
        {
            var gridLine = Console.ReadLine().ToCharArray();
            for(var j = 0; j < n; j++)
            {
                grid[i, j] = gridLine[j];
            } 
        }       
        string[] tokens_startX = Console.ReadLine().Split(' ');
        int startX = Convert.ToInt32(tokens_startX[0]);
        int startY = Convert.ToInt32(tokens_startX[1]);
        int goalX = Convert.ToInt32(tokens_startX[3]);
        int goalY = Convert.ToInt32(tokens_startX[2]);
        int result = minimumMoves(grid, startX, startY, goalX, goalY);
        Console.WriteLine(result);
    }
}
