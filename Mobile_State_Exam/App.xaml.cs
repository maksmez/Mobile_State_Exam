using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;

namespace Mobile_State_Exam
{
    public partial class App : Application
    {
        public App()
        {
            //per();
            InitializeComponent();
            MainPage = new NavigationPage(new StartPage());
            using (var db = new Context())
            {
                db.Database.Migrate();
            }
        }

        async void per()
        {
            var per = await Permissions.RequestAsync<Permissions.NetworkState>();

        }
        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
