using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile_State_Exam
{
    public partial class StartPage : ContentPage
    {
        ViewCell lastCell;
        public StartPage()
        {
            InitializeComponent();
            List<string> sciences = new List<string>() {"Математка","Русский язык", "Истроия", "Истроия", "Истроия", "Истроия", "Истроия", "Истроия", "Истроия", "Истроия" };
            this.BindingContext = sciences;
           
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

        async private void Go_to_SelectionPage(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new SectionPage());

        }

       async private void Go_to_Statistic(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Statistic());

        }
    }
}
