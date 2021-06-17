using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using mxskintool.ViewModels;

namespace mxskintool.Views
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private async void OnGetAssetPathButtonWasPressed(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog folderDialog = new OpenFolderDialog();
            var assetPath = await folderDialog.ShowAsync(this);
            if (assetPath != null)
            {
                // Get the context
                var context = this.DataContext as MainWindowViewModel;
                if (context != null)
                    context.AssetPath = assetPath;
            }
        }
    }
}