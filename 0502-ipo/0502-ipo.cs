public class Solution {
    
    private class Project
    {
        public int C { get; set; }
        public int P { get; set; }

        public Project(int c, int p)
        {
            C = c;
            P = p;
        }
    }
    
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital) 
    {
        List<Project> projects = new List<Project>();
        for (int i = 0; i < profits.Length; i++)
            projects.Add(new Project(capital[i], profits[i]));
        
        projects.Sort((a, b) => a.C.CompareTo(b.C));
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        int index = 0;
        for (int j = 0; j < k; j++)
        {
            while (index < projects.Count && projects[index].C <= w)
            {
                maxHeap.Enqueue(projects[index].P, projects[index].P);
                index++;
            }
            
            if (maxHeap.Count == 0)
                break;
            w += maxHeap.Dequeue();
        }
        return w;
    }
}