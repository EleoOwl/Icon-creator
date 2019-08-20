namespace DrawPixel
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.save = new System.Windows.Forms.Button();
            this.erase = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.but_colour = new System.Windows.Forms.Button();
            this.but_less = new System.Windows.Forms.Button();
            this.but_more = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.save);
            this.panel1.Controls.Add(this.erase);
            this.panel1.Controls.Add(this.clear);
            this.panel1.Controls.Add(this.but_colour);
            this.panel1.Controls.Add(this.but_less);
            this.panel1.Controls.Add(this.but_more);
            this.panel1.Location = new System.Drawing.Point(499, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(49, 426);
            this.panel1.TabIndex = 0;
            // 
            // save
            // 
            this.save.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.save.BackgroundImage = global::DrawPixel.Properties.Resources.save_icon;
            this.save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.save.Location = new System.Drawing.Point(3, 232);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(43, 39);
            this.save.TabIndex = 5;
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // erase
            // 
            this.erase.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.erase.BackgroundImage = global::DrawPixel.Properties.Resources.erase_text;
            this.erase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.erase.Location = new System.Drawing.Point(3, 142);
            this.erase.Name = "erase";
            this.erase.Size = new System.Drawing.Size(43, 39);
            this.erase.TabIndex = 4;
            this.erase.UseVisualStyleBackColor = true;
            this.erase.Click += new System.EventHandler(this.erase_Click);
            // 
            // clear
            // 
            this.clear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.clear.BackgroundImage = global::DrawPixel.Properties.Resources.clear;
            this.clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.clear.Location = new System.Drawing.Point(3, 187);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(43, 39);
            this.clear.TabIndex = 3;
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // but_colour
            // 
            this.but_colour.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.but_colour.BackgroundImage = global::DrawPixel.Properties.Resources.pipette;
            this.but_colour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.but_colour.Location = new System.Drawing.Point(3, 93);
            this.but_colour.Name = "but_colour";
            this.but_colour.Size = new System.Drawing.Size(43, 39);
            this.but_colour.TabIndex = 2;
            this.but_colour.UseVisualStyleBackColor = true;
            this.but_colour.Click += new System.EventHandler(this.but_colour_Click);
            // 
            // but_less
            // 
            this.but_less.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.but_less.Location = new System.Drawing.Point(3, 48);
            this.but_less.Name = "but_less";
            this.but_less.Size = new System.Drawing.Size(43, 39);
            this.but_less.TabIndex = 1;
            this.but_less.UseVisualStyleBackColor = true;
            this.but_less.Visible = false;
            this.but_less.Click += new System.EventHandler(this.but_less_Click);
            // 
            // but_more
            // 
            this.but_more.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.but_more.Location = new System.Drawing.Point(3, 3);
            this.but_more.Name = "but_more";
            this.but_more.Size = new System.Drawing.Size(43, 39);
            this.but_more.TabIndex = 0;
            this.but_more.UseVisualStyleBackColor = true;
            this.but_more.Visible = false;
            this.but_more.Click += new System.EventHandler(this.but_more_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(448, 105);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 178);
            this.trackBar1.SmallChange = 2;
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickFrequency = 2;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 450);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Draw Pixel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DoubleClick += new System.EventHandler(this.Form1_MouseDoubleClick);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button but_colour;
        private System.Windows.Forms.Button but_less;
        private System.Windows.Forms.Button but_more;
        private System.Windows.Forms.Button erase;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

