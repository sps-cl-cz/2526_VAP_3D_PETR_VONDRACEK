using MovieManager.ViewModels;

namespace MovieManager.Pages
{
    public partial class MovieDetailsPage : ContentPage
    {
        public MovieDetailsPage(MovieDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
