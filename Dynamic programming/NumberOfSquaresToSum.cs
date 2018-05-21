public class Solution {
    /*
    Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.

    Example 1:

    Input: n = 12
    Output: 3 
    Explanation: 12 = 4 + 4 + 4.

    Example 2:

    Input: n = 13
    Output: 2
    Explanation: 13 = 4 + 9.
    */
    public int NumSquares(int n) {
        var result = new int[n + 1];
        var number = 1;
        var square = 1;
        while(square <= n){
            for(var i = square; i < result.Length; i++){
                if(result[i - square] + 1 < result[i] || result[i] == 0){
                     result[i] = result[i - square] + 1;
                }
            }
            
            number++;
            square = number * number;
        } 
        
        return result[n];
    }
}
