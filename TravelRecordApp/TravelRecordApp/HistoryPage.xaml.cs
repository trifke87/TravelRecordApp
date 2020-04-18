using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        HistoryViewModel HistoryViewModel;
        public HistoryPage()
        {
            InitializeComponent();
            HistoryViewModel = new HistoryViewModel();
            BindingContext = HistoryViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            HistoryViewModel.UpdatePostsAsync();

            await AzureAppServiceHelper.SyncAsync();
        }

        private void PostListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = postListView.SelectedItem as Post;

            if(selectedPost != null)
            {
                Navigation.PushAsync(new PostDetailPage(selectedPost));
            }
        }

        //private void MenuItem_Clicked(object sender, EventArgs e)
        //{
        //    var post = (Post)((MenuItem)sender).CommandParameter;
        //    HistoryViewModel.DeletePostAsync(post);

        //    HistoryViewModel.UpdatePostsAsync();
        //}

        //private async void postListView_Refreshing(object sender, EventArgs e)
        //{
        //    await HistoryViewModel.UpdatePostsAsync();
        //    postListView.IsRefreshing = false;
        //}
    }
}