using System.Windows.Input;
using piskvorky.Models;

namespace piskvorky.ViewModels;

public class GameViewModel : BindableObject
{
    private readonly GameBoard _board;
    private Button[,] _buttons;

    public GameViewModel()
    {
        _board = new GameBoard();
        RestartCommand = new Command(ResetGame);
    }

    public ICommand RestartCommand { get; }

    public void InitializeBoard(Button[,] buttons)
    {
        _buttons = buttons;
        ResetGame();
    }

    public void ProcessMove(object sender, int row, int col)
    {
        var btn = sender as Button;
        if (btn == null) return;

        if (!_board.MakeMove(row, col))
            return;

        btn.Text = _board.CurrentPlayer == Player.X ? "X" : "O";

        if (_board.CheckWinner())
        {
            Application.Current.MainPage.DisplayAlert("Konec hry",
                $"Vyhrál hráč {(_board.CurrentPlayer == Player.X ? "X" : "O")}", "OK");
            ResetGame();
            return;
        }

        if (_board.IsDraw())
        {
            Application.Current.MainPage.DisplayAlert("Konec hry", "Remíza", "OK");
            ResetGame();
            return;
        }

        _board.SwitchPlayer();
    }

    private void ResetGame()
    {
        _board.Reset();
        if (_buttons != null)
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    _buttons[r, c].Text = string.Empty;
                }
            }
        }
    }
}