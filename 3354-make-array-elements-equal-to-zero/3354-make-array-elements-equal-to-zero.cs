public class Solution {
    int n;
    public int CountValidSelections(int[] nums) {
        n = nums.Length;
        int Ans = 0;
        
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == 0)
            {
                if (IsValidSelection(nums, i, -1)) Ans++;
                if (IsValidSelection(nums, i, 1)) Ans++;
            }
        }
        
        return Ans;
    }
    bool IsValidSelection(int[] nums,int start, int direction)
    {
        int[] temp = (int[])nums.Clone();
        int curr = start;
        int move = direction;
    
        while (curr >= 0 && curr < n)
        {
            if (temp[curr] == 0)
            {
                curr += move;
            }
            else
            {
                temp[curr]--;
                move = -move;
                curr += move;
            }
        }
    
        foreach (int num in temp)
        {
            if (num != 0)
                return false;
        }
    
        return true;
    }
}