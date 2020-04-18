using System;
using System.Collections.Generic;
using System.Text;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class HomeViewModel
    {
        public NavigationCommand NavigationCommand { get; set; }

        public HomeViewModel()
        {
            NavigationCommand = new NavigationCommand(this);
        }

        public async void Navigate()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewTravelPage());
        }
    }
}
