public class Solution {
    public int[] RelativeSortArray(int[] arr1, int[] arr2) {
        int[] a=new int[1001];
        int n=arr1.Length;
        for(int i=0;i<n;i++)
        {
            a[arr1[i]]++;
        }
        n=arr2.Length;
        int j=0;
        for(int i=0;i<n;i++)
        {
            while(a[arr2[i]]>0)
            {
                arr1[j++]=arr2[i];
                a[arr2[i]]--;
            }
        }
        for(int i=0;i<=1000;i++)
        {
            while(a[i]>0)
            {
                arr1[j++]=i;
                a[i]--;
            }
        }
        return arr1;
    }
}