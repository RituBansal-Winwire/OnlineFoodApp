using OnlineFoodApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineFoodApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OnlineFoodApp.Views;
namespace OnlineFoodApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
       
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new RetaurantPage());
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
          //  HomePageViewModel vm =new HomePageViewModel();
          //  var obj=  vm.GetRestaurants(e.NewTextValue);
        }
    }
}