using Model.Application.Finds;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class MainWindowViewModel
    {
        private readonly IDialogService _dialogService;
        public AuthenticationViewModel AuthenticationVM { get; set; }
        public AllFindsTabViewModel AllFindsTabVM { get; set; }
                
        //ctor
        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            AuthenticationVM = new AuthenticationViewModel(dialogService);
            AllFindsTabVM = new AllFindsTabViewModel(dialogService);
        }
    }
}
