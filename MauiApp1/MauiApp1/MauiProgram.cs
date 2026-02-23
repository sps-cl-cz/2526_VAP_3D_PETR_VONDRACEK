using Microsoft.Extensions.Logging;

namespace Úvod

{

    public static class MainPage : ContentPage

    {

        int count = 0;

        Button[] buttons;

        public MainPage()

        {

            InitializeComponent();

            buttons = [CounterBtn1, CounterBtn2, CounterBtn3, CounterBtn4];
            foreach (Button button in buttons)
            {
                button.IsEnabled = false;
                button.FontSize = 30;
                button.FontAttributes = FontAttributes.Bold;
            }
            Random random = new Random();
            int index = random.Next(buttons.Length);
            buttons[index].IsEnabled = true;
            

        }

        private void OnCounterClicked(object sender, EventArgs e)

        {

            count++;

            if (count == 1)

                CountLabel.Text = $"Clicked {count} time";

            else

                CountLabel.Text = $"Clicked {count} times";

        }

    }

}

}

 
