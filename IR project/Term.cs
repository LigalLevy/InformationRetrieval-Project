using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_project
{
    class Term
    {
        public Term(string TermTxt, int Hits, string FileId)
        {
            DBAccessor db = new DBAccessor();

            this.TermTxt = TermTxt;
            this.Hits = Hits;
            this.FileId = FileId;

            int tmpId = db.GetTermId(TermTxt);

            if (tmpId.CompareTo(-1) == 0)
            {
                db.AddNewTerm(TermTxt);
                this.Term_id = db.GetTermId(TermTxt);
            }
            else
            {
                this.Term_id = tmpId;
            }


        }

        public string TermTxt { get; set; }

        public int Term_id { get; set; }

        public int Hits { get; set; }

        public string FileId { get; set; }

    }
}
