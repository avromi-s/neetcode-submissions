public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var counts = new Dictionary<int, int>();

        foreach (var num in nums) {
            counts[num] = counts.TryGetValue(num, out var value) ? value + 1 : 1;
        }

        return GetKeysForTopKValues(counts, k);
    }

    private int[] GetKeysForTopKValues(Dictionary<int, int> counts, int k) {
        var keys = new int[k];

        for (var i = 0; i < keys.Length; i++) {
            var num = Int32.MinValue;
            var max = Int32.MinValue;

            foreach (var entry in counts) {
                if (entry.Value <= max) continue;

                num = entry.Key;
                max = entry.Value;
            }

            keys[i] = num;
            counts.Remove(num);
        }

        return keys;
    }
}
