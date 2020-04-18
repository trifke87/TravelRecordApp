using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModel.Commands
{
    public class DeletePostListCommand : ICommand
    {
        public HistoryViewModel HistoryViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public DeletePostListCommand(HistoryViewModel historyViewModel)
        {
            HistoryViewModel = historyViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
            var post = (Post)parameter;
            HistoryViewModel.DeletePostAsync(post);

            HistoryViewModel.UpdatePostsAsync();
        }
    }
}
