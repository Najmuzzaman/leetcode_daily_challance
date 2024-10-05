public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        int n=s1.Length;
        int m=s2.Length;
        int[] ind=new int[27];
        for(int i=0;i<n;i++)
            ind[s1[i]-'a']++;
        int[] ind2 = new int[27];
        for(int i = 0; i < n && i < m; i++)
            ind2[s2[i] - 'a']++;

        bool flag = true;
        for (int j = 0; j <= 26 && flag; j++)
            if (ind[j] != ind2[j])
                flag = false;
        if (flag)
        {
            return true;
        }
        
        for (int i=1;i<=m-n;i++)
        {
            ind2[s2[i + n -1] - 'a']++;
            ind2[s2[i - 1] - 'a']--;
            flag=true;
            for (int j = 0; j <= 26 && flag; j++)
                if (ind[j] != ind2[j])
                    flag = false;
            if(flag)
            {
                return true;
            }
        }
        return false;
    }
}