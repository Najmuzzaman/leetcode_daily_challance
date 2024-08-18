public class Solution {
    public string LargestPalindrome(int n, int k) 
    {
        // Case for k = 1, 3, 9
        if (k == 1 || k == 3 || k == 9) 
            return new string('9', n);
        // Case for k = 2
        if (k == 2) 
        {
            if (n == 1)
                return "8"; // Special case where n=1, return 8 instead of 9            
           
            StringBuilder sb = new StringBuilder(new string('9', n));
            sb[0] = '8'; // Set the first digit to 8
            sb[n - 1] = '8'; // Set the last digit to 8
            return sb.ToString();
        }
        // Case for k = 4
        if (k == 4 )
        {
            if (n == 1)
                return "8"; // Special case where n=1, return 8 instead of 9
            
            if (n == 2)
                return "88"; // Special case where n=1, return 8 instead of 9
            
            if (n == 3)
                return "888";
            
            StringBuilder sb = new StringBuilder(new string('9', n));
            sb[0] = '8'; // Set the first digit to 8
            sb[1] = '8';
             sb[n - 2] = '8';
            sb[n - 1] = '8'; // Set the last digit to 8
            return sb.ToString();
        }
        
        // Case for k = 5
        if (k == 5) {
            if (n == 1)
                return "5"; // Special case where n=1, return 5 instead of 9
            
            StringBuilder sb = new StringBuilder(new string('9', n));
            sb[0] = '5'; // Set the first digit to 5
            sb[n - 1] = '5'; // Set the last digit to 5
            return sb.ToString();
        }
        
        if (k == 6)
        {
            if (n == 1)
                return "6";
            if (n == 2)
                return "66";            
             if (n == 3)
                return "888";            
             if (n == 3)
                return "8778";
            if(n % 2 == 1)
            {
                int l = n / 2 - 1;
                StringBuilder sb = new StringBuilder(new string('9', l));
                return "8" + sb.ToString() + "8" +  sb.ToString() + "8";
            }
            else
            {
                int l = n / 2 - 2;
                StringBuilder sb = new StringBuilder(new string('9', l));
                return "8" +  sb.ToString() + "77" +  sb.ToString() + "8";
            }
        }
        
        // Case for k = 7
        if (k == 7)
        {
           var dic = new string[]
            {
                "", "7", "77", "959", "9779", "99799", "999999", "9994999",
                "99944999", "999969999", "9999449999", "99999499999"
            };
            int l  = n / 12;
            int r= n % 12;
            
            StringBuilder sb = new StringBuilder(new string('9', 6 * l));
            
            return sb.ToString() + dic[r] + sb.ToString();
        }
        // Case for k = 8
        if (k == 8)
        {
            if (n == 1)
                return "8"; // Special case where n=1, return 8 instead of 9
            
            if (n == 2)
                return "88"; // Special case where n=1, return 8 instead of 9
            
             if (n == 3)
                return "888";
            
            if (n == 4)
                return "8888";
            
            if (n == 5)
                return "88888";
            
            StringBuilder sb = new StringBuilder(new string('9', n));
            sb[0] = '8'; // Set the first digit to 8
            sb[1] = '8'; 
            sb[2] = '8'; 
            sb[n - 3] = '8'; // Set the last digit to 8
            sb[n - 2] = '8'; 
            sb[n - 1] = '8'; 
            return sb.ToString();
        }
        return "-1";
    }
}