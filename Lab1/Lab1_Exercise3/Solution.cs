namespace Lab1_Exercise3
{
    public class Solution
    {
        // Constants for directions
        private static readonly (int di, int dj)[] DIRS = { (-1, 0), (1, 0), (0, -1), (0, 1) };
        private int m, n;
        private char[][] board;
        private string word;
        private bool[][] visited;

        public bool Exist(char[][] board, string word)
        {
            if (board == null || board.Length == 0 || word == null || word.Length == 0)
            {
                return false;
            }

            this.board = board;
            this.word = word;
            m = board.Length;
            n = board[0].Length;

            // Early termination: check if the board is too small
            if (m * n < word.Length)
            {
                return false;
            }

            // Count characters in word and board to enable early termination
            var charCount = new int[128];
            foreach (var row in board)
            {
                foreach (var c in row)
                {
                    charCount[c]++;
                }
            }

            foreach (var c in word)
            {
                charCount[c]--;
                if (charCount[c] < 0) return false;
            }

            // Initialize visited array instead of modifying the board
            visited = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                visited[i] = new bool[n];
            }

            // Start search from positions matching the first character
            char firstChar = word[0];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == firstChar && DFS(i, j, 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool DFS(int i, int j, int k)
        {
            if (k == word.Length) return true;

            if (i < 0 || i >= m || j < 0 || j >= n ||
                visited[i][j] || board[i][j] != word[k])
            {
                return false;
            }

            visited[i][j] = true;

            foreach (var (di, dj) in DIRS)
            {
                if (DFS(i + di, j + dj, k + 1))
                {
                    return true;
                }
            }

            visited[i][j] = false;
            return false;
        }
    }
}
