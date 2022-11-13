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
    public partial class ThemeChanger : UserControl
    {
        public ThemeChanger()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SelectedThemeProperty = DependencyProperty.Register(nameof(SelectedTheme), typeof(int), typeof(ThemeChanger),
                                                                                                      new FrameworkPropertyMetadata(
                                                                                                          defaultValue: 0,
                                                                                                          flags: FrameworkPropertyMetadataOptions.AffectsMeasure,
                                                                                                          propertyChangedCallback: new PropertyChangedCallback(OnSelectedThemeChanged)));

        public int SelectedTheme
        {
            get => (int)GetValue(SelectedThemeProperty);
            set => SetValue(SelectedThemeProperty, value);
        }

        private static void OnSelectedThemeChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            ThemeChanger themeChanger = (ThemeChanger)dependencyObject;

            if(e.NewValue.ToString() == "0")
            {
                themeChanger.RadioButtonBlack.IsChecked = true;
            }
            else
            {
                themeChanger.RadioButtonLigth.IsChecked = true;
            }

            MainWindow.ThemeChage(Convert.ToInt32(e.NewValue.ToString()));
        }

        private void Click_SetThemeBlack(object sender, RoutedEventArgs e)
        {
            SelectedTheme = 0;
        }

        private void Click_SetThemeLigth(object sender, RoutedEventArgs e)
        {
            SelectedTheme = 1;
        }
    }
}
