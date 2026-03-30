using ProjectManager.Models;
using ProjectManager.ViewModels;

namespace ProjectManager.Pages;

public partial class NewProjectPage : ContentPage
{
	MainViewModel _viewModel;
	public NewProjectPage(MainViewModel mainViewModel)
	{
		_viewModel = mainViewModel;
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		string title = ProjectTitle.Text;
		string description = ProjectDescription.Text;
		DateTime date = ProjectDate.Date;
		Project project = new Project
		{
			Title = title,
			Description = description,
			Date = date,
		};
		_viewModel.Projects.Add(new ProjectViewModel(project));
		Shell.Current.GoToAsync("//MainPage");
    }
}