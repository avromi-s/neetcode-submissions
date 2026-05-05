public class Solution {

    // format - length:stringlength:string
    // e.g.,: ["abc", "abdef"] -> 3:abc5:abdef

    private const char STRING_START_DELIMITER = ':';

    public string Encode(IList<string> strs) {
        var encoded = new StringBuilder();

        foreach (var str in strs) {
            encoded.Append(str.Length);
            encoded.Append(STRING_START_DELIMITER);
            encoded.Append(str);
        }

        return encoded.ToString();
    }

    public List<string> Decode(string s) {
        var strs = new List<string>();

        var i = 0;
        while (i < s.Length) {
            var currentStrLength = ConsumeStringLengthMarker(s, ref i);
            var str = ConsumeString(s, currentStrLength, ref i);
            strs.Add(str);
        }

        return strs;
    }

    private int ConsumeStringLengthMarker(string s, ref int startIndex) {
        var buffer = "";
        while (s[startIndex] != STRING_START_DELIMITER) {
            buffer += s[startIndex++];
        }

        startIndex++;  // move past delimiter
        return Int32.Parse(buffer);
    }

    private string ConsumeString(string s, int length, ref int startIndex) {
        var sb = new StringBuilder(length);
        for (var j = 0; j < length; j++) {
            sb.Append(s[startIndex++]);
        }
        
        return sb.ToString();
    }
}
