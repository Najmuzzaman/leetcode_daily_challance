public class Solution {
    public int[] MaxPoints(int[][] grid, int[] queries) {        
        int rowCount = grid.Length, colCount = grid[0].Length;
        List<int[]> cellList = new List<int[]>();
        
        for (int row = 0; row < rowCount; row++) {
            for (int col = 0; col < colCount; col++) {
                cellList.Add(new int[] { row, col, grid[row][col] }); // [row, col, value]
            }
        }
        
        cellList.Sort((a, b) => a[2] - b[2]); // Sort by value in ascending order
        var sortedQueryList = queries.Select((value, idx) => new { value, idx }).OrderBy(q => q.value).ToList();
        
        int totalCells = cellList.Count;
        int cellIndex = 0;
        DisjointSet dsu = new DisjointSet(totalCells);
        int[] resultArray = new int[queries.Length];
        
        foreach (var query in sortedQueryList) {
            int queryValue = query.value;
            int queryIndex = query.idx;
            
            while (cellIndex < totalCells && cellList[cellIndex][2] < queryValue) {
                int currRow = cellList[cellIndex][0];
                int currCol = cellList[cellIndex][1];
                MergeAdjacentCells(currRow, currCol, queryValue, grid, dsu, rowCount, colCount);
                cellIndex++;
            }
            
            if (grid[0][0] >= queryValue) {
                resultArray[queryIndex] = 0;
            } else {
                int connectedCells = dsu.GroupSize[dsu.Find(0)]; // Count cells connected to grid[0][0]
                resultArray[queryIndex] = connectedCells;
            }
        }
        
        return resultArray;
    }
    
    private void MergeAdjacentCells(int row, int col, int queryValue, int[][] grid, DisjointSet dsu, int rowCount, int colCount) {
        int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 } };
        
        foreach (var dir in directions) {
            int newRow = row + dir[0];
            int newCol = col + dir[1];
            
            if (newRow < 0 || newRow >= rowCount || newCol < 0 || newCol >= colCount) continue;
            if (grid[newRow][newCol] >= queryValue) continue;
            
            dsu.Union(GetCellIndex(row, col, colCount), GetCellIndex(newRow, newCol, colCount));
        }
    }
    
    private int GetCellIndex(int row, int col, int colCount) {
        return row * colCount + col;
    }
}

public class DisjointSet {
    public int[] Parent;
    public int[] Rank;
    public int[] GroupSize;

    public DisjointSet(int size) {
        Parent = new int[size];
        Rank = new int[size];
        GroupSize = new int[size];
        
        for (int i = 0; i < size; i++) {
            Parent[i] = i;
            Rank[i] = 1;
            GroupSize[i] = 1;
        }
    }
    
    public int Find(int x) {
        if (Parent[x] == x) return x;
        Parent[x] = Find(Parent[x]); // Path compression
        return Parent[x];
    }
    
    public bool Union(int x, int y) {
        int rootX = Find(x);
        int rootY = Find(y);
        
        if (rootX == rootY) return false;
        
        if (Rank[rootX] < Rank[rootY]) {
            Parent[rootX] = rootY;
            GroupSize[rootY] += GroupSize[rootX];
        } else if (Rank[rootX] > Rank[rootY]) {
            Parent[rootY] = rootX;
            GroupSize[rootX] += GroupSize[rootY];
        } else {
            Parent[rootY] = rootX;
            Rank[rootX]++;
            GroupSize[rootX] += GroupSize[rootY];
        }
        return true;
    }
}
