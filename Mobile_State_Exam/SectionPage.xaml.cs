using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_State_Exam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SectionPage : ContentPage
    {
        public SectionPage()
        {
            InitializeComponent();
        }

        async private void Go_to_StartPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }

        async private void Go_to_Theory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Theory());
        }

        async private void Go_to_Cheats(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cheats());
        }

        async private void Go_to_Terms(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Terms());
        }

        async private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Tests());
        }

        async private void Go_to_Exams(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Exams());
        }
    }
}