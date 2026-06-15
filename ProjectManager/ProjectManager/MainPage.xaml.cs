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
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ProjectViewModel projectViewModel = (ProjectViewModel)button.BindingContext;
            _viewModel.Projects.Remove(projectViewModel);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Shell.Current.GoToAsync(nameof(ProjectDetailsPage), new Dictionary<string, object> { { "Project", e.Item } });
        }
    }

}
