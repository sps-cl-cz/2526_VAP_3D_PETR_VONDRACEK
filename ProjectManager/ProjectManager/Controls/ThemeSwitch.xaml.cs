using Microsoft.Maui.Controls;

namespace ProjectManager.Controls
{
    public partial class ThemeSwitch : ContentView
    {
        public static readonly BindableProperty IsDarkThemeProperty =
            BindableProperty.Create(
                nameof(IsDarkTheme),
                typeof(bool),
                typeof(ThemeSwitch),
                defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: OnIsDarkThemeChanged);

        public bool IsDarkTheme
        {
            get => (bool)GetValue(IsDarkThemeProperty);
            set => SetValue(IsDarkThemeProperty, value);
        }

        private static void OnIsDarkThemeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ThemeSwitch control && newValue is bool isDark)
            {
                control.ApplyTheme(isDark);
                control.OnPropertyChanged(nameof(CurrentTheme));
            }
        }

        public string CurrentTheme =>
            Application.Current?.UserAppTheme == AppTheme.Dark ? "Dark Mode" : "Light Mode";

        public ThemeSwitch()
        {
            InitializeComponent();
            bool initialDark = Application.Current?.UserAppTheme == AppTheme.Dark;
            SetValue(IsDarkThemeProperty, initialDark);
        }

        private void ApplyTheme(bool isDark)
        {
            Application.Current.UserAppTheme = isDark ? AppTheme.Dark : AppTheme.Light;
        }
    }
}