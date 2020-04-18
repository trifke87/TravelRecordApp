using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravelRecordApp.ViewModel.Commands
{
     public class NavigationCommand : ICommand
    {
        public HomeViewModel HomeViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public NavigationCommand(HomeViewModel homeViewModel)
        {
            HomeViewModel = homeViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            HomeViewModel.Navigate();
        }
    }
}
