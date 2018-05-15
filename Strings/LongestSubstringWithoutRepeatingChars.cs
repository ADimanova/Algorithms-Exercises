public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if(string.IsNullOrEmpty(s)){
            return 0;
        }
        
        var maxCount = 1;
        var currentCount = 1;
        var lastStartIndex = 0;
        var metChars = new HashSet<char>();
        metChars.Add(s[0]);
        for(var i = 1; i < s.Length; i++){
            if(metChars.Contains(s[i])){                
                var k = lastStartIndex;
                while(k < i && s[i] != s[k]){
                    metChars.Remove(s[k]);
                    currentCount--;
                    k++;
                }
                
                lastStartIndex = k + 1;
            }
            else{
                metChars.Add(s[i]);
                currentCount++;
                
                if(maxCount < currentCount){
                    maxCount = currentCount;
                }                
            }
        }
        
        return maxCount;
    }
}
