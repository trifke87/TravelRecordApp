using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelRecordApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainViewModel mainViewModel;
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            mainViewModel = new MainViewModel();
            BindingContext = mainViewModel;

            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.Travel.png", assembly);
        }

    }
}
