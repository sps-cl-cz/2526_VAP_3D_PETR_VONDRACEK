using ProjectManager.Pages;
using ProjectManager.ViewModels;

namespace ProjectManager
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        MainViewModel _viewModel;

        public MainPage(MainViewModel mainViewModel)
        {
            _viewModel = mainViewModel;
            InitializeComponent();
            BindingContext = _viewModel;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(ProjectDetailsPage));
        }
    }

}
