public class Solution {
    /*
    Given a triangle, find the minimum path sum from top to bottom. Each step you may move to adjacent numbers on the row below.

    For example, given the following triangle

    [
         [2],
        [3,4],
       [6,5,7],
      [4,1,8,3]
    ]

    The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).
    */
    public int MinimumTotal(IList<IList<int>> triangle) {
        if(triangle.Count == 0){
            return 0;
        }
        
        if(triangle.Count == 1){
            return triangle[0][0];
        }
        
        var bestPrevious = new int[triangle.Count];
        bestPrevious[0] = triangle[0][0];
        
        var minTotal = int.MaxValue;
        for(var row = 1; row < triangle.Count; row++){
            for(var col = triangle[row].Count - 1; col >= 0; col--){
                if(col == triangle[row].Count - 1){
                    bestPrevious[col] = triangle[row][col] + bestPrevious[col - 1];
                }
                else if(col == 0){
                    bestPrevious[col] = triangle[row][col] + bestPrevious[col];
                }
                else{
                    bestPrevious[col] = triangle[row][col] + Math.Min(bestPrevious[col - 1], bestPrevious[col]);
                }
                
                if(row == triangle.Count - 1 && bestPrevious[col] < minTotal){                    
                    minTotal = bestPrevious[col]; 
                }
            }            
        }
        
        return minTotal;
    }
}
