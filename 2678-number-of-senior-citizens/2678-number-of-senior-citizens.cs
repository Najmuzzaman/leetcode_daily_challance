public class Solution {
    public int CountSeniors(string[] details) {
         int seniors = 0;
         foreach (string a in details)
         {
             int age = Convert.ToInt32(a.Substring(11, 2));
             if(age>60)
                 seniors++;
         }
         return seniors;
    }
}