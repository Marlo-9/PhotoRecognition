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
    /// Логика взаимодействия для ResultShow.xaml
    /// </summary>
    public partial class ResultShow : UserControl
    {
        public ResultShow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty MainImageUriProperty = DependencyProperty.Register(nameof(MainImageUri), typeof(Uri), typeof(ResultShow), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string MainImageUri
        {
            get => (string)GetValue(MainImageUriProperty);
            set => SetValue(MainImageUriProperty, value);
        }

    }
}
