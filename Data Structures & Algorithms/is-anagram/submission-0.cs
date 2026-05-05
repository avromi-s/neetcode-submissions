public class Solution {
    // Count how many of each lowercase letter occurs in each string, 
    // using an array index to correspond to each letter. 
    // If both strings have the same amount of all letters and the same length,
    // they are anagrams.

    private const int ALPHABET_LENGTH = 26;

    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) return false;

        var letterCounts = new int[ALPHABET_LENGTH];

        foreach (var letter in s) 
            letterCounts[GetAlphabetIndex(letter)]++;

        foreach (var letter in t)
            if (--letterCounts[GetAlphabetIndex(letter)] < 0)
                return false;
        
        return true;
    }

    private static int GetAlphabetIndex(char c) {
        return c - 97;
    }
}