public class Solution {
    /*
    Say you have an array for which the ith element is the price of a given stock on day i.

    Design an algorithm to find the maximum profit. You may complete at most two transactions.

    Note: You may not engage in multiple transactions at the same time (i.e., you must sell the stock before you buy again).
    */
    public int MaxProfit(int[] prices) {
        return MaxProfit(prices, 2);
    }
    
    public int MaxProfit(int[] prices, int transactions){
        if(prices.Length < 2){
            return 0;
        }
        
        var resultMatrix = new int[transactions + 1, prices.Length];
        
        for(var row = 1; row < resultMatrix.GetLength(0); row++){
            var maxPrevious = int.MinValue;
            for(var col = 1; col < resultMatrix.GetLength(1); col++){
                var withoutTransacting = resultMatrix[row, col - 1];
                var current = (prices[col - 1] * -1) + resultMatrix[row - 1, col - 1];
                maxPrevious = maxPrevious > current ? maxPrevious : current;
                
                resultMatrix[row, col] = Math.Max(maxPrevious + prices[col], withoutTransacting);
            }
        }
        
        return resultMatrix[transactions, prices.Length - 1];
    }
}
