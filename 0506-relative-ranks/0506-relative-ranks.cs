public class Solution {
    public string[] FindRelativeRanks(int[] score) {
        int n=score.Length;
        string[] ans=new string[n];        
        int[] s = new int[n];
        Array.Copy(score, s, n);
        Array.Sort(s);
        Array.Reverse(s);
        int[] ind=new int[1000001];
        for(int i=0;i<n;i++)    
            ind[s[i]]=i+1;
        
        for(int i=0;i<n;i++)
        {
            if(ind[score[i]]==1)
                ans[i]="Gold Medal";
            else if(ind[score[i]]==2)
                ans[i]="Silver Medal";
            else if(ind[score[i]]==3)
                ans[i]="Bronze Medal";
            else
                ans[i]=ind[score[i]].ToString();
        }
        return ans;
    }
}