using ProjectManager.Database;
using ProjectManager.ViewModels;

namespace ProjectManager.Pages;

[QueryProperty(nameof(Project), "Project")]
public partial class ProjectDetailsPage : ContentPage
{
	public ProjectViewModel Project 
	{ 
		get => _viewModel; 
		set 
		{ 
			_viewModel = value; 
			BindingContext = value; 
		} 
	}
	ProjectViewModel _viewModel;
	DatabaseService _databaseService;
	
	public ProjectDetailsPage(DatabaseService databaseService)
	{
		_databaseService = databaseService;
		InitializeComponent();
	}

    protected override void OnDisappearing()
    {
		_databaseService.SaveProjectAsync(Project.Project);
        base.OnDisappearing();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}