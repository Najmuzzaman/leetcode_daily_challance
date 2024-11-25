public class Solution {
    int[][] directions =new int[6][]{new int[]{1, 3}, new int[]{0, 2, 4}, new int[]{1, 5},
                                  new int[]{0, 4}, new int[]{3, 5, 1}, new int[]{4, 2}};
    public int SlidingPuzzle(int[][] board) {
       
        StringBuilder b=new StringBuilder("");
        int p = 0;
        int k =0;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                b.Append(board[i][j].ToString());
                if (board[i][j] == 0)
                    p = k;
                k++;
            }
        }
        Dictionary<string, int> visit = new Dictionary<string, int>();
        dfs(b, visit, p, 0);
        return visit.ContainsKey("123450") ? visit["123450"] : -1;
    }
    void dfs(StringBuilder state, Dictionary<string, int> visit, int p,int moves)
    {
        if (visit.ContainsKey(state.ToString()) && visit[state.ToString()] <= moves)
        {
            return;
        }
        visit[state.ToString()] = moves;

        foreach (int nextPos in directions[p])
        {
            char a = state[p];
            state[p] = state[nextPos];
            state[nextPos] = a;

            dfs(state, visit, nextPos,moves + 1);
            a = state[p];
            state[p] = state[nextPos];
            state[nextPos] = a;
        }
    }
}