using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravelRecordApp.ViewModel.Commands
{
    public class RefreshCommand : ICommand
    {
        public HistoryViewModel HistoryViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public RefreshCommand(HistoryViewModel historyViewModel)
        {
            HistoryViewModel = historyViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            HistoryViewModel.RefreshPostAsync();
        }
    }
}
