public class Solution {
    private const char EMPTY_CELL = '.';
    private HashSet<char> _hashSet;

    public bool IsValidSudoku(char[][] board) {
        _hashSet = new HashSet<char>(board.Length);

        return AreRowsValid(board)
            && AreColumnsValid(board)
            && AreSubBoxesValid(board);
    }

    private bool AreRowsValid(char[][] board) {
        for (var i = 0; i < board.Length; i++) {
            for (var j = 0; j < board[i].Length; j++) {
                var value = board[i][j];
                if (value == EMPTY_CELL) continue;
                if (!_hashSet.Add(value)) return false;
            }

            _hashSet.Clear();
        }

        return true;
    }

    private bool AreColumnsValid(char[][] board) {
        var column = new HashSet<char>(board.Length);

        for (var i = 0; i < board.Length; i++) {
            for (var j = 0; j < board[i].Length; j++) {
                var value =  board[j][i];
                if (value == EMPTY_CELL) continue;
                if (!_hashSet.Add(value)) return false;
            }

            _hashSet.Clear();
        }

        return true;
    }

    private bool AreSubBoxesValid(char[][] board) {
        var subBoxSize = (int) Math.Sqrt(board.Length);

        for (var i = 0; i < subBoxSize; i++) {
            for (var j = 0; j < subBoxSize; j++) {
                if (!IsSubBoxValid(board, subBoxSize, i, j)) return false;
            }
        }

        return true;
    }

    private bool IsSubBoxValid(char[][] board, int subBoxSize, int subBoxRow, int subBoxColumn) {
        for (var i = 0; i < subBoxSize; i++) {
            for (var j = 0; j < subBoxSize; j++) {
                var rowIndex = (subBoxRow * subBoxSize) + i;
                var columnIndex = (subBoxColumn * subBoxSize) + j;
                var value = board[rowIndex][columnIndex];
                
                if (value == EMPTY_CELL) continue;
                if (!_hashSet.Add(value)) return false;
            }
        }

        _hashSet.Clear();

        return true;
    }
}