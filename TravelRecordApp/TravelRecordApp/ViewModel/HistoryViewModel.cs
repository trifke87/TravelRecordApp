using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class HistoryViewModel : INotifyPropertyChanged
    {
        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set 
            { 
                isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }
        public DeletePostListCommand DeletePostListCommand { get; set; }

        public RefreshCommand RefreshCommand { get; set; }
        public ObservableCollection<Post> Posts { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public HistoryViewModel()
        {
            Posts = new ObservableCollection<Post>();
            DeletePostListCommand = new DeletePostListCommand(this);
            RefreshCommand = new RefreshCommand(this);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public async Task<bool> UpdatePostsAsync()
        {
            try
            {
                var posts = await Post.ReadFromPostAsync();

                if (posts != null)
                {
                    Posts.Clear();
                    foreach (var post in posts)
                        Posts.Add(post);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async void DeletePostAsync(Post post)
        {
            await Post.DeletePostAsync(post);
        }

        public async void RefreshPostAsync()
        {
            isRefreshing = true;
            await UpdatePostsAsync();
            await AzureAppServiceHelper.SyncAsync();
            IsRefreshing = false;
        }
    }
}
