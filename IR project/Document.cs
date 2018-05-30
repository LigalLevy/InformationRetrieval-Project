using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_project
{
    class Document
    {

        public string Id { get; set; }

        public string FileName { get; set; }

        public string Author { get; set; }

        public int CreationYear { get; set; }

        public string Path { get; set; }

        public string OriginalPath { get; set; }

        public int IsAvailable { get; set; }

        public string Description { get; set; }

        public string content { get; set; }

    }
}
