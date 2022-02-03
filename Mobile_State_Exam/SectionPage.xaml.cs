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
    }
}