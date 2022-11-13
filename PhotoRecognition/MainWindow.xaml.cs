using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhotoRecognition
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Size Change Events

        private void WindowClose(object sender, RoutedEventArgs e)
        {
            WindowMain.Close();
        }

        private void WindowMaxiLize(object sender, RoutedEventArgs e)
        {
            if (WindowMain.WindowState == System.Windows.WindowState.Maximized)
            {
                WindowMain.WindowState = System.Windows.WindowState.Normal;

            }
            else if (WindowMain.ActualHeight > (System.Windows.SystemParameters.PrimaryScreenHeight / 2)
                    || WindowMain.ActualWidth > (System.Windows.SystemParameters.PrimaryScreenWidth / 2))
            {
                WindowMain.WindowState = System.Windows.WindowState.Maximized;
            }
        }

        private void WindowMinimiLize(object sender, RoutedEventArgs e)
        {
            WindowMain.WindowState = System.Windows.WindowState.Minimized;
        }

        #endregion

        public static void ThemeChage(int themeNumber)
        {
            Uri uri;

            switch (themeNumber)
            {
                case 0:
                    uri = new Uri("Resources\\Themes\\Colors\\Black.xaml", UriKind.Relative);
                    break;
                case 1:
                    uri = new Uri("Resources\\Themes\\Colors\\Ligth.xaml", UriKind.Relative);
                    break;
                default:
                    uri = new Uri("Resources\\Themes\\Colors\\Dark.xaml", UriKind.Relative);
                    break;
            }

            ResourceDictionary colorResourceDictionary = Application.LoadComponent(uri) as ResourceDictionary;

            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(colorResourceDictionary);
        }

        public void PatchParameter(string path)
        {
            /*ScriptEngine engine = Python.CreateEngine();
            ScriptEngine scope = engine.CreateScope();
            scope.SetVariable("path", path);
            engine.ExecuteFile("Script.py", scope);*/
        }

        private void ScriptStart(object sender, RoutedEventArgs e)
        {
            if (TextBoxWithButtonDataPath.Text != "")
            {
                MessageBox.Show("Папка с фотографиями не вабрана.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public static bool OpenFolderDialog(string title, ref string path)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                RestoreDirectory = true,
                Title = title,
                ShowHiddenItems = true,
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            using (dialog)
            {
                if (Directory.Exists(path))
                    dialog.InitialDirectory = path;
                dynamic xRes = dialog.ShowDialog();
                if (CommonFileDialogResult.Ok == xRes)
                    path = dialog.FileName;
                else if (CommonFileDialogResult.Cancel == xRes && !Directory.Exists(path))
                {
                    path = Environment.GetEnvironmentVariable("SYSTEMDRIVE");
                    return false;
                }
            }
            if (0 < path.Length && '\\' != path[path.Length - 1])
                path += "\\";

            return true;

        }

        private void ShowResult()
        {
            GridStart.Visibility = Visibility.Collapsed;
            GridResult.Visibility = Visibility.Visible;
        }

        private void Click_ShowFinishedResult(object sender, RoutedEventArgs e)
        {
            //string puth = "";
            ShowResult();
            //if(OpenFolderDialog("Выберите папку с результатами.", ref puth))
            //{
            //    ShowResult();
            //} else
            //{
            //    MessageBox.Show("Папка с фотографиями не вабрана.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
        }

        private void Click_BackToGridStart(object sender, RoutedEventArgs e)
        {
            GridStart.Visibility = Visibility.Visible;
            GridResult.Visibility = Visibility.Collapsed;
        }

        private void Click_Settings(object sender, RoutedEventArgs e)
        {
            BorderSettings.Visibility = BorderSettings.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}