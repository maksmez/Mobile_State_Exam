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
    public partial class Theory : ContentPage
    {
        ViewCell lastCell;
        public Theory()
        {
            InitializeComponent();
            List<string> themes = new List<string>() { "Тема1", "Тема2", "Тема3", "Операции с числами", "Очень при очень сложная тема", "Производные"};
            this.BindingContext = themes;
        }

        async private void Go_to_SelectionPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

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

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
   
}