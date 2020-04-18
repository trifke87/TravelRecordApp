using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModel.Commands
{
    public class SavePostCommand : ICommand
    {
        NewTravelViewModel NewTravelViewModel;

        public event EventHandler CanExecuteChanged;

        public SavePostCommand(NewTravelViewModel newTravelViewModel)
        {
            NewTravelViewModel = newTravelViewModel;
        }

        public bool CanExecute(object parameter)
        {
            var post = (Post)parameter;

            if(post != null)
            {
                if (string.IsNullOrEmpty(post.Experience))
                    return false;

                if (post.Venue != null)
                    return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            var post = (Post)parameter;
            NewTravelViewModel.PublishPost(post);
        }
    }
}
