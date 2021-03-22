using Model.Application.Finds;
using Model.Database.Services;
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
        public event PropertyChangedEventHandler PropertyChanged;
        private PagingResult<List<FindsQuickViewModel>> _currentPage;
        private List<FindsQuickViewModel> _allFinds;
        private int _findsOffset = 0;
        private int _pageSize = 20;
        private readonly IFindService _findService;
        public ICommand PreviousFindsCommand { get; set; }
        public ICommand NextFindsCommand { get; set; }

        public MainWindowViewModel()
        {
            _findService = new FindService();
            NextFindsCommand = new DelegateCommand(GetNextFinds, CanGetNextFinds);
            PreviousFindsCommand = new DelegateCommand(GetPreviousFinds, CanGetPreviousFinds);
        }

        public List<FindsQuickViewModel> AllFinds {
            get {
                if (_currentPage == null)
                {
                    _currentPage = _findService.GetFindsPage(_pageSize, 0);
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
            _currentPage = _findService.GetFindsPage(_pageSize, _findsOffset);
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
            _currentPage = _findService.GetFindsPage(_pageSize, _findsOffset);
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

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
