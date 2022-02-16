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
    public partial class Statistic_item_exam : ContentPage
    {
        ViewCell lastCell;

        public Statistic_item_exam()
        {
            InitializeComponent();
            List<string> themes = new List<string>() { "Вариант 1", "Вариант 2", "Вариант 3", "Вариант 4", "Вариант 5", "Вариант 6", "Вариант 7", "Вариант 8", "Вариант 9", "Вариант 10" };
            this.BindingContext = themes;
        }

        async private void Go_to_Statistic(object sender, EventArgs e)
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
    }
}