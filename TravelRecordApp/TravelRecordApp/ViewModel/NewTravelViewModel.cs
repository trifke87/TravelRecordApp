using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class NewTravelViewModel : INotifyPropertyChanged
    {
        private Post post;

        public Post Post
        {
            get { return post; }
            set
            {
                post = value;
                OnPropertyChanged("Post");
            }
        }

        private Venue venue;

        public Venue Venue
        {
            get { return venue; }
            set
            {
                venue = value;
                Post = new Post()
                {
                    Experience = Experience,
                    Venue = Venue
                };
                OnPropertyChanged("Venue");
            }
        }

        private string experience;

        public string Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                Post = new Post()
                {
                    Experience = Experience,
                    Venue = Venue
                };
                OnPropertyChanged("Experience");
            }
        }
        public SavePostCommand SavePostCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public NewTravelViewModel()
        {
            Post = new Post();
            Venue = new Venue();
            SavePostCommand = new SavePostCommand(this);
        }

        public async void PublishPost(Post post)
        {
            try
            {                

                Post.InsertPostAsync(post);
                await App.Current.MainPage.DisplayAlert("Success", "Experience succesfully insert", "Ok");

            }

            catch (NullReferenceException nullRefException)
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Experience failure insert", "Ok");

            }

            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Experience failure insert" + ex, "Ok");

            }
        }
    }
}
