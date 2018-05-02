using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int RemoveToGetPalindromeIndex(string s){
        var index = -1;
        
        var front = 0;
        var back = s.Length - 1;
        
        while(front < back){
            if(s[front] == s[back]){
                front++;
                back--;
            }
            else if(index != -1){
                return -1;
            }
            else{
                if(s[front] == s[back - 1] && s[back] == s[front + 1]){
                    var lookAheadIndex = 0;
                    while(true){
                        if(s[front + lookAheadIndex] != s[back - lookAheadIndex - 1]){
                            index = front;
                            front++;
                            break;
                        }
                        else if (s[front + lookAheadIndex + 1] != s[back - lookAheadIndex]){
                            index = back;
                            back--; 
                            break;
                        }
                        
                        lookAheadIndex++;
                    }
                }    
                else if(s[front] == s[back - 1]){
                    index = back;
                    back--;
                }
                else if(s[back] == s[front + 1] || back == front + 1){
                    index = front;
                    front++;
                }
                else{
                    return -1;
                }
            }
        }
        
        return index;
    }

    static void Main(String[] args) {
        int q = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < q; a0++){
            string s = Console.ReadLine();
            int result = RemoveToGetPalindromeIndex(s);
            Console.WriteLine(result);
        }
    }
}
