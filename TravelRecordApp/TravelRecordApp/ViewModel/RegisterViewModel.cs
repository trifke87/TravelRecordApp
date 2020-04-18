using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private Users user;

        public Users User
        {
            get { return user; }
            set 
            { 
                user = value;
                OnPropertyChanged("User");
            }
        }


        private string email;

        public string Email
        {
            get { return email; }
            set 
            { 
                email = value;
                User = new Users()
                {
                    Email = Email,
                    Password = Password,
                    ConfirmPassword = ConfirmPassword
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set 
            { 
                password = value;
                User = new Users()
                {
                    Email = Email,
                    Password = Password,
                    ConfirmPassword = ConfirmPassword
                };
                OnPropertyChanged("Password");
            }
        }

        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set 
            { 
                confirmPassword = value;
                User = new Users()
                {
                    Email = Email,
                    Password = Password,
                    ConfirmPassword = ConfirmPassword
                };
                OnPropertyChanged("ConfirmPassword");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public RegisterUserCommand RegisterUserCommand { get; set; }

        public RegisterViewModel()
        {
            User = new Users();
            RegisterUserCommand = new RegisterUserCommand(this);
        }

        public async void RegisterNewUser()
        {
            if (password == confirmPassword)
            {
                Users.InsertUsersAsync(User);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Password don't mach", "Ok");
            }
        }
    }
}
