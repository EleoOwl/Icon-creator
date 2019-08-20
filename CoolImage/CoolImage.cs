using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace CoolImage
{
    [Serializable]
    public class CoolImage
    {
        public Color[,] pixelArr { get; internal set; }
        public Image img { get; internal set; }

        public CoolImage(Color[,] pixelArr, Image img)
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
                    if (pixelArr[i, j]!= Color.Gray) (img as Bitmap).SetPixel(i, j, pixelArr[i, j]);

        }
        public CoolImage( Image img)
        {
            this.img = img;

            Bitmap bm = img as Bitmap;
            int n = bm.Size.Height, m = bm.Size.Width;
            pixelArr = new Color[n,m];
            for (int i = 0; i < n; i++)
                for (int j = 0; i < m; j++)
                    pixelArr[i, j] = bm.GetPixel(i, j);
        }
    }
}
