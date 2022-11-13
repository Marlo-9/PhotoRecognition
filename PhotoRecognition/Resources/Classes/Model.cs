using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PhotoRecognition.Resources.Classes
{
    internal class Model
    {
        public Whale TestData { get; set; }

        public Model(string path)
        {
            TestData = new Whale(path);
        }

        public Model() : this("PhotoRecognition/Resources/Result") { }

    }
}
