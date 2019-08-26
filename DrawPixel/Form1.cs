using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DrawPixel
{
    public partial class Form1 : Form
    {

        Panel[,] board;
        Color mouseColour;
        Color defaultPixelColor = Color.Gray;
        public Form1()
        {

            InitializeComponent();
            Create_board(20);
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new MenuStripColorTable());
            pcb_CloseForm.MouseEnter += (s, e) => { pcb_CloseForm.Image = Properties.Resources.checkedClose20px; };
            pcb_CloseForm.MouseLeave += (s, e) => { pcb_CloseForm.Image = Properties.Resources.uncheckedClose20px; };
            pcb_CloseForm.Click += (s, e) => { Application.Exit(); };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mouseColour = Color.Black;
            mousePAINT = false;
            trackBar1.Minimum = 6;
            trackBar1.Maximum = 50;
            trackBar1.Value = 20;
            trackBar1.SmallChange = 2;
        }

        private void DrawArr(Color[,] arr)
        {
            int len = (int)Math.Sqrt(arr.Length);
            if (arr.Length != board.Length)
            {
                Remove_board();
                Create_board(len);
            }
            for (int i = 0; i < len; i++)
                for (int j = 0; j < len; j++)
                    board[i, j].BackColor = arr[i, j];
        }
        private void Create_board(int n, Color[,] arr = null)
        {
            //int l = 20, r = this.Width - panel1.Width - l;
            //int u = 20, d = this.Height - 2*u;

            //int size = ((r - l) < (d - u) ? (r - l) : (d - u)) / n;
            //Remove_board();
            //board = new Panel[n, n];
            //for (int i = 0; i < n; i++)
            //{
            //    l = 20;
            //    for (int j = 0; j < n; j++)
            //    {
            //        board[i, j] = new Panel();
            //        board[i, j].Size = new Size((int)(0.9 * size), (int)(0.9 * size));
            //        board[i, j].Location = new Point(l, u); l += size;
            //        if (arr == null) board[i, j].BackColor = Color.Gray;
            //           else board[i, j].BackColor = arr[i, j];
            //        //  board[i, j].Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left)));
            //        board[i, j].Click += new EventHandler(panel_Click);
            //        board[i, j].MouseEnter += new EventHandler(Paint);
            //        board[i, j].DoubleClick += new EventHandler(Form1_MouseDoubleClick);
            //        pnl_Pixels.Controls.Add(board[i, j]);
            //    }
            //    u += size;
            

            int x = 5, y = 5, d = 2; // Начальные координаты.
            int size = pnl_Pixels.Width > pnl_Pixels.Height ? (pnl_Pixels.Height - 2 * x - (n - 1) * d) / n :
                (pnl_Pixels.Width - 2 * x - (n - 1) * d) / n;
            //while (n * (size + d) < pnl_Pixels.Height) size++;
            Remove_board();
            board = new Panel[n, n];
            for (int i = 0; i < n; i++)
            {
                x = 5;
                for(int j = 0; j < n; j++)
                {
                    board[i, j] = new Panel
                    {
                        Size = new Size(size, size),
                        Location = new Point(x, y),
                    };
                    if (arr == null) board[i, j].BackColor = defaultPixelColor;
                    else board[i, j].BackColor = arr[i, j];
                    board[i, j].Click += new EventHandler(panel_Click);
                    board[i, j].MouseEnter += new EventHandler(Paint);
                    board[i, j].DoubleClick += new EventHandler(Form1_MouseDoubleClick);
                    pnl_Pixels.Controls.Add(board[i, j]);
                    x += size + d;
                }
                y += size + d;
            }

           
            
        }
        private void Remove_board()
        {
           if (board!= null) foreach (Panel b in board) pnl_Pixels.Controls.Remove(b); 
            board = new Panel[0,0];
        }

        private void but_more_Click(object sender, EventArgs e)
        {

        }

        private void but_less_Click(object sender, EventArgs e)
        {

        }

        private void but_colour_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            mouseColour = colorDialog1.Color;
        }
        private void panel_Click(object sender, EventArgs e)
        {
            if (!mousePAINT) (sender as Panel).BackColor = mouseColour;
        }

        private void erase_Click(object sender, EventArgs e)
        {
            mouseColour = Color.Gray;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to clear picture?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int l = (int)Math.Sqrt(board.Length);
                for (int i = 0; i < l; i++)
                    for (int j = 0; j < l; j++) board[i, j].BackColor = Color.Gray;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            //DialogResult f = MessageBox.Show("Do you  want to save your picture as .jpg?", "", MessageBoxButtons.YesNoCancel);
            //if (f == DialogResult.Yes)
            //{
            //    int c = (int)Math.Sqrt(board.Length);
            //    Bitmap bmp = new Bitmap(c, c);
            //    for (int i = 0; i < c; i++)
            //        for (int j = 0; j < c; j++)
            //            if (board[i, j].BackColor != Color.Gray) bmp.SetPixel(i, j, board[i, j].BackColor);

            //    FileDialog a = new SaveFileDialog();
            //    a.Filter = "Изображение (.png)|*.png";
            //    a.ShowDialog();
            //    if (a.FileName != null)
            //        bmp.Save(a.FileName);
            //}
            //else if (f == DialogResult.No)
            //{
            //    int c = (int)Math.Sqrt(board.Length);
            //    Bitmap bmp = new Bitmap(c, c);
            //    Color[,] clr = new Color[c, c];
            //    for (int i = 0; i < c; i++)
            //        for (int j = 0; j < c; j++)
            //        {
            //            if (board[i, j].BackColor != Color.Gray) bmp.SetPixel(i, j, board[i, j].BackColor);
            //            clr[i, j] = board[i, j].BackColor;
            //        }
            //    CoolImage.CoolImage saved = new CoolImage.CoolImage(clr, bmp);
            //    FileDialog a = new SaveFileDialog();
            //    a.Filter = "Сериализированный объект bin (*.bin)|*.bin|Сериализованный объект .soap |*.soap| Сериализованный объект .xml |*.xml";
            //    a.ShowDialog();
            //    if (a.FileName != null)
            //        saved.Save(a.FileName, Ext(a.FileName));
            //}
            try
            {
                FileDialog a = new SaveFileDialog();
                a.ShowDialog();
                //изображение
                int c = (int)Math.Sqrt(board.Length);

                Bitmap bmp = new Bitmap(c, c);
                Color[,] clr = new Color[c, c];

                for (int i = 0; i < c; i++)
                    for (int j = 0; j < c; j++)
                    {
                        if (board[i, j].BackColor != Color.Gray) bmp.SetPixel(i, j, board[i, j].BackColor);
                        clr[i, j] = board[i, j].BackColor;
                    }
                string name = getName(a.FileName);
                DirectoryInfo dirInfo = new DirectoryInfo(a.FileName);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                if (a.FileName != null)
                    bmp.Save(a.FileName + "\\" + name + ".png");

                //сериализации

                CoolImage.CoolImage saved = new CoolImage.CoolImage(clr, bmp);

                saved.Save(a.FileName + "\\" + name + ".bin", CoolImage.CoolImage.SerializeFormat.Binary);
                // saved.Save(a.FileName + "\\" + name + ".xml", CoolImage.CoolImage.SerializeFormat.Xml);
                saved.Save(a.FileName + "\\" + name + ".soap", CoolImage.CoolImage.SerializeFormat.Soap);
            }
            catch { MessageBox.Show("You've done something wrong, sorry. You could try again"); }
        }

        private string getName(string s)
        {
            string ss = ""; bool coma = !s.Contains('.');
            for (int i = s.Length - 1; i >= 0 && s[i] != '\\'; i--)
            {
                if (s[i] == '.') coma = true;
                if (coma) ss += s[i];
            }
            ss.Reverse();
            return ss;
        }

        private CoolImage.CoolImage.SerializeFormat Ext(string a)
        {
            for (int i = 0; i < a.Length && a[i] != '.'; i++)
            {
                if (a[i + 1] == '.') switch (a[i + 2])
                    {
                        case 's': return CoolImage.CoolImage.SerializeFormat.Soap; break;
                        case 'x': return CoolImage.CoolImage.SerializeFormat.Xml; break;
                        case 'b': return CoolImage.CoolImage.SerializeFormat.Binary; break;
                    }
            }
            return CoolImage.CoolImage.SerializeFormat.Binary;
        }


        bool mousePAINT;
       

        private void Paint(object sender, EventArgs e)
        {
            if (mousePAINT)
                (sender as Panel).BackColor = mouseColour;
        }

        private void Form1_MouseDoubleClick(object sender, EventArgs e)
        {
            mousePAINT = !mousePAINT;
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            if (trackBar1.Value != (int)Math.Sqrt(board.Length)) Do_Resize(trackBar1.Value);
        }

        private void Do_Resize(int value)
        {
            int len = (int)Math.Sqrt(board.Length);
            Color[,] newe = new Color[value, value];
            if (value < len)
            {
                int diff = (len - value) / 2;
                for (int i = diff; i < len - diff - 1; i++)
                    for (int j = diff; j < len - diff - 1; j++)
                    {
                        newe[i - diff, j - diff] = board[i, j].BackColor;
                    }
            }
            else
            {
                int diff = (value - len) / 2;
                for (int i = 0; i < value; i++)
                    for (int j = 0; j < value; j++)
                    {
                        if (i > diff && j > diff && i < (len - diff) && j < (len - diff)) newe[i, j] = board[i - diff, j - diff].BackColor;
                        else newe[i, j] = Color.Gray;
                    }
            }

            Remove_board();
            Create_board(value, newe);
        }
        
    }
}
