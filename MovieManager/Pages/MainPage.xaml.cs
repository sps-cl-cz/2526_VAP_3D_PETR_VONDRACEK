using MovieManager.ViewModels;

namespace MovieManager
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _viewModel;

        public MainPage(MainViewModel mainViewModel)
        {
            _viewModel = mainViewModel;
            InitializeComponent();
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadMoviesAsync();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is MovieViewModel vm)
            {
                Shell.Current.GoToAsync(nameof(Pages.MovieDetailsPage),
                    new Dictionary<string, object> { { "Movie", vm } });
            }
        }
    }
}
