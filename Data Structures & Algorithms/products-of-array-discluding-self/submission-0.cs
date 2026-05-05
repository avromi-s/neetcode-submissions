public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var result = new int[nums.Length];

        var forwardRunningProduct = 1;
        for (var i = 0; i < nums.Length - 1; i++) {
            forwardRunningProduct = forwardRunningProduct * nums[i];
            result[i] = forwardRunningProduct;
        }

        var reverseRunningProduct = 1;
        for (var i = nums.Length - 1; i > 0; i--) {
            result[i] = reverseRunningProduct * result[i - 1];
            reverseRunningProduct = reverseRunningProduct * nums[i];
        }
        result[0] = reverseRunningProduct;

        return result;
    }
}
