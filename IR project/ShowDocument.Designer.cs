namespace IR_project
{
    partial class ShowDocument
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowDocument));
            this.docContent_rtb = new System.Windows.Forms.RichTextBox();
            this.print_img = new System.Windows.Forms.PictureBox();
            this.prontDoc_pd = new System.Windows.Forms.PrintDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.print_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // docContent_rtb
            // 
            this.docContent_rtb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.docContent_rtb.Location = new System.Drawing.Point(50, 205);
            this.docContent_rtb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.docContent_rtb.Name = "docContent_rtb";
            this.docContent_rtb.ReadOnly = true;
            this.docContent_rtb.Size = new System.Drawing.Size(952, 851);
            this.docContent_rtb.TabIndex = 0;
            this.docContent_rtb.Text = "";
            // 
            // print_img
            // 
            this.print_img.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.print_img.Cursor = System.Windows.Forms.Cursors.Hand;
            this.print_img.ImageLocation = "C:\\Users\\ligal\\Desktop\\IR project\\IR project\\images\\print_image.png";
            this.print_img.InitialImage = ((System.Drawing.Image)(resources.GetObject("print_img.InitialImage")));
            this.print_img.Location = new System.Drawing.Point(400, 118);
            this.print_img.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.print_img.Name = "print_img";
            this.print_img.Size = new System.Drawing.Size(75, 77);
            this.print_img.TabIndex = 8;
            this.print_img.TabStop = false;
            this.print_img.Click += new System.EventHandler(this.print_img_Click);
            // 
            // prontDoc_pd
            // 
            this.prontDoc_pd.UseEXDialog = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.ImageLocation = "C:\\Users\\ligal\\Desktop\\IR project\\IR project\\images\\download_inage.png";
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(592, 118);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 77);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ShowDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 1094);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.print_img);
            this.Controls.Add(this.docContent_rtb);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ShowDocument";
            this.Text = "ShowDocument";
            ((System.ComponentModel.ISupportInitialize)(this.print_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox docContent_rtb;
        private System.Windows.Forms.PictureBox print_img;
        private System.Windows.Forms.PrintDialog prontDoc_pd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}