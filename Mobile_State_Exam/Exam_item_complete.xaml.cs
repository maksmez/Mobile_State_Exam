using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public Exam_item_complete(Exam exam, List<string> list_answer_user, ObservableCollection<Question> list_quset)
        {
            InitializeComponent();
            this.BindingContext = list_quset;
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