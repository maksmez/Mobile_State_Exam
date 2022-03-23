using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mobile_State_Exam
{
    public partial class StartPage : ContentPage
    {
        ViewCell lastCell;
        Science science = new Science();
        public StartPage()
        {
            InitializeComponent();
            BindingContext = science.LoadData();
        }
        async protected override void OnAppearing()
        {
            if (Preferences.Get("name", "user") == "user")
            {
                string result = await DisplayPromptAsync("Привет!", "Введи свое имя!");
                Preferences.Set("name", result);
            }
            base.OnAppearing();
            user.Text = "Привет, " + Preferences.Get("name", "user") + "!";
        }


        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.White;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.White;
                lastCell = viewCell;
            }
        }

        async private void Go_to_Statistic(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Statistic());
        }


        async private void Go_to_SelectionPage(object sender, SelectedItemChangedEventArgs args)
        {

            Science science = args.SelectedItem as Science;
            if (science != null)
            {
                list.SelectedItem = null;
                await Navigation.PushAsync(new SectionPage(science));
            }
        }

       async private void change_user_name(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("", "Введи свое имя!");
            if (result == null|| result == "" || result == " ")
                return;
            Preferences.Set("name", result);
            user.Text = "Привет, " + Preferences.Get("name", "user") + "!";
        }
    }
}
