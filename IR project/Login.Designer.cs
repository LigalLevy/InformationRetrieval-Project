namespace IR_project
{
    partial class LogIn
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
            this.LoginUserName_txt = new System.Windows.Forms.TextBox();
            this.lbl_msg = new System.Windows.Forms.Label();
            this.Login_btn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.LoginPassword_txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LoginUserName_txt
            // 
            this.LoginUserName_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LoginUserName_txt.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LoginUserName_txt.Location = new System.Drawing.Point(47, 73);
            this.LoginUserName_txt.Margin = new System.Windows.Forms.Padding(2);
            this.LoginUserName_txt.Name = "LoginUserName_txt";
            this.LoginUserName_txt.Size = new System.Drawing.Size(409, 26);
            this.LoginUserName_txt.TabIndex = 11;
            this.LoginUserName_txt.Enter += new System.EventHandler(this.LoginUserName_txt_Enter);
            this.LoginUserName_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginUserName_txt_KeyPress);
            this.LoginUserName_txt.Leave += new System.EventHandler(this.LoginUserName_txt_Leave);
            // 
            // lbl_msg
            // 
            this.lbl_msg.AutoSize = true;
            this.lbl_msg.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_msg.Location = new System.Drawing.Point(44, 183);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(35, 13);
            this.lbl_msg.TabIndex = 10;
            this.lbl_msg.Text = "label1";
            this.lbl_msg.Visible = false;
            // 
            // Login_btn
            // 
            this.Login_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Login_btn.Depth = 0;
            this.Login_btn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Login_btn.Location = new System.Drawing.Point(201, 156);
            this.Login_btn.MouseState = MaterialSkin.MouseState.HOVER;
            this.Login_btn.Name = "Login_btn";
            this.Login_btn.Primary = true;
            this.Login_btn.Size = new System.Drawing.Size(82, 26);
            this.Login_btn.TabIndex = 9;
            this.Login_btn.Text = "Log In";
            this.Login_btn.UseVisualStyleBackColor = false;
            this.Login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // LoginPassword_txt
            // 
            this.LoginPassword_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LoginPassword_txt.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LoginPassword_txt.Location = new System.Drawing.Point(47, 113);
            this.LoginPassword_txt.Margin = new System.Windows.Forms.Padding(2);
            this.LoginPassword_txt.Name = "LoginPassword_txt";
            this.LoginPassword_txt.Size = new System.Drawing.Size(409, 26);
            this.LoginPassword_txt.TabIndex = 8;
            this.LoginPassword_txt.Enter += new System.EventHandler(this.LoginPassword_txt_Enter);
            this.LoginPassword_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginPassword_txt_KeyPress);
            this.LoginPassword_txt.Leave += new System.EventHandler(this.LoginPassword_txt_Leave);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 225);
            this.Controls.Add(this.LoginUserName_txt);
            this.Controls.Add(this.lbl_msg);
            this.Controls.Add(this.Login_btn);
            this.Controls.Add(this.LoginPassword_txt);
            this.Name = "LogIn";
            this.Text = "Log In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LoginUserName_txt;
        private System.Windows.Forms.Label lbl_msg;
        private MaterialSkin.Controls.MaterialRaisedButton Login_btn;
        private System.Windows.Forms.TextBox LoginPassword_txt;
    }
}