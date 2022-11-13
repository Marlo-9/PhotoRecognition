using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoRecognition.Resources.Classes
{
    public class Whale
    {
        private Whale(int iD, string pathImg)
        {
            ID = iD;
            PathsImg.Add(new Uri(pathImg, UriKind.RelativeOrAbsolute));
        }

        private Whale(int iD, Uri pathImg)
        {
            ID = iD;
            PathsImg.Add(pathImg);
        }

        public Whale(string path)
        {
            fillId(path);
        }

        public Whale() { }

        public int ID { get; set; }

        public List<Uri> PathsImg { get; set; } = new List<Uri>();

        public List<Whale> Whales { get; set; } = new List<Whale>();

        public void fillId(string path)
        {
            if (Directory.Exists(Directory.GetCurrentDirectory() + "\\" + path))
            {
                DirectoryInfo[] dirs = new DirectoryInfo(path).GetDirectories();

                foreach (DirectoryInfo dir in dirs)
                {
                    string[] files = Directory.GetFiles(dir.FullName);
                    Whale whale = new Whale(Convert.ToInt32(dir.Name), files[0]);

                    foreach (string file in files)
                        whale.PathsImg.Add(new Uri(file, UriKind.RelativeOrAbsolute));

                    Whales.Add(whale);
                }
            }
            else
            {
            }
        }
    }
}