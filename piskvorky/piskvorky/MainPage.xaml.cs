using piskvorky.ViewModels;

namespace piskvorky;

public partial class MainPage : ContentPage
{
    private Button[,] _buttons = new Button[3, 3];
    private readonly GameViewModel _viewModel;

    public MainPage()
    {
        InitializeComponent();
        _viewModel = new GameViewModel();
        CreateBoard();
        BindingContext = _viewModel;
    }

    void CreateBoard()
    {
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                var btn = new Button
                {
                    FontSize = 32
                };

                int row = r;
                int col = c;
                btn.Clicked += (sender, e) => _viewModel.ProcessMove(sender, row, col);

                Grid.SetRow(btn, r);
                Grid.SetColumn(btn, c);

                GameGrid.Children.Add(btn);
                _buttons[r, c] = btn;
            }
        }

        _viewModel.InitializeBoard(_buttons);
    }
}