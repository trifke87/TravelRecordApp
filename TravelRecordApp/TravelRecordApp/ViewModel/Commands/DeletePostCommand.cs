using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModel.Commands
{
    public class DeletePostCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public PostDetailViewModel PostDetailViewModel { get; set; }

        public DeletePostCommand(PostDetailViewModel postDetailViewModel)
        {
            PostDetailViewModel = postDetailViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var post = (Post)parameter;
            PostDetailViewModel.DeletPost(post);
        }
    }
}
