public class Solution {
    /*
    Given a sorted array and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

    You may assume no duplicates in the array.
    */
    public int SearchInsert(int[] nums, int target) {
        return BinarySearch(0, nums.Length - 1, nums, target);
    }
    
    private int BinarySearch(int left, int right, int[] nums, int target){
        var mid = left + ((right - left) / 2);
        if(nums[mid] == target){
            return mid;
        }
        
        if(nums[left] > target){
            return left;
        }
        
        if(nums[right] < target){
            return right + 1;
        }
        
        if(nums[mid] < target){
            return BinarySearch(mid + 1, right, nums, target);
        }
        else{
            return BinarySearch(left, mid - 1, nums, target);
        }
    }
}
