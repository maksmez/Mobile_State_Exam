using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_State_Exam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test_item : ContentPage
    {
        Question quest_object = new Question();
        Theme theme_odject = new Theme();
        int num = 0;
        public Test_item(Theme theme)
        {
            theme_odject = theme;
            InitializeComponent();
            theme.count_correct  = 0;
            theme.count_wrong = 0;
            theme.total_score = 0;
            theme.SaveData(theme);
            check_answer();
        }


        async private void Go_to_SelectionPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void check_answer()
        {
            if (num > 14)
            {
                double a = theme_odject.count_correct + theme_odject.count_wrong;
                double b = (Convert.ToDouble(theme_odject.count_correct) / a) * 100;
                theme_odject.total_score = Convert.ToInt32(b);
                if (theme_odject.total_score >= 80)
                {
                    theme_odject.SaveData(theme_odject);
                    await DisplayAlert("Ура!", "Тест пройден на " + Convert.ToString(theme_odject.total_score) + "%", "Завершить");
                    await Navigation.PopAsync();
                }
                else
                {
                    theme_odject.SaveData(theme_odject);
                    await DisplayAlert("Эх!", "Тест пройден на " + Convert.ToString(theme_odject.total_score) + "%", "Завершить");
                    await Navigation.PopAsync();
                }
                return;
            }
            quest_object = quest_object.LoadData(theme_odject.id);
            this.BindingContext = quest_object;
            answer.Text = "";
            num = num + 1;
            question_label.Text = "Вопрос № " + Convert.ToString(num);
        }
        async private void Button_Check(object sender, EventArgs e)
        {
            if (answer.Text == "")
            {
                await DisplayAlert("Внимание!", "Пустое значение!", "Ок");
                return;
            }
            if (answer.Text.ToLower() == quest_object.answer.ToLower())
            {
                int count = theme_odject.count_correct + 1;
                theme_odject.count_correct = count;
                await DisplayAlert("Молодец!", "Задача решена правильно!", "Далее");
                check_answer();
            }
            else
            {
                int count = theme_odject.count_wrong + 1;
                theme_odject.count_wrong = count;
                await DisplayAlert("Ошибка!", "Задача решена неправильно!", "Далее");
                check_answer();
            }
        }

        async private void Button_Pass(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Внимание!", "Пропуск вопроса будет засчитан как неправильный!", "Продолжить", "Отмена");
            if (result)
            {
                int count = theme_odject.count_wrong + 1;
                theme_odject.count_wrong = count;
                check_answer();
            }
        }
    }
}