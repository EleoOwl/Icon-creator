using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawPixel
{
    public partial class Form1 : Form
    {

        Panel[,] board;
        Color mouseColour;
        public Form1()
        {
            
            InitializeComponent();
            Create_board(20);
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
            int l = 20, r = this.Width - panel1.Width - l;
            int u = 20, d = this.Height - 2*u;

            int size = ((r - l) < (d - u) ? (r - l) : (d - u)) / n;
            Remove_board();
            board = new Panel[n, n];
            for (int i = 0; i < n; i++)
            {
                l = 20;
                for (int j = 0; j < n; j++)
                {
                    board[i, j] = new Panel();
                    board[i, j].Size = new Size((int)(0.9 * size), (int)(0.9 * size));
                    board[i, j].Location = new Point(l, u); l += size;
                    if (arr == null) board[i, j].BackColor = Color.Gray;
                       else board[i, j].BackColor = arr[i, j];
                    //  board[i, j].Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left)));
                    board[i, j].Click += new EventHandler(panel_Click);
                    board[i, j].MouseEnter += new EventHandler(Paint);
                    board[i, j].DoubleClick += new EventHandler(Form1_MouseDoubleClick);
                    Controls.Add(board[i, j]);
                }
                u += size;
            }
            
        }
        private void Remove_board()
        {
           if (board!= null) foreach (Panel b in board)  Controls.Remove(b); 
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
            if (MessageBox.Show("Do you  want to save your picture as .jpg?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int c =(int) Math.Sqrt(board.Length);
                Bitmap bmp = new Bitmap(c, c);
                for (int i = 0; i < c; i++)
                    for (int j = 0; j < c; j++)
                      if (board[i, j].BackColor!=Color.Gray)  bmp.SetPixel(i, j, board[i, j].BackColor);

                FileDialog a = new SaveFileDialog();
                a.Filter = "Изображение (.png)|*.png";
                a.ShowDialog();
                if (a.FileName!=null)
                     bmp.Save(a.FileName);
            }
        }


        bool mousePAINT;
       

        private void Paint(object sender, EventArgs e)
        {
          if (mousePAINT)
                (sender as Panel).BackColor = mouseColour;
        }

        private void Form1_MouseDoubleClick(object sender,EventArgs e)
        {
            mousePAINT = !mousePAINT;
        }
        
        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            if (trackBar1.Value != (int)Math.Sqrt(board.Length)) Do_Resize(trackBar1.Value);
        }

        private void Do_Resize(int value)
        {
            int len =(int) Math.Sqrt(board.Length);
            Color[,] newe = new Color[value, value];
            if (value < len)
            {
                int diff = (len - value) / 2 ;
                for (int i = diff; i < len - diff-1; i++)
                    for(int j = diff; j<len-diff-1; j++)
                    {
                        newe[i - diff, j - diff] = board[i, j].BackColor; 
                    }
            }
            else
            {
                int diff = (value-len) / 2;
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
