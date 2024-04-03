public class Solution {
    char[][] board;
    bool[,] visited;
    int len,m,n; 
    public bool Exist(char[][] board, string word) {
        this.board = board;
        m = board.Length;
        n = board[0].Length;
        len=word.Length;
        visited = new bool[m, n];
        bool ans = false;
        
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (this.board[i][j] == word[0]) {
                    ans = dfs(word, i, j, 0);
                    if (ans) return true;
                }
            }
        }
        
        return false;
    }
    
    private bool dfs(string word, int i, int j, int v) {
        if (v == len) {
            return true;
        }
        
        if (!IsValid(i, j, word[v])) {
            return false;
        }
        
        visited[i, j] = true;
        
        if (dfs(word, i + 1, j, v + 1) ||
            dfs(word, i - 1, j, v + 1) ||
            dfs(word, i, j + 1, v + 1) ||
            dfs(word, i, j - 1, v + 1)) {
            return true;
        }
        
        visited[i, j] = false;
        return false;
    }
    
    private bool IsValid(int i, int j, char target) {               
        return i >= 0 && i < m && j >= 0 && j < n && !visited[i, j] && board[i][j] == target;
    }
}