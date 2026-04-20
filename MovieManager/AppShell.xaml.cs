using MovieManager.Pages;

namespace MovieManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MovieDetailsPage), typeof(MovieDetailsPage));
        }
    }
}
