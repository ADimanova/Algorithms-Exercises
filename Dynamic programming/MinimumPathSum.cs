public class Solution {
    /*
    Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.

    Note: You can only move either down or right at any point in time.
    */
    public int MinPathSum(int[,] grid) {
        if(grid.GetLength(0) == 0 || grid.GetLength(0) == 0){
            return 0;
        }
        
        var resultMatrix = new int[grid.GetLength(0), grid.GetLength(1)];
        
        for(var row = 0; row < grid.GetLength(0); row++){
            for(var col = 0; col < grid.GetLength(1); col++){
                resultMatrix[row, col] = grid[row, col]; 
                
                if(row == 0 && col != 0){
                    resultMatrix[row, col] += resultMatrix[row, col - 1];                 
                }
                else if(col == 0 && row != 0){
                    resultMatrix[row, col] += resultMatrix[row - 1, col];
                }
                else if (row != 0 && col != 0) {
                    resultMatrix[row, col] += Math.Min(resultMatrix[row, col - 1], resultMatrix[row - 1, col]);
                }
            }
        }
        
        return resultMatrix[resultMatrix.GetLength(0) - 1, resultMatrix.GetLength(1) - 1];
    }
}
