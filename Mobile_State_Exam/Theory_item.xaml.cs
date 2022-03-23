using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_State_Exam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Theory_item : ContentPage
    {
        Theme theme_object = new Theme();
        public Theory_item(Theme theme)
        {
            InitializeComponent();
            theme_object.id = theme.id;
            UrlWebViewSource urlSource = new UrlWebViewSource();
            string path = theme.theory;
            urlSource.Url = System.IO.Path.Combine("file:///android_asset/theory", path);
            web.Source = urlSource;
            this.BindingContext = theme;
        }

        async private void Go_to_Theory(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}