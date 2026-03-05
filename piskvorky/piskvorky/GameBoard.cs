namespace piskvorky.Models;

public class GameBoard
{
    private readonly string[,] _cells;
    private Player _currentPlayer;

    public GameBoard()
    {
        _cells = new string[3, 3];
        _currentPlayer = Player.X;
    }

    public Player CurrentPlayer => _currentPlayer;

    public bool MakeMove(int row, int col)
    {
        if (!string.IsNullOrEmpty(_cells[row, col]))
            return false;

        _cells[row, col] = _currentPlayer == Player.X ? "X" : "O";
        return true;
    }

    public string GetCell(int row, int col) => _cells[row, col];

    public bool CheckWinner()
    {
        // Řádky
        for (int r = 0; r < 3; r++)
        {
            if (!string.IsNullOrEmpty(_cells[r, 0]) &&
                _cells[r, 0] == _cells[r, 1] &&
                _cells[r, 1] == _cells[r, 2])
                return true;
        }

        // Sloupce
        for (int c = 0; c < 3; c++)
        {
            if (!string.IsNullOrEmpty(_cells[0, c]) &&
                _cells[0, c] == _cells[1, c] &&
                _cells[1, c] == _cells[2, c])
                return true;
        }

        // Diagonály
        if (!string.IsNullOrEmpty(_cells[0, 0]) &&
            _cells[0, 0] == _cells[1, 1] &&
            _cells[1, 1] == _cells[2, 2])
            return true;

        if (!string.IsNullOrEmpty(_cells[0, 2]) &&
            _cells[0, 2] == _cells[1, 1] &&
            _cells[1, 1] == _cells[2, 0])
            return true;

        return false;
    }

    public bool IsDraw()
    {
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                if (string.IsNullOrEmpty(_cells[r, c]))
                    return false;
            }
        }
        return true;
    }

    public void Reset()
    {
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                _cells[r, c] = string.Empty;
            }
        }
        _currentPlayer = Player.X;
    }

    public void SwitchPlayer()
    {
        _currentPlayer = _currentPlayer == Player.X ? Player.O : Player.X;
    }
}