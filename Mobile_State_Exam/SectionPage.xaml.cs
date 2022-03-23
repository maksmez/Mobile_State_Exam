using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_State_Exam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SectionPage : ContentPage
    {
        public SectionPage(Science science)
        {
            InitializeComponent();
            this.BindingContext = science;
        }

        async private void Go_to_StartPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }

        async private void Go_to_Theory(object sender, EventArgs e)
        {
            Science science = this.BindingContext as Science;
            await Navigation.PushAsync(new Theory(science));
        }

        async private void Go_to_Cheats(object sender, EventArgs e)
        {
            Science science = this.BindingContext as Science;
            await Navigation.PushAsync(new Cheats(science));
        }

        async private void Go_to_Terms(object sender, EventArgs e)
        {
            Science science = this.BindingContext as Science;
            await Navigation.PushAsync(new Terms(science));
        }

        async private void Go_to_Tests(object sender, EventArgs e)
        {
            Science science = this.BindingContext as Science;
            await Navigation.PushAsync(new Tests(science));
        }

        async private void Go_to_Exams(object sender, EventArgs e)
        {
            Science science = this.BindingContext as Science;
            await Navigation.PushAsync(new Exams(science));
        }

    }
}