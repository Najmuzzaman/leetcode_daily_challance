public class TaskManager {

    PriorityQueue<int, (int prio, int taskId)> userId_PrioTaskId = new(new PrioTaskIdComparer());
    Dictionary<int, (int prio, int userId)> task_prioUserId = new();

    public TaskManager(IList<IList<int>> tasks) { //total : nlogn
        foreach (var task in tasks) { //O(n)
            Add(task[0], task[1], task[2]); //Ologn
        }
    }
    
    public void Add(int userId, int taskId, int priority) { //total logn
        userId_PrioTaskId.Enqueue(userId, (priority, taskId)); //logn
        task_prioUserId[taskId] = (priority, userId); //o(1)
    }
    
    public void Edit(int taskId, int newPriority) {
        if (task_prioUserId.TryGetValue(taskId, out var current)) { //o(1)
            // Just update the dictionary and enqueue the new version
            task_prioUserId[taskId] = (newPriority, current.userId); //O(1)
            userId_PrioTaskId.Enqueue(current.userId, (newPriority, taskId));//logN
        }
    }
    
    public void Rmv(int taskId) { //O(1)
        task_prioUserId.Remove(taskId);
    }
    
    public int ExecTop() { //Worse case MlogN, m=number of entries logN enaueue operation, the rest are O(1)
        while (userId_PrioTaskId.Count > 0) {
            userId_PrioTaskId.TryDequeue(out int userId, out var prioTaskId);
            
            // Check if the task exists and matches the current priority
            if (task_prioUserId.TryGetValue(prioTaskId.taskId, out var current) && 
                current.prio == prioTaskId.prio && 
                current.userId == userId) 
            {
                // Remove from dictionary (since it's being executed)
                task_prioUserId.Remove(prioTaskId.taskId);
                return userId;
            }
        }
        return -1;  // No valid tasks left
    }
}

public class PrioTaskIdComparer : IComparer<(int prio, int taskId)>
{
    public int Compare((int prio, int taskId) x, (int prio, int taskId) y)
    {
        // First compare by priority (higher priority comes first)
        int prioComparison = y.prio.CompareTo(x.prio);
        
        // If priorities are equal, compare by taskId (higher taskId comes first)
        if (prioComparison == 0)
        {
            return y.taskId.CompareTo(x.taskId);
        }
        
        return prioComparison;
    }
}

/**
 * Your TaskManager object will be instantiated and called as such:
 * TaskManager obj = new TaskManager(tasks);
 * obj.Add(userId,taskId,priority);
 * obj.Edit(taskId,newPriority);
 * obj.Rmv(taskId);
 * int param_4 = obj.ExecTop();
 */