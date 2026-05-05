public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var previousNumbers = new Dictionary<int, int>(nums.Length / 2);

        for (var i = 0; i < nums.Length; i++) {
            var remainingToTarget = target - nums[i];

            if (previousNumbers.TryGetValue(remainingToTarget, out var otherNumbersIndex))
                return [otherNumbersIndex, i];
            
            previousNumbers[nums[i]] = i;
        }

        return [-1, -1];  // should be impossible as per constraints
    }
}