using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class PostDetailViewModel : INotifyPropertyChanged
    {
        private string userId;

        public string UserId
        {
            get { return userId; }
            set 
            { 
                userId = value;
                OnPropertyChanged("UserId");
            }
        }

        private string id;

        public string Id
        {
            get { return id; }
            set 
            { 
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string categoryId;

        public string CategoryId
        {
            get { return categoryId; }
            set 
            { 
                categoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }

        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set 
            { 
                categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set 
            { 
                address = value;
                OnPropertyChanged("Address");
            }
        }


        private string venueName;

        public string VenueName
        {
            get { return venueName; }
            set 
            { 
                venueName = value;
                OnPropertyChanged("VenueName");
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
                    VenueName = VenueName,
                    Id = Id,
                    UserId = UserId,
                    CategoryId = CategoryId,
                    CategoryName = CategoryName,
                    Address = Address,
                    Latitude = Latitude,
                    Longitude = Longitude,
                    Distance = Distance
                };
                OnPropertyChanged("Experience");
            }
        }

        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set 
            { 
                latitude = value;
                OnPropertyChanged("Latitude");
            }
        }

        private double longitude;

        public double Longitude
        {
            get { return longitude; }
            set 
            { 
                longitude = value;
                OnPropertyChanged("Longitude");
            }
        }

        private int distance;

        public int Distance
        {
            get { return distance; }
            set 
            {
                distance = value;
                OnPropertyChanged("Distance");
            }
        }


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

        public DeletePostCommand DeletePostCommand { get; set; }
        public UpdatePostCommand UpdatePostCommand { get; set; }

        public string LongitudeAndLatitude { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public PostDetailViewModel(Post post)
        {
            Post = new Post()
            {
                Experience = post.Experience,
                VenueName = post.VenueName,
                CategoryName = post.CategoryName,
                Address = post.Address,
                Latitude = post.Latitude,
                Longitude = post.Longitude,
                Distance = post.Distance,
                CategoryId = post.CategoryId,
                Id = post.Id,
                UserId = post.UserId
            };

            Id = post.Id;
            UserId = post.UserId;
            CategoryId = post.CategoryId;
            CategoryName = post.CategoryName;
            Address = post.Address;
            Experience = post.Experience;
            VenueName = post.VenueName;
            Latitude = post.Latitude;
            Longitude = post.Longitude;
            Distance = post.Distance;
            LongitudeAndLatitude = $"{post.Latitude}, {post.Longitude}";

            DeletePostCommand = new DeletePostCommand(this);
            UpdatePostCommand = new UpdatePostCommand(this);
        }

        public async void DeletPost(Post post)
        {
            await Post.DeletePostAsync(post);
            await App.Current.MainPage.DisplayAlert("Success", "Experience has been deleted", "Ok");
        }

        public async void UpdatePost(Post post)
        {
            post.Experience = Post.Experience;

            Post.UpdatePostAsync(post);
            await App.Current.MainPage.DisplayAlert("Success", "Experience succesfully insert", "Ok");
        }
    }
}
