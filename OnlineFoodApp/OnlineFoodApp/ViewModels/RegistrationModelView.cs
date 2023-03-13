using OnlineFoodApp.Models;
using OnlineFoodApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Windows.Input;
using System.Xml.Linq;
using Xamarin.Forms;

namespace OnlineFoodApp.ViewModels
{
    public class RegistrationModelView : INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private ServiceData _apiServices = new ServiceData();
        public RegistrationModelView()
        {
            RegisterCommand = new Command(OnRegister);
        }

        public ICommand RegisterCommand { protected set; get; }

        public event PropertyChangedEventHandler PropertyChanged;
        private string _fname;
        private string _Lname;
        private string _email;
        private string _Usern;
        private string _Pass;
        public string FName
        {
            get { return _fname; }
            set
            {
                _fname = value;
                var args = new PropertyChangedEventArgs(nameof(FName));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public string LName
        {
            get { return _Lname; }
            set
            {
                _Lname = value;
                var args = new PropertyChangedEventArgs(nameof(LName));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                var args = new PropertyChangedEventArgs(nameof(Email));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string Usern
        {
            get { return _Usern; }
            set
            {
                _Usern = value;
                var args = new PropertyChangedEventArgs(nameof(Usern));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public string Pass
        {
            get { return _Pass; }
            set
            {
                _Pass = value;
                var args = new PropertyChangedEventArgs(nameof(Pass));
                PropertyChanged?.Invoke(this, args);
            }
        }

        async public void OnRegister()
        {
            if (_Usern != "")
            {
                var userdata = new User {username=_Usern,password=_Pass  };
                var data = await _apiServices.PostUserData(userdata);
                if (data != 0)
                {
                    await Application.Current.MainPage.DisplayAlert("SaveAlert", "Data Saved Successfully", "Ok");
                }
            }
        }

    }
}
