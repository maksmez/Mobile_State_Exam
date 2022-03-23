using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_State_Exam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Exams : ContentPage
    {
        ViewCell lastCell;
        Exam exam = new Exam();

        public Exams(Science science)
        {
            InitializeComponent();
            this.BindingContext = exam.LoadData(science.id);
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
       async private void list_ItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            Exam exam = args.SelectedItem as Exam;
            if (exam != null)
            {
                list_exams.SelectedItem = null;
                await Navigation.PushAsync(new Exam_item(exam));
            }
        }
    }
}