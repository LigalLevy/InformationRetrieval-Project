namespace IR_project
{
    partial class AdminPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Greating_lbl = new System.Windows.Forms.Label();
            this.delDoc_tab = new System.Windows.Forms.TabPage();
            this.SearchRes_Table = new System.Windows.Forms.TableLayoutPanel();
            this.SearchBox_txt = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Search_btn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.addDoc_tab = new System.Windows.Forms.TabPage();
            this.ConfirmTxt_lbl = new System.Windows.Forms.Label();
            this.AlertMsg_lbl = new System.Windows.Forms.Label();
            this.insertDoc_form__btn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.DocCreationDate_np = new System.Windows.Forms.NumericUpDown();
            this.DocAuthor_txt = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.DocName_txt = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.PathBox_txt = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Browse_btn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.admPanel_pnl = new MaterialSkin.Controls.MaterialTabControl();
            this.AddDoc_btn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.removeDoc_btn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.docFile_ofg = new System.Windows.Forms.OpenFileDialog();
            this.noresult_pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.delDoc_tab.SuspendLayout();
            this.addDoc_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DocCreationDate_np)).BeginInit();
            this.admPanel_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noresult_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.ImageLocation = "C:\\Users\\ligal\\Desktop\\IR project\\IR project\\images\\Logo.gif";
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(232, 148);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(802, 192);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // Greating_lbl
            // 
            this.Greating_lbl.AutoSize = true;
            this.Greating_lbl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Greating_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Greating_lbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Greating_lbl.Location = new System.Drawing.Point(44, 115);
            this.Greating_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Greating_lbl.Name = "Greating_lbl";
            this.Greating_lbl.Size = new System.Drawing.Size(81, 30);
            this.Greating_lbl.TabIndex = 10;
            this.Greating_lbl.Text = "label1";
            // 
            // delDoc_tab
            // 
            this.delDoc_tab.BackColor = System.Drawing.Color.White;
            this.delDoc_tab.Controls.Add(this.SearchRes_Table);
            this.delDoc_tab.Controls.Add(this.SearchBox_txt);
            this.delDoc_tab.Controls.Add(this.Search_btn);
            this.delDoc_tab.Location = new System.Drawing.Point(4, 29);
            this.delDoc_tab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.delDoc_tab.Name = "delDoc_tab";
            this.delDoc_tab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.delDoc_tab.Size = new System.Drawing.Size(950, 765);
            this.delDoc_tab.TabIndex = 2;
            this.delDoc_tab.Text = "Delete";
            // 
            // SearchRes_Table
            // 
            this.SearchRes_Table.AutoScroll = true;
            this.SearchRes_Table.AutoSize = true;
            this.SearchRes_Table.ColumnCount = 2;
            this.SearchRes_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SearchRes_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 730F));
            this.SearchRes_Table.Location = new System.Drawing.Point(32, 75);
            this.SearchRes_Table.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SearchRes_Table.MaximumSize = new System.Drawing.Size(885, 697);
            this.SearchRes_Table.MinimumSize = new System.Drawing.Size(885, 15);
            this.SearchRes_Table.Name = "SearchRes_Table";
            this.SearchRes_Table.RowCount = 1;
            this.SearchRes_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SearchRes_Table.Size = new System.Drawing.Size(885, 645);
            this.SearchRes_Table.TabIndex = 14;
            this.SearchRes_Table.Paint += new System.Windows.Forms.PaintEventHandler(this.SearchRes_Table_Paint);
            // 
            // SearchBox_txt
            // 
            this.SearchBox_txt.Depth = 0;
            this.SearchBox_txt.Hint = "File Name or Author";
            this.SearchBox_txt.Location = new System.Drawing.Point(32, 31);
            this.SearchBox_txt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SearchBox_txt.MouseState = MaterialSkin.MouseState.HOVER;
            this.SearchBox_txt.Name = "SearchBox_txt";
            this.SearchBox_txt.PasswordChar = '\0';
            this.SearchBox_txt.SelectedText = "";
            this.SearchBox_txt.SelectionLength = 0;
            this.SearchBox_txt.SelectionStart = 0;
            this.SearchBox_txt.Size = new System.Drawing.Size(786, 32);
            this.SearchBox_txt.TabIndex = 7;
            this.SearchBox_txt.UseSystemPasswordChar = false;
            this.SearchBox_txt.Click += new System.EventHandler(this.SearchBox_txt_Click);
            this.SearchBox_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchBox_txt_KeyPress);
            // 
            // Search_btn
            // 
            this.Search_btn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Search_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Search_btn.BackgroundImage")));
            this.Search_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Search_btn.Depth = 0;
            this.Search_btn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Search_btn.Location = new System.Drawing.Point(826, 26);
            this.Search_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Search_btn.MouseState = MaterialSkin.MouseState.HOVER;
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Primary = true;
            this.Search_btn.Size = new System.Drawing.Size(90, 40);
            this.Search_btn.TabIndex = 6;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = false;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // addDoc_tab
            // 
            this.addDoc_tab.BackColor = System.Drawing.Color.White;
            this.addDoc_tab.Controls.Add(this.ConfirmTxt_lbl);
            this.addDoc_tab.Controls.Add(this.AlertMsg_lbl);
            this.addDoc_tab.Controls.Add(this.insertDoc_form__btn);
            this.addDoc_tab.Controls.Add(this.label1);
            this.addDoc_tab.Controls.Add(this.DocCreationDate_np);
            this.addDoc_tab.Controls.Add(this.DocAuthor_txt);
            this.addDoc_tab.Controls.Add(this.DocName_txt);
            this.addDoc_tab.Controls.Add(this.PathBox_txt);
            this.addDoc_tab.Controls.Add(this.Browse_btn);
            this.addDoc_tab.Location = new System.Drawing.Point(4, 29);
            this.addDoc_tab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addDoc_tab.Name = "addDoc_tab";
            this.addDoc_tab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addDoc_tab.Size = new System.Drawing.Size(950, 765);
            this.addDoc_tab.TabIndex = 1;
            this.addDoc_tab.Text = "Add";
            // 
            // ConfirmTxt_lbl
            // 
            this.ConfirmTxt_lbl.AutoSize = true;
            this.ConfirmTxt_lbl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ConfirmTxt_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmTxt_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ConfirmTxt_lbl.Location = new System.Drawing.Point(194, 685);
            this.ConfirmTxt_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ConfirmTxt_lbl.Name = "ConfirmTxt_lbl";
            this.ConfirmTxt_lbl.Size = new System.Drawing.Size(487, 26);
            this.ConfirmTxt_lbl.TabIndex = 15;
            this.ConfirmTxt_lbl.Text = "Your Document Has been successfully Uploaded";
            this.ConfirmTxt_lbl.Visible = false;
            // 
            // AlertMsg_lbl
            // 
            this.AlertMsg_lbl.AutoSize = true;
            this.AlertMsg_lbl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.AlertMsg_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlertMsg_lbl.ForeColor = System.Drawing.Color.DarkRed;
            this.AlertMsg_lbl.Location = new System.Drawing.Point(51, 685);
            this.AlertMsg_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AlertMsg_lbl.Name = "AlertMsg_lbl";
            this.AlertMsg_lbl.Size = new System.Drawing.Size(70, 26);
            this.AlertMsg_lbl.TabIndex = 14;
            this.AlertMsg_lbl.Text = "label1";
            this.AlertMsg_lbl.Visible = false;
            // 
            // insertDoc_form__btn
            // 
            this.insertDoc_form__btn.Depth = 0;
            this.insertDoc_form__btn.Location = new System.Drawing.Point(324, 548);
            this.insertDoc_form__btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.insertDoc_form__btn.MouseState = MaterialSkin.MouseState.HOVER;
            this.insertDoc_form__btn.Name = "insertDoc_form__btn";
            this.insertDoc_form__btn.Primary = true;
            this.insertDoc_form__btn.Size = new System.Drawing.Size(255, 54);
            this.insertDoc_form__btn.TabIndex = 14;
            this.insertDoc_form__btn.Text = "Insert Document";
            this.insertDoc_form__btn.UseVisualStyleBackColor = true;
            this.insertDoc_form__btn.Click += new System.EventHandler(this.insertDoc_form__btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(270, 395);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 26);
            this.label1.TabIndex = 14;
            this.label1.Text = "Creation year";
            // 
            // DocCreationDate_np
            // 
            this.DocCreationDate_np.Location = new System.Drawing.Point(274, 428);
            this.DocCreationDate_np.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DocCreationDate_np.Maximum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.DocCreationDate_np.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.DocCreationDate_np.Name = "DocCreationDate_np";
            this.DocCreationDate_np.Size = new System.Drawing.Size(390, 26);
            this.DocCreationDate_np.TabIndex = 13;
            this.DocCreationDate_np.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // DocAuthor_txt
            // 
            this.DocAuthor_txt.Depth = 0;
            this.DocAuthor_txt.Hint = "Document Author";
            this.DocAuthor_txt.Location = new System.Drawing.Point(274, 286);
            this.DocAuthor_txt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DocAuthor_txt.MouseState = MaterialSkin.MouseState.HOVER;
            this.DocAuthor_txt.Name = "DocAuthor_txt";
            this.DocAuthor_txt.PasswordChar = '\0';
            this.DocAuthor_txt.SelectedText = "";
            this.DocAuthor_txt.SelectionLength = 0;
            this.DocAuthor_txt.SelectionStart = 0;
            this.DocAuthor_txt.Size = new System.Drawing.Size(390, 32);
            this.DocAuthor_txt.TabIndex = 11;
            this.DocAuthor_txt.UseSystemPasswordChar = false;
            // 
            // DocName_txt
            // 
            this.DocName_txt.Depth = 0;
            this.DocName_txt.Hint = "Document Title";
            this.DocName_txt.Location = new System.Drawing.Point(274, 163);
            this.DocName_txt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DocName_txt.MouseState = MaterialSkin.MouseState.HOVER;
            this.DocName_txt.Name = "DocName_txt";
            this.DocName_txt.PasswordChar = '\0';
            this.DocName_txt.SelectedText = "";
            this.DocName_txt.SelectionLength = 0;
            this.DocName_txt.SelectionStart = 0;
            this.DocName_txt.Size = new System.Drawing.Size(390, 32);
            this.DocName_txt.TabIndex = 10;
            this.DocName_txt.UseSystemPasswordChar = false;
            // 
            // PathBox_txt
            // 
            this.PathBox_txt.Depth = 0;
            this.PathBox_txt.Hint = "Document Local Path";
            this.PathBox_txt.Location = new System.Drawing.Point(32, 32);
            this.PathBox_txt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PathBox_txt.MouseState = MaterialSkin.MouseState.HOVER;
            this.PathBox_txt.Name = "PathBox_txt";
            this.PathBox_txt.PasswordChar = '\0';
            this.PathBox_txt.SelectedText = "";
            this.PathBox_txt.SelectionLength = 0;
            this.PathBox_txt.SelectionStart = 0;
            this.PathBox_txt.Size = new System.Drawing.Size(786, 32);
            this.PathBox_txt.TabIndex = 9;
            this.PathBox_txt.UseSystemPasswordChar = false;
            // 
            // Browse_btn
            // 
            this.Browse_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Browse_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Browse_btn.Depth = 0;
            this.Browse_btn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Browse_btn.Location = new System.Drawing.Point(826, 28);
            this.Browse_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Browse_btn.MouseState = MaterialSkin.MouseState.HOVER;
            this.Browse_btn.Name = "Browse_btn";
            this.Browse_btn.Primary = true;
            this.Browse_btn.Size = new System.Drawing.Size(90, 40);
            this.Browse_btn.TabIndex = 8;
            this.Browse_btn.Text = "Browse";
            this.Browse_btn.UseVisualStyleBackColor = false;
            this.Browse_btn.Click += new System.EventHandler(this.Browse_btn_Click);
            // 
            // admPanel_pnl
            // 
            this.admPanel_pnl.Controls.Add(this.addDoc_tab);
            this.admPanel_pnl.Controls.Add(this.delDoc_tab);
            this.admPanel_pnl.Depth = 0;
            this.admPanel_pnl.Location = new System.Drawing.Point(158, 437);
            this.admPanel_pnl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.admPanel_pnl.MouseState = MaterialSkin.MouseState.HOVER;
            this.admPanel_pnl.Name = "admPanel_pnl";
            this.admPanel_pnl.SelectedIndex = 0;
            this.admPanel_pnl.Size = new System.Drawing.Size(958, 798);
            this.admPanel_pnl.TabIndex = 11;
            // 
            // AddDoc_btn
            // 
            this.AddDoc_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddDoc_btn.Depth = 0;
            this.AddDoc_btn.Location = new System.Drawing.Point(362, 348);
            this.AddDoc_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddDoc_btn.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddDoc_btn.Name = "AddDoc_btn";
            this.AddDoc_btn.Primary = true;
            this.AddDoc_btn.Size = new System.Drawing.Size(255, 54);
            this.AddDoc_btn.TabIndex = 12;
            this.AddDoc_btn.Text = "Add Document";
            this.AddDoc_btn.UseVisualStyleBackColor = true;
            this.AddDoc_btn.Click += new System.EventHandler(this.AddDoc_btn_Click);
            // 
            // removeDoc_btn
            // 
            this.removeDoc_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeDoc_btn.Depth = 0;
            this.removeDoc_btn.Location = new System.Drawing.Point(627, 349);
            this.removeDoc_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.removeDoc_btn.MouseState = MaterialSkin.MouseState.HOVER;
            this.removeDoc_btn.Name = "removeDoc_btn";
            this.removeDoc_btn.Primary = true;
            this.removeDoc_btn.Size = new System.Drawing.Size(255, 54);
            this.removeDoc_btn.TabIndex = 13;
            this.removeDoc_btn.Text = "Modify Documents";
            this.removeDoc_btn.UseVisualStyleBackColor = true;
            this.removeDoc_btn.Click += new System.EventHandler(this.removeDoc_btn_Click);
            // 
            // docFile_ofg
            // 
            this.docFile_ofg.DefaultExt = "txt";
            this.docFile_ofg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.docFile_ofg.FilterIndex = 2;
            this.docFile_ofg.InitialDirectory = "C:\\";
            this.docFile_ofg.ReadOnlyChecked = true;
            this.docFile_ofg.RestoreDirectory = true;
            this.docFile_ofg.ShowReadOnly = true;
            this.docFile_ofg.Title = "Browse Text Files";
            // 
            // noresult_pb
            // 
            this.noresult_pb.ImageLocation = "C:\\Users\\ligal\\Desktop\\IR project\\IR project\\images\\noResults.png";
            this.noresult_pb.InitialImage = ((System.Drawing.Image)(resources.GetObject("noresult_pb.InitialImage")));
            this.noresult_pb.Location = new System.Drawing.Point(254, 558);
            this.noresult_pb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.noresult_pb.Name = "noresult_pb";
            this.noresult_pb.Size = new System.Drawing.Size(783, 615);
            this.noresult_pb.TabIndex = 17;
            this.noresult_pb.TabStop = false;
            this.noresult_pb.Visible = false;
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 1094);
            this.Controls.Add(this.noresult_pb);
            this.Controls.Add(this.removeDoc_btn);
            this.Controls.Add(this.AddDoc_btn);
            this.Controls.Add(this.admPanel_pnl);
            this.Controls.Add(this.Greating_lbl);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AdminPanel";
            this.Text = "Admin Pannel";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.delDoc_tab.ResumeLayout(false);
            this.delDoc_tab.PerformLayout();
            this.addDoc_tab.ResumeLayout(false);
            this.addDoc_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DocCreationDate_np)).EndInit();
            this.admPanel_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.noresult_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Greating_lbl;
        private System.Windows.Forms.TabPage delDoc_tab;
        private System.Windows.Forms.TabPage addDoc_tab;
        private MaterialSkin.Controls.MaterialTabControl admPanel_pnl;
        private MaterialSkin.Controls.MaterialRaisedButton AddDoc_btn;
        private MaterialSkin.Controls.MaterialRaisedButton removeDoc_btn;
        private MaterialSkin.Controls.MaterialRaisedButton Search_btn;
        private MaterialSkin.Controls.MaterialSingleLineTextField SearchBox_txt;
        private System.Windows.Forms.TableLayoutPanel SearchRes_Table;
        private MaterialSkin.Controls.MaterialSingleLineTextField PathBox_txt;
        private MaterialSkin.Controls.MaterialRaisedButton Browse_btn;
        private MaterialSkin.Controls.MaterialSingleLineTextField DocAuthor_txt;
        private MaterialSkin.Controls.MaterialSingleLineTextField DocName_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown DocCreationDate_np;
        private System.Windows.Forms.OpenFileDialog docFile_ofg;
        private MaterialSkin.Controls.MaterialRaisedButton insertDoc_form__btn;
        private System.Windows.Forms.Label AlertMsg_lbl;
        private System.Windows.Forms.Label ConfirmTxt_lbl;
        private System.Windows.Forms.PictureBox noresult_pb;
    }
}