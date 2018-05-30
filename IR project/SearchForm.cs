using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IR_project
{
    public partial class SearchForm : MaterialForm
    {
        #region Initialize
      
        RetrievalManager _IRManager;
        LogIn _loginForm;
        AdminPanel _adminPanel;
        ShowDocument _showDoc;
        Mode _mode;

        public SearchForm()
        {
            InitializeComponent();
            setComponents();
            _IRManager = new RetrievalManager();
            _mode = Mode.User;

            //this 2 method is for DEBUG
           // _IRManager.UpdatePostingFileToDictionary();
           //_IRManager.ParseQuery(" love NOT Eye AND (ODED or LIGAL");
            
        }

        private void setComponents()
        {
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.Blue500, Primary.Grey800, Primary.Purple50, Accent.DeepPurple700, TextShade.BLACK);

            SearchRes_Table.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth + 10, 0);
        }

        #endregion Initialize

        #region Public Methods

        public void AdminLogedIn(bool isSuccess, string userName)
        {
            _mode = Mode.Admin;
            setMode(userName);
        }

        public void RefreshData()
        {
            _IRManager.UpdatePostingFileToDictionary();
        }

        #endregion Public Methods

        #region Event Handlers
        
        private void Search_btn_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void SearchBox_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginIcon_img_Click(object sender, EventArgs e)
        {

          //  AdminLogedIn(true, "Admin");
           // return;

            if(_loginForm == null)
            {
                _loginForm = new LogIn(this);
            }
            _loginForm.Show();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {

        }

        private void SearchBox_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Search();
            }
        }

        #endregion Event Handlers

        #region Private Methods
        private void showResults(List<Document> docs)
        {

            string basepath  = ConstantStrings.BasePath +  @"images\";

            SearchRes_Table.Controls.Clear();
            SearchRes_Table.RowCount = docs.Count();
            SearchRes_Table.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            SearchRes_Table.RowStyles[0] = (new RowStyle(SizeType.AutoSize, 100));
            SearchRes_Table.Height = 10;

            for (int i = 0; i < docs.Count(); i++)
            {
                int localHeight = 0; //6

                Panel container = new Panel();
                container.Name = "Panel_" + docs[i].Id;
               
                PictureBox pb = new PictureBox();
                pb.Size = new Size(300, 25);
                pb.Location = new Point(90, 0);
                pb.ImageLocation = basepath + "lineSeperatot.png";
                localHeight += 25;

                container.BorderStyle = BorderStyle.None;
                //container.AutoSize = true;
                container.Width = SearchRes_Table.Width;
                container.Height = 170;

                container.Controls.Add(pb);
                container.Controls.Add(CreateLabel(docs[i].FileName, 12, ref localHeight, FontStyle.Bold, idNum:1, docId: docs[i].Id));
                container.Controls.Add(CreateLabel(docs[i].Path, 8, ref localHeight, FontStyle.Bold, idNum: 2, docId: docs[i].Id));
                container.Controls.Add(CreateLabel(docs[i].Description +  "...", 8, ref localHeight, numOfLines:4));
                container.Controls.Add(CreateLabel("By: " + docs[i].Author, 10, ref localHeight));

                SearchRes_Table.Controls.Add(container, 0, i);
            }

            SearchRes_Table.AutoScroll = true;
        }

       
        private Label CreateLabel(string text, int fontSize, ref int localHeight, 
            FontStyle fontStyle = FontStyle.Regular, int numOfLines = 1, string fontfamily = "Arial",
            int? idNum = null, string docId = "")
        {
            var label = new Label();
            label.AutoSize = true;
            label.Font = new Font(fontfamily, fontSize, fontStyle);
            label.ForeColor = Color.DarkGray;
            label.Text = text;
            label.Location = new Point(0, localHeight);
            localHeight += (numOfLines - 1) * 10 + label.Height + 7;

            if (idNum.HasValue && !string.IsNullOrEmpty(docId))
            {
                label.Name = string.Format("lbl{0}_{1}", idNum, docId);
                label.Cursor = System.Windows.Forms.Cursors.Hand;
                label.Click += LinkedLabel_Click;
            }

            return label;
        }

         private void openAdminPanel(string userName)
        {
            if (_adminPanel == null)
            {
                _adminPanel = new AdminPanel(this, userName);
            }
            _adminPanel.Show();
        }
        
        private void setMode(string userName)
        {
            string text = string.Format("Hello, {0}", userName);
            switch (_mode)
            {
                case Mode.Admin:
                    Greating_lbl.Text = text;
                    Greating_lbl.Visible = true;
                    loginIcon_img.Visible = false;
                    openAdminPanel(userName);
                    break;
                case Mode.User:
                    break;
                default:
                    break;
            }
        }


        private void LinkedLabel_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (_showDoc != null)
            {
                _showDoc.Dispose();
            }
            _showDoc = new ShowDocument(label.Name.Substring(label.Name.IndexOf("_")+1));
            _showDoc.Visible = true;
        }

        private RichTextBox CreateLinkedLabel(string text, int fontSize, ref int localHeight,
                                 FontStyle fontStyle = FontStyle.Regular, string fontfamily = "Arial", int numOfLines = 1)
        {
            var richTextBox = new RichTextBox();
            richTextBox.AutoSize = true;
            richTextBox.Font = new Font(fontfamily, fontSize, fontStyle);
            richTextBox.ForeColor = Color.DarkGray;
            richTextBox.Text = text;
            richTextBox.Location = new Point(0, localHeight);

            richTextBox.ReadOnly = true;
            richTextBox.BorderStyle = BorderStyle.None;
            richTextBox.TabStop = false;
            //richTextBox.(ControlStyles.Selectable, false);
           // richTextBox.SetStyle(ControlStyles.UserMouse, true);
            //richTextBox.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            localHeight += (numOfLines - 1) * 10 + richTextBox.Height + 7;


            return richTextBox;
        }

        private void Search()
        {
            string text = SearchBox_txt.Text;
            List<Document> docs = new List<Document>();
            docs = _IRManager.Search(text);

            showResults(docs);
            noresult_pb.Visible = docs.Count() == 0;
        }

        #endregion Private Methods


    }
}
