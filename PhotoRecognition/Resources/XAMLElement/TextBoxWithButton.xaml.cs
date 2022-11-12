using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using PhotoRecognition;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;

namespace PhotoRecognition.Resources.XAMLElement
{
    public partial class TextBoxWithButton : UserControl
    {
        public TextBoxWithButton()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(TextBoxWithButton),
                                                                         new FrameworkPropertyMetadata(
                                                                             defaultValue: "",
                                                                             flags: FrameworkPropertyMetadataOptions.AffectsMeasure,
                                                                             propertyChangedCallback: new PropertyChangedCallback(OnTextChanged)));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private static void OnTextChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            TextBoxWithButton textBoxWithButton = (TextBoxWithButton)dependencyObject;

            TextBlock textBlock = textBoxWithButton.TextBlockPlaceHolder;

            if (textBlock != null)
            {
                textBlock.Visibility = e.NewValue.ToString() != "" ? Visibility.Hidden : Visibility.Visible;
            }
        }

        public static readonly DependencyProperty PlaceHolderProperty = DependencyProperty.Register(nameof(PlaceHolder), typeof(string), typeof(TextBoxWithButton));

        public string PlaceHolder
        {
            get => (string)GetValue(PlaceHolderProperty);
            set => SetValue(PlaceHolderProperty, value);
        }

        private void Click_OpenFolderDialog(object sender, RoutedEventArgs e)
        {
            string puth = "";
            TextBoxWithButton textBoxWithButton = (TextBoxWithButton)((Grid)((Button)sender).Parent).Parent;

            if (MainWindow.OpenFolderDialog("Выберите папку с исходными данными.", ref puth))
            {
                textBoxWithButton.Text = puth;
                textBoxWithButton.TextBoxMain.Text = puth;
            }
            
        }
    }
}
