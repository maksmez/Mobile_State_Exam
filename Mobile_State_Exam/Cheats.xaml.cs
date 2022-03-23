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

    public partial class Cheats : ContentPage
    {
        ViewCell lastCell;
        Science science_object = new Science();
        Cheat cheat = new Cheat();
        public Cheats(Science science)
        {
            InitializeComponent();
            science_object.id = science.id;
            this.BindingContext = cheat.LoadData(science_object.id);
            
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
            Cheat cheat = args.SelectedItem as Cheat;
            if (cheat != null)
            {
                // Снимаем выделение
                list_cheat.SelectedItem = null;
                // Переходим на страницу редактирования элемента 
                await Navigation.PushAsync(new Cheats_item(cheat));
            }
        }
    }
}