using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRecordApp.Model
{
    public class Post : INotifyPropertyChanged
    {
        #region Properties

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


        private string experience;

        public string Experience
        {
            get { return experience; }
            set 
            { 
                experience = value;
                OnPropertyChanged("Experience");
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

        private DateTimeOffset _createdAt;

        public DateTimeOffset createdAt
        {
            get { return _createdAt; }
            set { _createdAt = value; }
        }


        private Venue venue;

        [JsonIgnore]
        public Venue Venue
        {
            get { return venue; }
            set 
            { 
                venue = value;

                if (venue.categories != null)
                {
                    var firstCategory = venue.categories.FirstOrDefault();

                    if (firstCategory != null)
                    {
                        CategoryId = firstCategory.id;
                        CategoryName = firstCategory.name;
                    }
                }

                if (venue.location != null)
                {
                    Address = venue.location.address;
                    Distance = venue.location.distance;
                    Latitude = venue.location.lat;
                    Longitude = venue.location.lng;
                }
                
                VenueName = venue.name;
                UserId = App.user.Id;

                OnPropertyChanged("Venue");
            }
        }


        #endregion

        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if(handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public static async void InsertPostAsync(Post post)
        {
            await App.postsTable.InsertAsync(post);
            await App.MobileService.SyncContext.PushAsync();
        }

        public static async void UpdatePostAsync(Post selectedPost)
        {
            await App.MobileService.GetTable<Post>().UpdateAsync(selectedPost);
        }

        public static async Task<bool> DeletePostAsync(Post selectedPost)
        {
            try
            {
                await App.postsTable.DeleteAsync(selectedPost);
                await App.MobileService.SyncContext.PushAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public static async Task<List<Post>> ReadFromPostAsync()
        {
            var post = await App.postsTable
                .Where(p => p.UserId == App.user.Id)
                .ToListAsync();

            return post;
        }

        public static Dictionary<string, int> PostCatagories(List<Post> posts)
        {
            var categories = (from p in posts
                              orderby p.CategoryId
                              select p.CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();

            foreach (var category in categories)
            {
                var count = (from post in posts
                             where post.CategoryName == category
                             select post).ToList().Count;

                categoriesCount.Add(category, count);
            }

            return categoriesCount;
        }
    }
}
