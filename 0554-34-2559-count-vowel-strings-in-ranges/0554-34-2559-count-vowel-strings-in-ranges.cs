public class Solution {
    public int[] VowelStrings(string[] words, int[][] queries) {
        int n = words.Length;
        int[] prefix = new int[n];
        int sum=0;
        for (int i=0;i<n;i++)
        {
            int e=words[i].Length-1;
            if(e>-1)
            {
                if( (words[i][0]=='a' || words[i][0]=='e' || words[i][0]=='i' || words[i][0]=='o' || words[i][0]=='u')&&
                (words[i][e]=='a' || words[i][e]=='e' || words[i][e]=='i' || words[i][e]=='o' || words[i][e]=='u')
                )
                {
                    sum++;
                }
            }
            prefix[i] = sum;
        }
        int[] result = new int[queries.Length];
        int ind = 0;
        foreach(int[] query in queries)
        {
            int l = query[0];
            int r = query[1];
            if (l == 0)
            {
                result[ind++] = prefix[r];
            }
            else
            {
                result[ind++] = prefix[r] - prefix[l - 1];
            }
        }
        return result;
    }
}