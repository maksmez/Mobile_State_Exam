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
    public partial class Statistic : ContentPage
    {
        public Statistic()
        {
            InitializeComponent();
        }

       async private void Go_to_SectionPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Go_to_Statistic_Science(object sender, EventArgs e)
        {

        }
    }
}