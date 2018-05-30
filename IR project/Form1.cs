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
    public partial class Form1 : MaterialForm
    {
        DBAccesser _db;
        RetrievalManager IRManager;
        public Form1()
        {
            InitializeComponent();
            _db = new DBAccesser();
            IRManager = new RetrievalManager();

            string[] docs = IRManager.GetSourceDoc();
            IRManager.TransferInvertedDocs(docs);
            //string[] str = util.Tokenize(@"C:\Users\ligal\source\repos\IR project\IR project\SourceFiles\a love lesson.html");
           // util.ParseFiles(@"C:\Users\ligal\source\repos\IR project\IR project\SourceFiles\a love lesson.txt");
          
        }
    }
}
