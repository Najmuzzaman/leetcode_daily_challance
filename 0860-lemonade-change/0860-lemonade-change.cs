public class Solution {
    public bool LemonadeChange(int[] bills) {
        int[] change=new int[30];
        
        foreach(int a in bills)
        {
            if(a==5)
                change[5]++;
            else if(a==10)
            {
                if(change[5]>0)
                {
                    change[5]--;
                    change[10]++;
                }
                else
                    return false;                
            }
            else if(a==20)
            {
                if(change[5]>=1 && change[10]>=1)
                {
                    change[5]--;
                    change[10]--;
                    change[20]++;
                }
                else if(change[5]>=3)
                {
                    change[5]--;
                    change[5]--;
                    change[5]--;
                    change[20]++;
                }
                else
                    return false;
            }
        }
        return true;
    }
}