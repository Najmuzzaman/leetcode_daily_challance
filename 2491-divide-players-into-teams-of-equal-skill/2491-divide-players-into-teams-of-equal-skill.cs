public class Solution {
    public long DividePlayers(int[] skill) {
         int n=skill.Length;
         int[] ind=new int[1001];
         long Sum=skill.Sum(x=>(long)x);
         Sum *= 2;
         if (Sum % n != 0) return -1;
         long S=Sum/n;
         HashSet<int> seen=new HashSet<int>();
         for (int i = 0; i < n; i++)
         {
             ind[skill[i]]++;
             seen.Add(skill[i]);
         }
         Sum = 0;
         foreach (int i in seen)
         {
             int Ne =(int) (S - i);
             while (ind[i]>0)
             {
                 Sum += ((long)i * Ne);
                 ind[i]--;
                 ind[Ne]--;
                 if (ind[Ne] == -1) return -1;
             }
         }
         return Sum;
    }
}