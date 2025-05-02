public class Solution {
    public string PushDominoes(string dominoes) {
        int n = dominoes.Length;
        int[] status = new int[n];
        Queue<int> indexes = new();
        for(int i=0; i<n; i++)
            switch(dominoes[i])
            {
                case 'R' : status[i] = 1; indexes.Enqueue(i); break;
                case 'L' : status[i] = -1; indexes.Enqueue(i); break;
                default: break;
            }
        // Use queue
        while(indexes.Count>0){
            int c = indexes.Count();
            HashSet<int> processed = new();
            for(int k=0; k<c; k++){
                int ind = indexes.Dequeue();
                if(status[ind]>0 && ind<n-1 && (status[ind+1]==0 || processed.Contains(ind+1))) 
                    {status[ind+1]++; processed.Add(ind+1);}
                if(status[ind]<0 && ind>0 &&  (status[ind-1]==0 || processed.Contains(ind-1))) 
                    {status[ind-1]--; processed.Add(ind-1);}
            }
            foreach(int p in processed)
                if(status[p]==1 && p<n-1 && status[p+1]==0) indexes.Enqueue(p);
                else if(status[p]==-1 && p>0 && status[p-1]==0) indexes.Enqueue(p);
        }
        // build the answer
        StringBuilder ans = new StringBuilder();
        for(int i=0; i<n; i++)
        {
            switch(status[i])
            {
                case 1 : ans.Append('R'); break;
                case 0 : ans.Append('.'); break;
                case -1 : ans.Append('L'); break;
                default: Console.WriteLine("Error!"); break; // error case
            }
        }
        return ans.ToString();
    }
}