public class Worker
{
    public double Ratio { get; set; }
    public int Quality { get; set; }

    public Worker(double ratio, int quality)
    {
        Ratio = ratio;
        Quality = quality;
    }
}

public class Solution {
    public double MincostToHireWorkers(int[] quality, int[] wage, int k) 
    {
        int n = quality.Length;
        double minCost = double.MaxValue;
        int qualityTillNow = 0;
        List<Worker> workers = new List<Worker>();

        for (int i = 0; i < n; i++)
            workers.Add(new Worker((double)wage[i] / quality[i], quality[i]));

        workers = workers.OrderBy(w => w.Ratio).ToList();
        
        List<int> highQualityWorkers = new List<int>();

        foreach (Worker worker in workers)
        {
            double ratio = worker.Ratio;
            int qua = worker.Quality;

            qualityTillNow += qua;
            highQualityWorkers.Add(-qua);
            highQualityWorkers.Sort();

            if (highQualityWorkers.Count > k)
            {
                qualityTillNow += highQualityWorkers.First();
                highQualityWorkers.RemoveAt(0);
            }

            if (highQualityWorkers.Count == k)
            {
                minCost = Math.Min(minCost, qualityTillNow * ratio);
            }
        }

        return minCost;
    }
}