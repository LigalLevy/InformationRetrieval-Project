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
using System.Data.Sql;

namespace IR_project
{
    public partial class AdminPanel : MaterialForm
    {
        #region Initial
        private SearchForm _searchForm;
        private ShowDocument _showDoc;
        private RetrievalManager rm;
        private DBAccessor _da;
        string _uploadDocumentl;
        public AdminPanel(SearchForm ParentForm, string UserName)
        {
            _searchForm = ParentForm;
            InitializeComponent();
            rm = new RetrievalManager();
            _da = new DBAccessor();
            Greating_lbl.Text = string.Format("Hello, {0}", UserName);
            SearchRes_Table.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth + 10, 0);
        }
        #endregion Initial

        #region Controller Events

        private void AddDoc_btn_Click(object sender, EventArgs e)
        {
            admPanel_pnl.SelectedTab = addDoc_tab;
        }

        private void removeDoc_btn_Click(object sender, EventArgs e)
        {
            admPanel_pnl.SelectedTab = delDoc_tab; 
        }


        private void Search_btn_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Browse_btn_Click(object sender, EventArgs e)
        {
            _uploadDocumentl = string.Empty;

            if (docFile_ofg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(docFile_ofg.FileName);
                _uploadDocumentl = sr.ReadToEnd();
                PathBox_txt.Text = docFile_ofg.FileName;
                string filename = docFile_ofg.FileName.Substring( docFile_ofg.FileName.LastIndexOf('\\')+1);
                filename = filename.Substring(0, filename.LastIndexOf('.'));
                DocName_txt.Text = filename;
                sr.Close();
            }
        }

         private void SearchRes_Table_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SearchBox_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Search();
            }
        }

        #endregion Controller Events

        #region Private Methods

        private void Search()
        {
            List<Document> docs = new List<Document>();
            string name_to_search = SearchBox_txt.Text;
            docs = rm.GetAllDocsByName(name_to_search);
            showResults(docs);
            noresult_pb.Visible = docs.Count() == 0;
        }

        private void showResults(List<Document> docs)
        {
            string basepath = ConstantStrings.BasePath + @"images\";

            SearchRes_Table.Controls.Clear();
            SearchRes_Table.RowCount = docs.Count();
            SearchRes_Table.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            SearchRes_Table.RowStyles[0] = (new RowStyle(SizeType.AutoSize, 100));
            SearchRes_Table.Height = 10;
            for (int i = 0; i < docs.Count(); i++)
            {
                Panel container = new Panel();
                int localHeight = 0;
                PictureBox iconBtn = new PictureBox();
                
                iconBtn.Click += IconBtn_Click;
               // iconBtn.Location = new Point(0, 200);
                iconBtn.Size = new Size(23, 23);
                if (docs[i].IsAvailable == 1)
                { 
                   // iconBtn.Text = "Delete";
                    iconBtn.Name = "DELETE_" + docs[i].Id;
                    iconBtn.BackgroundImage = Image.FromFile(basepath + "deleteIcon.png");
                }
                else if(docs[i].IsAvailable == 0)
                {
                   // iconBtn.Text = "Restore";
                    iconBtn.Name = "RESTORE_" + docs[i].Id;
                    iconBtn.BackgroundImage = Image.FromFile(basepath + "restoreIcon.gif");
                }
               
                PictureBox pb = new PictureBox();
                pb.Size = new Size(300, 25);
                pb.Location = new Point(50, 0);
                pb.ImageLocation = basepath + "lineSeperatot.png";
                localHeight += 25;


                container.BorderStyle = BorderStyle.None;
                container.AutoSize = true;
                container.Width = SearchRes_Table.Width ;
                // container.Height = 150;

                container.Controls.Add(pb);
                container.Controls.Add(CreateLabel(docs[i].FileName, 12, ref localHeight, FontStyle.Bold, idNum: 1, docId: docs[i].Id));
                container.Controls.Add(CreateLabel(docs[i].Path, 8, ref localHeight, FontStyle.Bold, idNum: 2, docId: docs[i].Id));
                container.Controls.Add(CreateLabel(docs[i].Description + "...", 8, ref localHeight, numOfLines: 4));
                container.Controls.Add(CreateLabel("By: " + docs[i].Author, 10, ref localHeight));

                SearchRes_Table.Controls.Add(iconBtn, 0, i);
                SearchRes_Table.Controls.Add(container, 1, i);
            }

            SearchRes_Table.ColumnStyles[0].SizeType = SizeType.Absolute;
            SearchRes_Table.ColumnStyles[0].Width = 50;
            SearchRes_Table.Visible = true;
        }

        private void IconBtn_Click(object sender, EventArgs e)
        {
            string basepath = ConstantStrings.BasePath + @"images\";

            var icon = (sender as PictureBox);
            string type = icon.Name.Substring(0, icon.Name.LastIndexOf('_'));
            string id = icon.Name.Substring(type.Length+1);
            if (type == "DELETE")
            {
                rm.RemoveFile(id);
                icon.BackgroundImage = Image.FromFile(basepath + "restoreIcon.gif");
                icon.Name = "RESTORE_" + id;
            }
            else if (type == "RESTORE")
            {
                rm.RestoreFile(id);
                icon.BackgroundImage = Image.FromFile(basepath + "deleteIcon.png");
                icon.Name = "DELETE_" + id;
            }
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

        private void LinkedLabel_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (_showDoc != null)
            {
                _showDoc.Dispose();
            }
            _showDoc = new ShowDocument(label.Name.Substring(label.Name.IndexOf("_")));
            _showDoc.Visible = true;
        }

        private void insertDoc_form__btn_Click(object sender, EventArgs e)
        {
            ConfirmTxt_lbl.Visible = AlertMsg_lbl.Visible = false;
            Document doc;
            StringBuilder msg;
            if (ValidateInsertForm(out msg))
            {
                doc = new Document
                {
                    FileName = DocName_txt.Text,
                    Author = DocAuthor_txt.Text,
                    content = _uploadDocumentl,
                    CreationYear = (int)DocCreationDate_np.Value,
                    IsAvailable = 1,
                    OriginalPath = PathBox_txt.Text
                };

                List<Document> doclist = new List<Document>();
                doclist.Add(doc);
                try
                {
                    rm.InsertNewDocuments(doclist);
                    _searchForm.RefreshData();
                    ConfirmTxt_lbl.Visible = true;
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    AlertMsg_lbl.Text = "* Document could not be Uploaded";
                    AlertMsg_lbl.Visible = true;
                }
            }
            else
            {
                AlertMsg_lbl.Text = msg.ToString();
                AlertMsg_lbl.Visible = true;
            }
        }

        private bool ValidateInsertForm(out StringBuilder msg)
        {
            msg = new StringBuilder();
            if (string.IsNullOrEmpty(_uploadDocumentl)) { msg.AppendLine("* Please Select File"); }
            if (string.IsNullOrEmpty(PathBox_txt.Text)) { msg.AppendLine("* Please Select File Path"); }
            if (string.IsNullOrEmpty(DocName_txt.Text)) { msg.AppendLine("* Please Select Document Title"); }
            if (string.IsNullOrEmpty(DocAuthor_txt.Text)) { msg.AppendLine("* Please Select Document Author"); }

            return string.IsNullOrEmpty(msg.ToString());
        }

        #endregion Private Methods

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }

        private void SearchBox_txt_Click(object sender, EventArgs e)
        {

        }
    }
}
