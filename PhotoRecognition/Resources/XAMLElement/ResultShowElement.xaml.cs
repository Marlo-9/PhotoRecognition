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
    public partial class ResultShowElement : UserControl
    {
        public ResultShowElement()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ImageUriProperty = DependencyProperty.Register(nameof(ImageUri), typeof(Uri), typeof(ResultShowElement), new FrameworkPropertyMetadata(new Uri("..\\Stubs\\ResultShowMainImageStub.png", UriKind.Relative)));

        public string ImageUri
        {
            get => (string)GetValue(ImageUriProperty);
            set => SetValue(ImageUriProperty, value);
        }
    }
}
