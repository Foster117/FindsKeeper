using Model.Application.Finds;
using Model.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class FindOwerviewWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        FindImage _selectedImage;
        int _imageCounter = 0;
        string _sliderInfo;
        public FindImage SelectedImage { get {
                return _selectedImage;
            } 
            private set {
                _selectedImage = value;
                OnPropertyChanged(nameof(SelectedImage));
            }
        }
        public string SliderInfo
        {
            get
            {
                if (Find.Images.Count == 0)
                {
                    return "";
                }
                return _sliderInfo = _imageCounter + 1 + " of " + Find.Images.Count;
            }
            private set
            {
                OnPropertyChanged(nameof(SliderInfo));
            }
        }
        public DetailedFindModel Find { get; set; }
        public ICommand PreviousImageCommand { get; set; }
        public ICommand NextImageCommand { get; set; }
        
        //ctor
        public FindOwerviewWindowViewModel(DetailedFindModel find)
        {
            Find = find;
            SelectedImage = find.Images.FirstOrDefault();
            PreviousImageCommand = new DelegateCommand(GetPreviousImage, CanGetImage);
            NextImageCommand = new DelegateCommand(GetNextImage, CanGetImage);
        }

        private void GetPreviousImage(object obj)
        {
            _imageCounter--;
            ChangeSelectedImage();
        }
        private void GetNextImage(object obj)
        {
            _imageCounter++;
            ChangeSelectedImage();
        }
        private bool CanGetImage(object arg)
        {
            if (Find.Images.Count <= 1)
            {
                return false;
            }
            return true;
        }

        private void ChangeSelectedImage()
        {
            if (_imageCounter < 0)
            {
                _imageCounter = Find.Images.Count - 1;
            }
            if (_imageCounter == Find.Images.Count)
            {
                _imageCounter = 0;
            }
            SelectedImage = Find.Images[_imageCounter];
            SliderInfo = "";    //Updating SliderInfo property
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
