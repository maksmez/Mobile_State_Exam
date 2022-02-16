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
    public partial class Terms : ContentPage
    {
        ViewCell lastCell;

        public Terms()
        {
            InitializeComponent();
            List<string> themes = new List<string>() { "Аксиома — утверждение, принимаемое 6ез доказательств.", "Аргумент (функции). Переменная величина (независимая), с помощью которой определяется значение функции.", "Гипербола. Незамкнутая кривая (состоит при помощи двух неограниченных ветвей). Термин появился благодаря Апполонию Пермскому (древнегреческий ученый).", "Интеграл. Основное понятие математического анализа. Возникло из-за того, что понадобилось измерять объемы и площади.", "Матрица. Прямоугольная таблица. Образуется при помощи множества числа (определенного). Включает в себя столбцы и строки (структура матрицы). Впервые термин «матрица» появилась у ученого Дж. Сильвестра." };
            this.BindingContext = themes;
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
        async private void Go_to_SelectionPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}