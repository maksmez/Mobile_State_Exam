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
    public partial class Exam_item_complete : ContentPage
    {
        public Exam_item_complete()
        {
            InitializeComponent();
            List<string> themes = new List<string>() { "Найдите значение выражения: 2+2=?", "На тарелке 16 пирожков: 7 с рыбой, 5 с вареньем и 4 с вишней. Юля наугад выбирает один пирожок. Найдите вероятность того, что он окажется с вишней.", "Из пункта A круговой трассы выехал велосипедист. Через 30 минут он еще не вернулся в пункт А и из пункта А следом за ним отправился мотоциклист. Через 10 минут после отправления он догнал велосипедиста в первый раз, а еще через 30 минут после этого догнал его во второй раз. Найдите скорость мотоциклиста, если длина трассы равна 30 км. Ответ дайте в км/ч." };
            this.BindingContext = themes;
        }

       async private void Go_to_SelectionPage(object sender, EventArgs e)
        {
            int count_page_remove = 3; //количесвто страниц для перехода (3 назад)
            for (var counter = 1; counter < count_page_remove; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            await Navigation.PopAsync();
        }
    }
}