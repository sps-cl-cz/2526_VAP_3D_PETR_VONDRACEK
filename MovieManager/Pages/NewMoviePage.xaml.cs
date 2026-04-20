using MovieManager.ViewModels;

namespace MovieManager.Pages
{
    public partial class NewMoviePage : ContentPage
    {
        public NewMoviePage(NewMovieViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
