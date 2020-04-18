using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModel.Commands
{
    public class RegisterUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public RegisterViewModel RegisterViewModel { get; set; }

        public RegisterUserCommand(RegisterViewModel registerViewModel)
        {
            RegisterViewModel = registerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            var user = (Users)parameter;

            if (user == null)
                return false;

            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.ConfirmPassword))
                return false;

            if (user.Password != user.ConfirmPassword)
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            RegisterViewModel.RegisterNewUser();
        }
    }
}
