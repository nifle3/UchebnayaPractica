namespace WpfApp1.Utils.Algorithm;

public static class Search
{
    public static int LevenshteinDistance(string s1, string s2)
    {
        if (string.IsNullOrEmpty(s1))
        {
            return string.IsNullOrEmpty(s2) ? 0 : s2.Length;
        }

        if (string.IsNullOrEmpty(s2))
        {
            return s1.Length;
        }

        var v0 = new int[s2.Length + 1];
        var v1 = new int[s2.Length + 1];

        v0 = v0.Select((idx, _) => idx).ToArray();
        
        for (var i = 0; i < s1.Length; i++)
        {
            v1[0] = i + 1;

            for (var j = 0; j < s2.Length; j++)
            {
                var cost = (s1[i] == s2[j]) ? 0 : 1;
                v1[j + 1] = Math.Min(Math.Min(v1[j] + 1, v0[j + 1] + 1), v0[j] + cost);
            }

            for (var j = 0; j < v0.Length; j++)
                v0[j] = v1[j];
        }

        return v1[s2.Length];
    }
}