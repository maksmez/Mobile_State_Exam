using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_State_Exam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Statistic_item_exam : ContentPage
    {
        ViewCell lastCell;
        Exam exam = new Exam();
        ObservableCollection<Exam> exam_list;

        public Statistic_item_exam(ObservableCollection<Exam> list_exam)
        {
            InitializeComponent();
            this.BindingContext = list_exam;
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