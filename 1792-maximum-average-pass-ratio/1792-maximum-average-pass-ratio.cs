public class Solution {
    double CalculateGain(int pass, int total)
    {
        return (double)(pass + 1) / (total + 1) - (double)pass / total;
    }
    
    public double MaxAverageRatio(int[][] classes, int extraStudents) {
         PriorityQueue<(double gain, int pass, int total), double> maxHeap = new();        

        // Initialize the heap with all classes
        foreach (var cls in classes)
        {
            int pass = cls[0], total = cls[1];
            maxHeap.Enqueue((CalculateGain(pass, total), pass, total), -CalculateGain(pass, total));
        }

        // Distribute extra students
        for (int i = 0; i < extraStudents; i++)
        {
            var (gain, pass, total) = maxHeap.Dequeue();
            pass++;
            total++;
            maxHeap.Enqueue((CalculateGain(pass, total), pass, total), -CalculateGain(pass, total));
        }

        // Calculate the final average pass ratio
        double totalRatio = 0.0;
        while (maxHeap.Count > 0)
        {
            var (_, pass, total) = maxHeap.Dequeue();
            totalRatio += (double)pass / total;
        }

        return totalRatio/classes.Length;
    }
}