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
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IDialogService dialogService;
        public event PropertyChangedEventHandler PropertyChanged;
        private PagingResult<List<FindsQuickViewModel>> _currentPage;
        private List<FindsQuickViewModel> _allFinds;
        public FindsQuickViewModel SelectedItem { get; set; }
        private int _findsOffset = 0;
        private int _pageSize = 20;
        private IFindRepository _findRepository = new FindRepository();
        public ICommand PreviousFindsCommand { get; set; }
        public ICommand NextFindsCommand { get; set; }
        public ICommand OpenFindOwerviewWindowCommand { get; set; }
        public ICommand OpenRegWindowCommand { get; set; }


        //ctor
        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            NextFindsCommand = new DelegateCommand(GetNextFinds, CanGetNextFinds);
            PreviousFindsCommand = new DelegateCommand(GetPreviousFinds, CanGetPreviousFinds);
            OpenFindOwerviewWindowCommand = new DelegateCommand(OpenFindOverviewWindow);
            OpenRegWindowCommand = new DelegateCommand(OpenRegWindow);
        }

        public List<FindsQuickViewModel> AllFinds {
            get {
                if (_currentPage == null)
                {
                    _currentPage = _findRepository.GetFindsPage(_pageSize, 0);
                    _allFinds = _currentPage.Items;
                }
                return _allFinds;
            }
            private set
            {
                _allFinds = value;
                OnPropertyChanged(nameof(AllFinds));
            }
        }

        // Next Finds Command
        private void GetNextFinds(object obj)
        {
            _findsOffset += _pageSize;
            _currentPage = _findRepository.GetFindsPage(_pageSize, _findsOffset);
            AllFinds = _currentPage.Items;
        }
        private bool CanGetNextFinds(object arg)
        {
            return _currentPage.Offset + _pageSize < _currentPage.TotalCount;
        }
        ////////////////

        // Previous Finds Command
        private void GetPreviousFinds(object obj)
        {
            _findsOffset -= _pageSize;
            _currentPage = _findRepository.GetFindsPage(_pageSize, _findsOffset);
            AllFinds = _currentPage.Items;
        }
        private bool CanGetPreviousFinds(object arg)
        {
            if (_findsOffset == 0)
            {
                return false;
            }
            return true;
        }
        ////////////////
        
        // Open Find Overview Window Command
        private void OpenFindOverviewWindow(object obj)
        {
            if (obj != null)
            {
                DetailedFindModel find = _findRepository.GetFindById((obj as FindsQuickViewModel).Id);
                dialogService.OpenWindow(new FindOwerviewWindowViewModel(find));
            }
        }
        ////////////////

        private void OpenRegWindow(object obj)
        {
            dialogService.OpenWindow(new RegistrationWindowViewModel());
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
