public class Solution {
    public string FindDifferentBinaryString(string[] nums) {
        int n = nums.Length;
        char[] ans = new string('0', n).ToCharArray();
        
        if (!nums.Contains(new string(ans))) return new string(ans);
        
        for (int i = 0; i < n; i++) 
        {
            ans[i] = '1';
            if (!nums.Contains(new string(ans))) 
                return new string(ans);
            ans[i] = '0';
        }
        return new string(ans);
    }
}