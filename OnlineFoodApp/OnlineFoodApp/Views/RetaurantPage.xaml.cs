using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineFoodApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineFoodApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RetaurantPage : ContentPage
    {
        public RetaurantPage()
        {
            InitializeComponent();
            BindingContext = new RestaurantModelView();
        }
    }
}