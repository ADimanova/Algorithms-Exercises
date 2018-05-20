/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    /*
    You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

    You may assume the two numbers do not contain any leading zero, except the number 0 itself.

    Example

    Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
    Output: 7 -> 0 -> 8
    Explanation: 342 + 465 = 807.

    */
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var num1 = new Stack<int>();
        var num2 = new Stack<int>();
        
        while(l1 != null || l2 != null){
            if(l1 != null){
                num1.Push(l1.val);
                l1 = l1.next;
            }
            
            if(l2 != null){
                num2.Push(l2.val);
                l2 = l2.next;
            }
        }
        
        var actualNum1 = System.Numerics.BigInteger.Parse(string.Join("", num1));
        var actualNum2 = System.Numerics.BigInteger.Parse(string.Join("", num2));
        
        var result = actualNum1 + actualNum2;
        
        var resultAsString = result.ToString();
        var length = resultAsString.Length;
        var root = new ListNode((int)Char.GetNumericValue(resultAsString[length - 1]));
        
        var current = root;
        for(var i = length - 2; i >= 0; i--){
            var next = new ListNode((int)Char.GetNumericValue(resultAsString[i]));
            current.next = next;
            current = next;
        }
        
        return root;
    }
}
