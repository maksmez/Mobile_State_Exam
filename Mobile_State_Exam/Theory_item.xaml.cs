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
    public partial class Theory_item : ContentPage
    {
        public Theory_item()
        {
            InitializeComponent();
        }

        async private void Go_to_Theory(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}