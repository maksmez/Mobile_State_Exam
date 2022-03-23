using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_State_Exam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Exam_item : ContentPage
    {
        Exam_Questions quest = new Exam_Questions();
        Exam exam2 = new Exam();
        ObservableCollection<Question> list_quset = new ObservableCollection<Question>();
        public Exam_item(Exam exam)
        {
            InitializeComponent();
            exam2 = exam;
            list_quset = quest.LoadExamQuestion(exam.id);
            this.BindingContext = list_quset;
            num_var.Text = exam.name_option;
        }


        async private void Go_to_Exams(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async private void Go_to_Exam_item_complete(object sender, EventArgs e)
        {
            exam2.count_correct = 0;
            exam2.count_wrong = 0;
            int flag = 0;
            IEnumerable<PropertyInfo> pInfos = (listview_quest as ItemsView<Cell>).GetType().GetRuntimeProperties();
            var templatedItems = pInfos.FirstOrDefault(info => info.Name == "TemplatedItems");
            var cells = templatedItems.GetValue(listview_quest);
            foreach (ViewCell cell in cells as Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell>)
            {
                var text = ((((cell.View as Grid).Children.Last() as StackLayout).Children.Last() as Frame).Children.Last() as Entry).Text;
                if (text == null)
                {
                    await DisplayAlert("Внимание!", "Пустое значение!", "Ок");
                    return;
                }
                if (list_quset[flag].answer.ToLower() == text.ToLower())
                {
                    exam2.count_correct++;
                }
                else
                {
                    exam2.count_wrong++;
                }
                flag++;
            }
            double a = exam2.count_correct + exam2.count_wrong;
            double b = (Convert.ToDouble(exam2.count_correct) / a) * 100;
            exam2.total_score = Convert.ToInt32(b);
            int count_page_remove = 3; //количесвто страниц для перехода (3 назад)
            for (var counter = 1; counter < count_page_remove; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            if (exam2.total_score >= 80)
            {
                quest.SaveData(exam2);
                await DisplayAlert("Ура!", "Вариант решен на " + Convert.ToString(exam2.total_score) + "%", "Завершить");
                await Navigation.PopAsync();
            }
            else
            {
                quest.SaveData(exam2);
                await DisplayAlert("Эх!", "Вариант решен на " + Convert.ToString(exam2.total_score) + "%", "Завершить");
                await Navigation.PopAsync();
            }
        }
    }
}