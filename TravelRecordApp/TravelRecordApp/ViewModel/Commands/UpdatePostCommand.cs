using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModel.Commands
{
    public class UpdatePostCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public PostDetailViewModel PostDetailViewModel { get; set; }

        public UpdatePostCommand(PostDetailViewModel postDetailViewModel)
        {
            PostDetailViewModel = postDetailViewModel;
        }

        public bool CanExecute(object parameter)
        {
            var post = (Post)parameter;

            if (post == null || string.IsNullOrEmpty(post.Experience))
                return false;
            else
                return true;

        }

        public void Execute(object parameter)
        {
            var post = (Post)parameter;

            PostDetailViewModel.UpdatePost(post);
        }
    }
}
