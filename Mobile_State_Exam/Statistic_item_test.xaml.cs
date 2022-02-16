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
    public partial class Statistic_item_test : ContentPage
    {
        ViewCell lastCell;

        public Statistic_item_test()
        {
            InitializeComponent();
            List<string> themes = new List<string>() { "Логарифмы", "Тригонометрия", "Неравенства", "Операции с числами", "Очень при очень сложная тема", "Производные", "Сложные тригонометрические функции", "Система линейных алгебраических уравнений", "Дифференциальные уравнения", "Математика в экономике" };
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