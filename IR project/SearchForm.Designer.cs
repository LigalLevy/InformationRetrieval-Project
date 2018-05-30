namespace IR_project
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.Search_btn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loginIcon_img = new System.Windows.Forms.PictureBox();
            this.Greating_lbl = new System.Windows.Forms.Label();
            this.SearchBox_txt = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SearchRes_Table = new System.Windows.Forms.TableLayoutPanel();
            this.noresult_pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginIcon_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noresult_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // Search_btn
            // 
            this.Search_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Search_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Search_btn.Depth = 0;
            this.Search_btn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Search_btn.Location = new System.Drawing.Point(814, 380);
            this.Search_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Search_btn.MouseState = MaterialSkin.MouseState.HOVER;
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Primary = true;
            this.Search_btn.Size = new System.Drawing.Size(123, 40);
            this.Search_btn.TabIndex = 4;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = false;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.ImageLocation = "C:\\Users\\ligal\\Desktop\\IR project\\IR project\\images\\Logo.gif";
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(135, 182);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(802, 192);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // loginIcon_img
            // 
            this.loginIcon_img.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginIcon_img.ImageLocation = "C:\\Users\\ligal\\Desktop\\IR project\\IR project\\images\\login_image.png";
            this.loginIcon_img.Location = new System.Drawing.Point(34, 122);
            this.loginIcon_img.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loginIcon_img.Name = "loginIcon_img";
            this.loginIcon_img.Size = new System.Drawing.Size(75, 77);
            this.loginIcon_img.TabIndex = 7;
            this.loginIcon_img.TabStop = false;
            this.loginIcon_img.Click += new System.EventHandler(this.loginIcon_img_Click);
            // 
            // Greating_lbl
            // 
            this.Greating_lbl.AutoSize = true;
            this.Greating_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Greating_lbl.Location = new System.Drawing.Point(28, 122);
            this.Greating_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Greating_lbl.Name = "Greating_lbl";
            this.Greating_lbl.Size = new System.Drawing.Size(81, 30);
            this.Greating_lbl.TabIndex = 9;
            this.Greating_lbl.Text = "label1";
            this.Greating_lbl.Visible = false;
            // 
            // SearchBox_txt
            // 
            this.SearchBox_txt.Depth = 0;
            this.SearchBox_txt.Hint = "";
            this.SearchBox_txt.Location = new System.Drawing.Point(135, 382);
            this.SearchBox_txt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SearchBox_txt.MouseState = MaterialSkin.MouseState.HOVER;
            this.SearchBox_txt.Name = "SearchBox_txt";
            this.SearchBox_txt.PasswordChar = '\0';
            this.SearchBox_txt.SelectedText = "";
            this.SearchBox_txt.SelectionLength = 0;
            this.SearchBox_txt.SelectionStart = 0;
            this.SearchBox_txt.Size = new System.Drawing.Size(670, 32);
            this.SearchBox_txt.TabIndex = 12;
            this.SearchBox_txt.UseSystemPasswordChar = false;
            this.SearchBox_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchBox_txt_KeyPress);
            // 
            // SearchRes_Table
            // 
            this.SearchRes_Table.AutoScroll = true;
            this.SearchRes_Table.AutoSize = true;
            this.SearchRes_Table.ColumnCount = 1;
            this.SearchRes_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SearchRes_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 638F));
            this.SearchRes_Table.Location = new System.Drawing.Point(136, 429);
            this.SearchRes_Table.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SearchRes_Table.MaximumSize = new System.Drawing.Size(801, 746);
            this.SearchRes_Table.MinimumSize = new System.Drawing.Size(801, 15);
            this.SearchRes_Table.Name = "SearchRes_Table";
            this.SearchRes_Table.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SearchRes_Table.RowCount = 1;
            this.SearchRes_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SearchRes_Table.Size = new System.Drawing.Size(801, 746);
            this.SearchRes_Table.TabIndex = 15;
            // 
            // noresult_pb
            // 
            this.noresult_pb.ImageLocation = "C:\\Users\\ligal\\Desktop\\IR project\\IR project\\images\\noResults.png";
            this.noresult_pb.InitialImage = ((System.Drawing.Image)(resources.GetObject("noresult_pb.InitialImage")));
            this.noresult_pb.Location = new System.Drawing.Point(140, 429);
            this.noresult_pb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.noresult_pb.Name = "noresult_pb";
            this.noresult_pb.Size = new System.Drawing.Size(792, 615);
            this.noresult_pb.TabIndex = 16;
            this.noresult_pb.TabStop = false;
            this.noresult_pb.Visible = false;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1070, 1272);
            this.Controls.Add(this.noresult_pb);
            this.Controls.Add(this.SearchRes_Table);
            this.Controls.Add(this.SearchBox_txt);
            this.Controls.Add(this.Greating_lbl);
            this.Controls.Add(this.loginIcon_img);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Search_btn);
            this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.Name = "SearchForm";
            this.Text = "Sherlock IR";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Load += new System.EventHandler(this.SearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginIcon_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noresult_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialRaisedButton Search_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox loginIcon_img;
        private System.Windows.Forms.Label Greating_lbl;
        private MaterialSkin.Controls.MaterialSingleLineTextField SearchBox_txt;
        private System.Windows.Forms.TableLayoutPanel SearchRes_Table;
        private System.Windows.Forms.PictureBox noresult_pb;
    }
}

