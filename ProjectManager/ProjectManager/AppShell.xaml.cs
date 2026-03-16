namespace ProjectManager.pages;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ProjectDetailsPage), typeof(ProjectDetailsPage));
    }
}
