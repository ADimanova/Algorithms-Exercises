public class Solution {
    /*
    Say you have an array for which the ith element is the price of a given stock on day i.

    Design an algorithm to find the maximum profit. You may complete at most k transactions.

    Note:
    You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).

    Example 1:

    Input: [2,4,1], k = 2
    Output: 2
    Explanation: Buy on day 1 (price = 2) and sell on day 2 (price = 4), profit = 4-2 = 2.

    Example 2:

    Input: [3,2,6,5,0,3], k = 2
    Output: 7
    Explanation: Buy on day 2 (price = 2) and sell on day 3 (price = 6), profit = 6-2 = 4.
                 Then buy on day 5 (price = 0) and sell on day 6 (price = 3), profit = 3-0 = 3.
    */
    public int MaxProfit(int k, int[] prices) {
        if(prices.Length < 2 || k < 1){
            return 0;
        }
        
        if(k > prices.Length / 2){
            return MaxProfitWithNoLimit(prices);
        }
        
        var resultMatrix = new int[2, prices.Length];
        
        for(var row = 1; row < k + 1; row++){
            var rowMax = int.MinValue;
            var indexRow = row % 2 == 0 ? 0 : 1;
            for(var col = 1; col < resultMatrix.GetLength(1); col++){
                var currentRowMax = resultMatrix[Math.Abs(indexRow - 1), col - 1] - prices[col - 1];
                if(rowMax < currentRowMax){
                    rowMax = currentRowMax;
                }
                
                resultMatrix[indexRow, col] = Math.Max(resultMatrix[indexRow, col - 1], prices[col] + rowMax);
            }
        }
        
        var resultRow = k % 2 == 0 ? 1 : 0;
        Console.WriteLine(resultMatrix[0, resultMatrix.GetLength(1) - 1]);
        Console.WriteLine(resultMatrix[1, resultMatrix.GetLength(1) - 1]);
        return resultMatrix[Math.Abs(resultRow - 1), resultMatrix.GetLength(1) - 1];
    }
    
    private int MaxProfitWithNoLimit(int[] prices){
        var max = 0;
        for(var i = 1; i < prices.Length; i++){
            if(prices[i] > prices[i - 1]){
                max += prices[i] - prices[i - 1];
            }
        }
        
        return max;
    }
}
