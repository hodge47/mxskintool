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
                {
                    context.AssetPath = assetPath;
                    // Get skinning files from directory
                    context.GetMapFilesInDirectory();
                    context.GetJmFilesInDirectory();
                }
            }
        }

        private void OnRemoveSelectedMapFilesButtonWasPressed()
        {
            
        }

        private async void OnRenameAll(object sender, RoutedEventArgs e)
        {
            var context = this.DataContext as MainWindowViewModel;
            if (context != null)
            {
                var result = await MessageBox.Show(this, "Test", "Test title", MessageBox.MessageBoxButtons.YesNoCancel);
            }
        }
    }
}