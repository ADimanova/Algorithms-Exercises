public class Solution {
    /*
    The start is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).

    You can only move either down or right at any point in time. We are trying to reach the bottom-right corner of the grid.

    Now consider if some obstacles are added to the grids. How many unique paths would there be?
    
    Obstacles are marked with 1 in the matrix.
    */
    public int UniquePathsWithObstacles(int[,] obstacleGrid) {
        if(obstacleGrid.GetLength(0) == 0 || obstacleGrid.GetLength(1) == 0){
            return 0;
        }
        var pathCounts = new int[obstacleGrid.GetLength(0), obstacleGrid.GetLength(1)];
        
        var isFinish = true;
        for(var row = pathCounts.GetLength(0) - 1; row >= 0; row--){
            for(var col = pathCounts.GetLength(1) - 1; col >= 0; col--){
                if(obstacleGrid[row, col] != 1){
                    if(isFinish){
                        pathCounts[row, col] = 1;
                        isFinish = false;
                    }
                    else if(row == pathCounts.GetLength(0) - 1){
                        pathCounts[row, col] = pathCounts[row, col + 1];
                    }
                    else if(col == pathCounts.GetLength(1) - 1){
                        pathCounts[row, col] = pathCounts[row + 1, col];
                    }
                    else{
                        pathCounts[row, col] = pathCounts[row + 1, col] + pathCounts[row, col + 1];
                    }
                }
                else if(isFinish){
                    return 0;
                }
            }
        }
        
        return pathCounts[0, 0];
    }
}
