using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_State_Exam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Theory : ContentPage
    {
        ViewCell lastCell;
        Science science_object = new Science();
        Theme them = new Theme();
        public Theory(Science science)
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
            Theme theme = args.SelectedItem as Theme;
            if (theme != null)
            {
                // Снимаем выделение
                list_theory.SelectedItem = null;
                // Переходим на страницу редактирования элемента 
                await Navigation.PushAsync(new Theory_item(theme));
            }
        }
    }

}