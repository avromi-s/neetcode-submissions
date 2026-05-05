public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        var anagramGroups = new Dictionary<string, List<string>>();

        foreach (var word in strs) {
            var representation = GetCharFrequencyRepresentation(word);

            if (anagramGroups.TryGetValue(representation, out var wordList))
                anagramGroups[representation].Add(word);
            else
                anagramGroups[representation] = [word];
        }

        return anagramGroups.Values.ToList();
    }

    private static readonly char[] ALPHABET_LETTER =
        ['a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'];

    private static string GetCharFrequencyRepresentation(string str) {
        var sb = new StringBuilder();

        foreach (var alphabetLetter in ALPHABET_LETTER) {
            var count = 0;

            foreach (var strLetter in str) {
                if (alphabetLetter == strLetter)
                    count++;
            }

            sb.Append(alphabetLetter);
            sb.Append(count);
        }

        return sb.ToString();
    }
}
