using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using Syncfusion.UI.Xaml.Spreadsheet.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CleanSlate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        // init the theme manager so the app can be customized!
        ThemeManagerLite themeManager = new ThemeManagerLite();

        public MainWindow(string[] args)
        {
            InitializeComponent();

            // set handlers
            // load saved user settings
            themeManager.ChangeTheme(Properties.Settings.Default.Theme);

            this.Height = Properties.Settings.Default.MainWindowHeight;
            this.Width = Properties.Settings.Default.MainWindowWidth;

        }


        // sets the theme on click from the theme radio button list
        private void SetTheme_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            string theme = radioButton.Content.ToString();
            themeManager.ChangeTheme(theme);
        }

        // various use of the Metro popup
        private async void Message_ClickAsync(object sender, RoutedEventArgs e)
        {
            MessageDialogResult res = await this.ShowMessageAsync("Hey, Listen!", "These are just some controls to take up space :)",
                MessageDialogStyle.AffirmativeAndNegative);

            if (res == MessageDialogResult.Affirmative)
            {
                await this.ShowMessageAsync("You clicked OK! ", res.ToString());
            }
        }

        // launches the SubWindow form via dialog
        private void menuinformation_Click(object sender, RoutedEventArgs e)
        {
            SubWindow subWindow = new SubWindow();
            subWindow.ShowDialog();
        }

        // this allows the user to drag the app by clicking and holding anywhere on the window!
        private void Mainwindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        // persist user resize because its nice to have and easy to do
        private async void Mainwindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    this.Invoke(() => { Properties.Settings.Default.MainWindowHeight = (int)Height; });
                    this.Invoke(() => { Properties.Settings.Default.MainWindowWidth = (int)Width; });
                    Properties.Settings.Default.Save();
                }
                catch (Exception ex)
                {
                    ShowMessage("Hey, listen!", ex.Message);
                }
            });
        }

        private async void menusave_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {

                }
                catch (Exception ex)
                {
                    ShowMessage("Hey, listen!", ex.Message);
                }
                Loading(false);
            });
        }

        private async void menuopen_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Loading(true);

                try
                {

                }
                catch (Exception ex)
                {
                    ShowMessage("Hey, listen!", ex.Message);
                }
                Loading(false);
            });
        }

        private async void menusaveas_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {

                }
                catch (Exception ex)
                {
                    ShowMessage("Hey, listen!", ex.Message);
                }
                Loading(false);
            });
        }

        private async void menunew_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Loading(true);
                try
                {

                }
                catch (Exception ex)
                {
                    ShowMessage("Hey, listen!", ex.Message);
                }
                Loading(false);
            });
        }

        private async void ShowMessage(string title, string message)
        {
            await this.Invoke(async () => { await this.ShowMessageAsync(title, message); });
        }

        private void Loading(bool load)
        {
            loader.Invoke(() => { loader.IsIndeterminate = load; });
        }
    }
}
