namespace ProjectManager.Controls;

public partial class ImagePicker : ContentView
{
    public static BindableProperty ImagePathProperty =
        BindableProperty.Create(
            nameof(ImagePath),
            typeof(string),
            typeof(ImagePicker),
            string.Empty,
            BindingMode.TwoWay
            );

    public string ImagePath 
    { 
        get => (string)GetValue(ImagePathProperty);
        set => SetValue(ImagePathProperty, value);
    }

	public ImagePicker()
	{
		InitializeComponent();
        BindingContext = this;
	}

    private async void FileSelect_Clicked(object sender, EventArgs e)
    {
        var res = await FilePicker.PickAsync(PickOptions.Images);
        if (res != null)
        {
            ImagePath = res.FullPath;
        }
    }
}