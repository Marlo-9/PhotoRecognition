using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PhotoRecognition.Resources.Classes
{
    internal class ViewModel : INotifyPropertyChanged
    {
        public Model PhotoModel { get; set; }

        public ViewModel()
        {
            PhotoModel = new Model("Resources\\Result");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
