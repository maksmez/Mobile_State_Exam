using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_State_Exam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tests : ContentPage
    {
        ViewCell lastCell;
        Science science_object = new Science();
        Theme them = new Theme();
        public Tests(Science science)
        {
            InitializeComponent();
            science_object.id = science.id;
            this.BindingContext = them.LoadData(science_object.id);
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
            if (args.SelectedItemIndex >= 0)
            {
                bool result = await DisplayAlert("Внимание!", "Тест на 15 вопросов.\nДля прохождения теста необходимо набрать больше 80%.", "Начать", "Отмена");
                if (result)
                {
                    Theme theme = args.SelectedItem as Theme;
                    if (theme != null)
                    {
                        list_tests.SelectedItem = null;
                        await Navigation.PushAsync(new Test_item(theme));
                    }
                }
                else
                {
                    list_tests.SelectedItem = null;
                }
            }
        }
            
    }
}