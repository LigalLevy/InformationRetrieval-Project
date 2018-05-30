using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IR_project
{
    public partial class ShowDocument : MaterialForm
    {
        private string _docId;
        private Document _doc;
        private RetrievalManager rm;
        private DBAccessor _da;

        public ShowDocument(string docId)
        {
            _docId = docId;
            InitializeComponent();
            rm = new RetrievalManager();
            _da = new DBAccessor();

            getDocument();
        }

        private void getDocument()
        {
            _doc = _da.GetDocsById(new List<string> { _docId }).FirstOrDefault();
            if(_doc == null)
            {
                MessageBox.Show("Document could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            docContent_rtb.Text = GetFileContent();

        }

        private string GetFileContent()
        {
            StringBuilder content = new StringBuilder();
            if (_doc != null && _doc.Path!= null)
            {
                if (System.IO.File.Exists(_doc.Path))
                {
                    var Lines = File.ReadLines(_doc.Path).ToList();
                    foreach (var line in Lines)
                    {
                        content.AppendLine(line);
                    }   
                }
            }
            return content.ToString();
        }

        private void print_img_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.DocumentName = _doc.Path; 
                prontDoc_pd.Document = printDoc;
                prontDoc_pd.AllowSelection = true;
                prontDoc_pd.AllowSomePages = true;

                //Call ShowDialog
                if (prontDoc_pd.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message + "\n\n Unable to print the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } // end catch
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = _doc.FileName;
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.FileName = _doc.FileName;
            //saveFileDialog1.RestoreDirectory = true;

            var result = saveFileDialog1.ShowDialog(); //shows save file dialog
            if (result == DialogResult.OK)
            {
                System.IO.File.Copy(_doc.Path, saveFileDialog1.FileName);
            }
        }
    }
}
