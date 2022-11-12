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

namespace PhotoRecognition.Resources.XAMLElement
{
    /// <summary>
    /// Логика взаимодействия для TextBoxWithButton.xaml
    /// </summary>
    public partial class TextBoxWithButton : UserControl
    {
        public TextBoxWithButton()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(TextBoxUnderLine),
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
            TextBoxWithButton textBoxUnderLine = (TextBoxWithButton)dependencyObject;

            TextBlock textBlock = textBoxUnderLine.TextBoxPlaceHolder;

            if (textBlock != null)
            {
                textBlock.Visibility = e.NewValue.ToString() != "" ? Visibility.Hidden : Visibility.Visible;
            }
        }

        public static readonly DependencyProperty PlaceHolderProperty = DependencyProperty.Register(nameof(PlaceHolder), typeof(string), typeof(TextBoxUnderLine));

        public string PlaceHolder
        {
            get => (string)GetValue(PlaceHolderProperty);
            set => SetValue(PlaceHolderProperty, value);
        }
    }
}
