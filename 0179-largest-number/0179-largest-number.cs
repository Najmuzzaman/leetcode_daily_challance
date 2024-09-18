public class Solution {
    public string LargestNumber(int[] nums) {
        int n=nums.Length;
        string[] st=new string[n];
        for(int i=0;i<n;i++)
            st[i]=nums[i].ToString();
        Array.Sort(st, (a, b) => string.Compare(b + a, a + b));
        if(st[0]=="0") return "0";
        string s="";
        for(int i=0;i<n;i++)
            s+=st[i];
        return s;
    }
}