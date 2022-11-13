using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhotoRecognition.Resources.XAMLElement
{
    public partial class ResultShow : UserControl
    {
        public ResultShow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty MainImageUriProperty = DependencyProperty.Register(nameof(MainImageUri), typeof(Uri), typeof(ResultShow), new FrameworkPropertyMetadata(new Uri("..\\Stubs\\ResultShowMainImageStub.png", UriKind.Relative)));

        public string MainImageUri
        {
            get => (string)GetValue(MainImageUriProperty);
            set => SetValue(MainImageUriProperty, value);
        }

        public static readonly DependencyProperty WhaleNameProperty = DependencyProperty.Register(
                                                                         nameof(WhaleName),
                                                                         typeof(string),
                                                                         typeof(ResultShow),
                                                                         new FrameworkPropertyMetadata(
                                                                             defaultValue: "",
                                                                             flags: FrameworkPropertyMetadataOptions.AffectsMeasure,
                                                                             propertyChangedCallback: new PropertyChangedCallback(OnWhaleNameChanged)));

        public string WhaleName
        {
            get => (string)GetValue(WhaleNameProperty);
            set => SetValue(WhaleNameProperty, value);
        }

        private static void OnWhaleNameChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            ResultShow resultShowresultShow = (ResultShow)dependencyObject;

            resultShowresultShow.TextBoxUnderLineWhaleName.Text = (string)dependencyObject.GetValue(WhaleNameProperty);
        }

        public static readonly DependencyProperty IDProperty = DependencyProperty.Register(nameof(ID),
                                                                                           typeof(string),
                                                                                           typeof(ResultShow),
                                                                                           new FrameworkPropertyMetadata(
                                                                                               defaultValue: "ID:0",
                                                                                               flags: FrameworkPropertyMetadataOptions.AffectsMeasure,
                                                                                               propertyChangedCallback: new PropertyChangedCallback(OnIDChanged)));

        public string ID
        {
            get => (string)GetValue(IDProperty);
            set => SetValue(IDProperty, value);
        }

        private static void OnIDChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            ((ResultShow)dependencyObject).TextBlockID.Text = "ID:" + e.NewValue;
        }

        public static readonly DependencyProperty ElemetsProperty = DependencyProperty.Register(nameof(Elemets),
                                                                                                typeof(object),
                                                                                                typeof(ResultShow),
                                                                                                new FrameworkPropertyMetadata(
                                                                                                    defaultValue: null,
                                                                                                    flags: FrameworkPropertyMetadataOptions.AffectsMeasure,
                                                                                                    propertyChangedCallback: new PropertyChangedCallback(OnElemetsChanged)));

        public object Elemets
        {
            get => GetValue(ElemetsProperty);
            set => SetValue(ElemetsProperty, value);
        }

        private static void OnElemetsChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            ToggleButton toggleButton = ((ResultShow)dependencyObject).ToggleButtonExpander;

            if (e.NewValue.ToString() == "System.Windows.FrameworkPropertyMetadata")
            {
                toggleButton.Visibility = Visibility.Collapsed;
            } else
            {
                toggleButton.Visibility = Visibility.Visible;
            }
        }

        private void Click_Expander(object sender, RoutedEventArgs e)
        {
            GridContent.Visibility = (bool)((ToggleButton)sender).IsChecked ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
