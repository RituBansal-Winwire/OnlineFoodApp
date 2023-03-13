using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using OnlineFoodApp.Services;
using OnlineFoodApp.Models;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using OnlineFoodApp.Views;
using Xamarin.Essentials;

namespace OnlineFoodApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private ServiceData _apiServices = new ServiceData();
        public Action SendDataFromLogin;
        public Action DisplayInvalidLoginPrompt;
        public bool isLogin = false;
        public event PropertyChangedEventHandler PropertyChanged ;
        private string _uname;
        public string UName
        {
            get { return _uname; }
            set
            {
                _uname = value;
                var args = new PropertyChangedEventArgs(nameof(UName));
                PropertyChanged?.Invoke(this, args);
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                var args = new PropertyChangedEventArgs(nameof(Password));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public ICommand RegisterCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
            RegisterCommand = new Command(OnRegister);
        }
        async public void OnSubmit()
        {
            if (_uname != "" || password != "")
            {
                var data = await _apiServices.ValidateLogin(_uname, password);
                if (data != null)
                {
                    var userData = JsonConvert.DeserializeObject<User>(data);
                    Application.Current.Properties["UName"] = userData.username;
                    await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
                    isLogin=true;
                }
                else {
                    DisplayInvalidLoginPrompt();
                }
            }
        }

        async public void OnRegister()
        {
         
             await Application.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
            
        }
    }
}
