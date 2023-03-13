using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using OnlineFoodApp.Models;
using System.Xml.Linq;
using OnlineFoodApp.Services;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.ConstrainedExecution;
using static System.Net.WebRequestMethods;
using System.Collections;

namespace OnlineFoodApp.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        private ServiceData _apiServices = new ServiceData();
       
        public ObservableCollection<Restaurant> items { get; set; }
        public ObservableCollection<Restaurant> itemlist { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private string _searchText { get; set; }

        public string searchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value) {
                    _searchText = value;
                    var args = new PropertyChangedEventArgs(nameof(searchText));
                    PropertyChanged?.Invoke(this, args);
                    FilterItems();
                }
            }
        }
        private ObservableCollection<Restaurant> _filteredItems;
        public ObservableCollection<Restaurant> FilteredItems
        {
            get { return _filteredItems; }
            set
            {
                if (_filteredItems != value)
                {
                    _filteredItems = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilteredItems)));
                }
            }
        }

        public ObservableCollection<Restaurant> Itemlist
        {
            get { return itemlist; }
            set
            {
                itemlist = value;
                var args = new PropertyChangedEventArgs(nameof(Itemlist));
                PropertyChanged?.Invoke(this, args);
            }
        }
       public HomePageViewModel()
        {
            
            FilteredItems = new ObservableCollection<Restaurant>();
            GetRestaurants();
        }

        private void FilterItems()
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                GetRestaurants();
               
            }
            else
            {
                GetRestaurants(searchText);
                 
            }
        }

        async public void GetRestaurants(string searchText = null)
        {
            Itemlist = new ObservableCollection<Restaurant>();
            await _apiServices.GetRestaurants(list =>
            {
                foreach (Restaurant item in list)
                    Itemlist.Add(item);
            });
           
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                FilteredItems = new ObservableCollection<Restaurant>(Itemlist.Where(item => item.displayName.ToLower().Contains(searchText.ToLower())));
                itemlist.Clear();
                Itemlist = FilteredItems;
            }
           
        }

    }
}
