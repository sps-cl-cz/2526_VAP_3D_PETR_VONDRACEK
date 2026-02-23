namespace kalkulačka
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public string Expression
        {
            get
            {
                return _expression;
            }
            set
            {
                _expression = value;
                OnPropertyChanged();
            }
        }

        string _expression = string.Empty;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        private void OnNumberClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string value = button.Text;
                Expression += value;
            }
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            try
            {
                string result = new DataTable().Compute(Expression, null).ToString();
                Expression = result;
            }
            catch (Exception ex)
            {
                Expression = "Error";
            }
        }
    }

}
