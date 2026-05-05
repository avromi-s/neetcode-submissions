public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var counts = new Dictionary<int, int>();
        foreach (var num in nums) {
            counts[num] = counts.TryGetValue(num, out var count) ? count + 1 : 1;
        }

        var buckets = new List<int>[nums.Length + 1];
        foreach (var entry in counts) {
            if (buckets[entry.Value] is null)
                buckets[entry.Value] = new List<int>();
            
            buckets[entry.Value].Add(entry.Key);
        }

        var topKFrequent = new List<int>(k);
        for (var i = buckets.Length - 1; i > 0 && topKFrequent.Count < k; i--) {
            if (buckets[i] is null) continue;

            for (var j = 0; j < buckets[i].Count && topKFrequent.Count < k; j++) {
                topKFrequent.Add(buckets[i][j]);
            }
        }

        return topKFrequent.ToArray();
    }
}