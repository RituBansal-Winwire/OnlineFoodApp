using Newtonsoft.Json;
using OnlineFoodApp.Models;
using OnlineFoodApp.Services;
using OnlineFoodApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using System.Xml.Linq;
using Xamarin.Forms;

namespace OnlineFoodApp.ViewModels
{
    public class RestaurantModelView : INotifyPropertyChanged
    {
        private ServiceData _apiServices = new ServiceData();
        public RestaurantModelView()
        {
            GetCommand = new Command(OnGet);
            AddCommand = new Command(OnAdd);
            UpdateCommand = new Command(OnUpdate);
            DeleteCommand = new Command(OnDelete);
        }
        public ICommand AddCommand { protected set; get; }
        public ICommand UpdateCommand { protected set; get; }
        public ICommand DeleteCommand { protected set; get; }
        public ICommand GetCommand { protected set; get; }

        public event PropertyChangedEventHandler PropertyChanged;
        private string _dname;
        private string _address;
        private int _price;
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                var args = new PropertyChangedEventArgs(nameof(Id));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string DName
        {
            get { return _dname; }
            set
            {
                _dname = value;
                var args = new PropertyChangedEventArgs(nameof(DName));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                var args = new PropertyChangedEventArgs(nameof(Address));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                var args = new PropertyChangedEventArgs(nameof(Price));
                PropertyChanged?.Invoke(this, args);
            }
        }

        async public void OnAdd()
        {
            if (_dname != "")
            {
                var restData = new Restaurant { displayName = DName, address = _address, priceForTwo = _price };
                var data = await _apiServices.PostRestaurants(restData,"POST");
                if (data != 0) {
                    await Application.Current.MainPage.DisplayAlert("SaveAlert","Data Saved Successfully","Ok");
                }
            }
        }

        async public void OnUpdate()
        {
            if (_id != 0)
            {
                var restData = new Restaurant {id=_id ,displayName = DName, address = _address, priceForTwo = _price };
                var data = await _apiServices.PostRestaurants(restData, "PUT");
                if (data != 0)
                {
                    await Application.Current.MainPage.DisplayAlert("SaveAlert", "Data Updated Successfully", "Ok");
                }
            }
        }

        async public void OnDelete()
        {
            if (_id != 0)
            {
                var data = await _apiServices.PostRestaurants(null,"DELETE",_id);
                if (data != 0)
                {
                    await Application.Current.MainPage.DisplayAlert("SaveAlert", "Data Removed Successfully", "Ok");
                }
            }
        }

        async public void OnGet()
        {
            if (Id != 0)
            {
                await _apiServices.GetRestaurants(list =>
                {
                    foreach (Restaurant item in list)
                    {
                        if (item.id == Id)
                        {
                            DName = item.displayName;
                            Address = item.address;
                            Price = item.priceForTwo;
                        }
                    }

                });

                if (DName == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Get", "No data found", "Ok");
                }
            }
            else {
                await Application.Current.MainPage.DisplayAlert("Get", "ID cannot be blank", "Ok");
            }
        }
    }
}
