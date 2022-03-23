using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Mobile_State_Exam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cheats_item : ContentPage
    {
        Cheat cheat = new Cheat();
        public Cheats_item(Cheat cheat)
        {
            InitializeComponent();
            UrlWebViewSource urlSource = new UrlWebViewSource();
            string path = cheat.path;
            urlSource.Url = System.IO.Path.Combine("file:///android_asset/cheat", path);
            web.Source = urlSource;
            this.BindingContext = cheat;

        }

       async private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }
    }
}