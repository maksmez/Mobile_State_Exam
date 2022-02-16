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
    public partial class Test_item : ContentPage
    {
        public Test_item()
        {
            InitializeComponent();
        }

        async private void Go_to_SelectionPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    
    }
}