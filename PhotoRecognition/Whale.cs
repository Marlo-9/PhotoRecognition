using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PhotoRecognition
{
    internal class Whale
    {
        private Whale(int iD, string pathImg)
        {
            ID = iD;
            PathsImg.Add(pathImg);
        }

        public Whale()
        {

        }

        public int ID { get; set; }
        public List<string> PathsImg { get; set; } = new List<string>();

        public List<Whale> Whales { get; set; } = new List<Whale>();
        public void outKit(Whale whale)
        {
            Console.WriteLine("ID: " + whale.ID + " IMGPATH: ");
            for (int i = 0; i < whale.PathsImg.Count; i++)
            {
                Console.WriteLine(whale.PathsImg[i]);
            }
        }

        public void OutKits()
        {
            foreach (Whale whale in Whales)
            {
                Console.WriteLine(whale.ID);
            }
        }

        public void fillId(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo[] dirs = new DirectoryInfo(path).GetDirectories(); // директории
                foreach (DirectoryInfo dir in dirs)
                {
                    string[] files = Directory.GetFiles(dir.FullName);
                    Whale whale = new Whale(Convert.ToInt32(dir.Name), files[0]);
                    foreach (string file in files)
                    {
                        whale.PathsImg.Add(file);
                    }
                    Whales.Add(whale);
                }
            }
            Console.ReadLine();
        }
    }
}
