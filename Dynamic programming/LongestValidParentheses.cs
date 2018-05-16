public class Solution {
    public int LongestValidParentheses(string s) {
        var longest = 0;
        var results = new int[s.Length];
        
        var stack = new Stack<int>();
        for(var i = 0; i < s.Length; i++){
            if(s[i] == '('){
                stack.Push(i);
            }
            else{
                if(stack.Count > 0){
                    var lastIndex = stack.Pop();
                    results[i] = results[i - 1] + 2;
                    if(lastIndex != 0){
                        results[i] += results[lastIndex - 1];
                    }
                    
                    if(longest < results[i]){
                        longest = results[i];
                    }
                }
            }
        }
        
        return longest;
    }
}
