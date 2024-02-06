public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
         Dictionary<string, List<string>> mp=new Dictionary<string, List<string>>();
         foreach (string str in strs)
         {
             string st = str;
             char[] charArray = st.ToCharArray();
             Array.Sort(charArray);
             st = new string(charArray);
             if (mp.ContainsKey(st))
             {
                 mp[st].Add(str);
             }
             else
             {
                 mp[st] =new List<string>();
                 mp[st].Add(str);
             }
         }
         IList<IList<string>> strin= new List<IList<string>>();
         foreach(List<string> s in mp.Values)
         {
             if(s.Count > 0) 
             { 
                 strin.Add(s); 
             }
         }
         return strin;
    }
}