using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        //Users user;
        RegisterViewModel registerViewModel;
        public RegisterPage()
        {
            InitializeComponent();
            //user = new Users();
            //containerStackLayout.BindingContext = user;
            registerViewModel = new RegisterViewModel();
            BindingContext = registerViewModel;
        }

    }
}