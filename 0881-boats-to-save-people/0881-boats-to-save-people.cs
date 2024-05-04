public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        Array.Sort(people);
        int i=0 , boats=0;
        int j=people.Length-1;

        while(i<=j){
            if(people[i]+people[j]<=limit){
                i++;
                j--;
                boats++;
            }
            else{
                boats++;
                j--;
            }
        }

        return boats;
    }
}