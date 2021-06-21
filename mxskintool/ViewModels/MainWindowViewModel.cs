using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using JetBrains.Annotations;
using mxskintool.Models;
using mxskintool.ViewModels;

namespace mxskintool.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private SkinEditingFileUtilities _skinEditingUtilities;
        
        private string _assetPath = string.Empty;
        private List<SkinningFile> _mapFiles = new List<SkinningFile>();
        private List<SkinningFile> _jmFiles = new List<SkinningFile>();
        private Dictionary<string, string> _dynos = new Dictionary<string, string>()
        {
            {"Honda (450f)", "crf450v2017"}, {"Husqvarna (450f)", "fc450v2016"},
            {"Kawasaki (450f)", "kx450fv2016"}, {"KTM (450f)", "450sxfv2016"}, {"Suzuki (450f)", "rmz450v2018"},
            {"Yamaha (450f)", "yz450fv2014"}, {"KTM (350f)", "350sxfv2016"}, {"Honda (250f)", "crf250v2018"},
            {"Husqvarna (250f)", "fc250v2016"}, {"Kawasaki (250f)", "kx250fv2017"}, {"KTM (250f)", "250sxfv2016"},
            {"Suzuki (250f)", "rmz250v2010"}, {"Yamaha (250f)", "yz250fv2014"}, {"Honda (250t)", "cr250"},
            {"Kawasaki (250t)", "kx250"}, {"KTM (250t)", "250sx"}, {"Suzuki (250t)", "rm250"}, {"Yamaha (250t)", "yz250"},
            {"Honda (125)", "cr125"}, {"Kawasaki (125)", "kx125"}, {"KTM (125)", "125sx"}, {"Yamaha (125)", "yz125"},
            {"Suzuki (125)", "rm125"}, {"Rider Body", "rider_body"}, {"Helmet", "rider_head"}, {"Wheels", "wheels"}
        }; 
        
        public SkinEditingFileUtilities SkinEditingUtilities
        {
            get => _skinEditingUtilities;
            set => _skinEditingUtilities = value ?? throw new ArgumentNullException(nameof(value));
        }

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
        
        public List<string> MapFiles
        {
            get
            {
                var mapFiles = new List<string>();
                foreach (var map in _mapFiles)
                {
                    mapFiles.Add(map.FileName);
                }

                return mapFiles;
            }
        }
        
        public List<string> JmFiles
        {
            get
            {
                var jmFiles = new List<string>();
                foreach (var jm in _jmFiles)
                {
                    jmFiles.Add(jm.FileName);
                }

                return jmFiles;
            }
        }

        public List<string> Dynos
        {
            get
            {
                var dynos = new List<string>();
                foreach (var dyno in _dynos.Keys)
                {
                    dynos.Add(dyno);
                }

                return dynos;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindowViewModel()
        {
            _skinEditingUtilities = new SkinEditingFileUtilities();
            
            AssetPath = "No directory Selected";
        }

        /// <summary>
        /// Gets all the map files from the AssetsDirectory
        /// </summary>
        public void GetMapFilesInDirectory()
        {
            if (AssetPath != "No directory Selected" && !string.IsNullOrEmpty(AssetPath))
            {
                var filePaths = _skinEditingUtilities.GetFilesInDirectory(AssetPath, "*.png");
                List<SkinningFile> mapFiles = new List<SkinningFile>();
                foreach (var filePath in filePaths)
                {
                    var skinningFile = new SkinningFile() { FilePath = filePath, FileName = Path.GetFileName(filePath)};
                    mapFiles.Add(skinningFile);
                }

                _mapFiles = mapFiles;
                
                // Invoke fake property was changed
                OnPropertyChanged(nameof(MapFiles));
            }
        }
        /// <summary>
        /// Removes all the map files from MapFiles at the specified indices
        /// </summary>
        /// <param name="indices"></param>
        public void RemoveMapFilesFromList(int[] indices)
        {
            for (int i = 0; i < indices.Length; i++)
            {
                MapFiles.RemoveAt(indices[i]);
            }
        }
        
        /// <summary>
        /// Gets all the JM files from the AssetsDirectory
        /// </summary>
        public void GetJmFilesInDirectory()
        {
            if (AssetPath != "No directory Selected" && !string.IsNullOrEmpty(AssetPath))
            {
                var filePaths = _skinEditingUtilities.GetFilesInDirectory(AssetPath, "*.jm");
                List<SkinningFile> jmFiles = new List<SkinningFile>();
                foreach (var filePath in filePaths)
                {
                    var skinningFile = new SkinningFile() { FilePath = filePath, FileName = Path.GetFileName(filePath)};
                    jmFiles.Add(skinningFile);
                }

                _jmFiles = jmFiles;
                
                // Invoke fake property was changed
                OnPropertyChanged(nameof(JmFiles));
            }
        }
        
        public struct SkinningFile
        {
            public string FileName;
            public string FilePath;
        }
    }
}