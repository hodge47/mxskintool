using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using JetBrains.Annotations;

namespace mxskintool.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _assetPath = string.Empty;

        [NotNull]
        public string AssetPath
        {
            get => _assetPath;
            set
            {
                if (value != _assetPath)
                {
                    _assetPath = value;
                    OnPropertyChanged(nameof(AssetPath));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindowViewModel()
        {
            AssetPath = "No directory Selected";
        }
    }
}