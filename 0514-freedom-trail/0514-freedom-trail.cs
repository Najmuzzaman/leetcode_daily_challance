public class Solution {
    public int FindRotateSteps(string ring, string key)
    {
        List<int>[] positions = new List<int>[26];
        int rlen=ring.Length;
        int klen=key.Length;
        int i=0;
        foreach (char a in ring) 
        {
            int c = a - 'a';
            if (positions[c] == null) 
                positions[c] = new List<int>();
            positions[c].Add(i);
            i++;
        }
        int[,] dp = new int[klen, rlen];
        return dfs(0, 0, positions, key, ring,rlen,klen, dp);
    }
    
    int dfs(int index, int pos, List<int>[] positions, string key, string ring,int rlen, int klen, int[,] dp) 
    {
        if (index == klen) return 0;
        if (dp[index, pos] > 0) return dp[index, pos];  
        char target = key[index];
        List<int> possiblePositions = positions[target - 'a'];        
        int minSteps = int.MaxValue;
        foreach (int nextPos in possiblePositions) 
        {
            int steps = Math.Min(Math.Abs(nextPos - pos), rlen - Math.Abs(nextPos - pos));            
            int totalSteps = steps + dfs(index + 1, nextPos, positions, key, ring,rlen,klen, dp);            
            minSteps = Math.Min(minSteps, totalSteps);
        }
        return dp[index, pos] = minSteps + 1;
    }
}