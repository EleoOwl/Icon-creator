using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace CoolImage
{
    [Serializable]
    public class CoolImage
    {
        public enum SerializeFormat { Binary, Xml, Soap }
        public Color[,] pixelArr { get; internal set; }
        public Bitmap img { get; internal set; }

        public CoolImage()
        {
            this.pixelArr = new Color[0, 0];
            this.img = new Bitmap(1, 1);

        }
        public CoolImage(Color[,] pixelArr, Bitmap img)
        {
            this.pixelArr = pixelArr;
            this.img = img;

        }
        public CoolImage(Color[,] pixelArr)
        {
            this.pixelArr = pixelArr;

            int c = (int)Math.Sqrt(pixelArr.Length);
            img = new Bitmap(c, c);
            for (int i = 0; i < c; i++)
                for (int j = 0; j < c; j++)
                    if (pixelArr[i, j] != Color.Gray) (img as Bitmap).SetPixel(i, j, pixelArr[i, j]);

        }
        public CoolImage(Bitmap img)
        {
            this.img = img;

            Bitmap bm = img as Bitmap;
            int n = bm.Size.Height, m = bm.Size.Width;
            pixelArr = new Color[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; i < m; j++)
                    pixelArr[i, j] = bm.GetPixel(i, j);
        }
        public void Save(string path, SerializeFormat serializeFormat)
        {
            Stream s = File.Open(path, FileMode.Create);
            switch (serializeFormat)
            {
                case SerializeFormat.Binary:
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(s, this);
                    break;
                case SerializeFormat.Soap:
                    SoapFormatter binFormat = new SoapFormatter();
                    binFormat.Serialize(s, this);
                    break;
                case SerializeFormat.Xml:
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(CoolImage));
                    xmlFormat.Serialize(s, this);
                    break;
            }
            s.Close();
        }
        public void Read(string path, SerializeFormat serializeFormat)
        {
            Stream s = File.Open(path, FileMode.Open);
            CoolImage cl = this;
            switch (serializeFormat)
            {
                case SerializeFormat.Binary:

                    BinaryFormatter bf = new BinaryFormatter();
                    cl = bf.Deserialize(s) as CoolImage;
                    break;

                case SerializeFormat.Soap:
                    SoapFormatter binFormat = new SoapFormatter();
                    cl = binFormat.Deserialize(s) as CoolImage;
                    break;
                case SerializeFormat.Xml:
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(CoolImage));
                    cl = xmlFormat.Deserialize(s) as CoolImage;
                    break;
            }
            this.img = cl.img;
            this.pixelArr = cl.pixelArr;
            s.Close();
        }
    }

}
