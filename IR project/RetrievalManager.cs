using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Microsoft.VisualBasic;



namespace IR_project
{

    class RetrievalManager
    {
        private DBAccessor da = new DBAccessor();
        private Dictionary<string, List<string>> termsDictionary = new Dictionary<string, List<string>>();
        private List<string> allDocs = new List<string>();

        public RetrievalManager()
        {
            this.UpdatePostingFileToDictionary();
        }

        #region Files 

        /**Get array of files from the source file directory*/
        public List<string> GetSourceDoc()
        {
            string sourceDocDirectory = ConstantStrings.BasePath + @"SourceFiles";
            string[] files = System.IO.Directory.GetFiles(sourceDocDirectory, "*.txt");
            List<string> pathOfFiles = new List<string>();

            foreach (string file in files)
            {
                pathOfFiles.Add(file);
            }

            return pathOfFiles;
        }

        /** 
           * Move the inverted files from the source dir to the stored dir 
           * and delete them from source file
           */
        public void TransferInvertedDocs(ref List<Document> docs)
        {
            string storedFileDir = ConstantStrings.BasePath + @"StoredFiles\";
            string defSourceFolder = ConstantStrings.BasePath + @"SourceFiles\";
            foreach (Document doc in docs)
            {
                string filename = Path.GetFileName(doc.OriginalPath);
                filename = FindRecursiveFileName(filename, filename, storedFileDir, 1);
                string destDir = storedFileDir + filename;
           
                System.IO.File.Copy(doc.OriginalPath, destDir);
                doc.Path = destDir;
            }
        }

        private string FindRecursiveFileName(string originalName, string fileName, string storedFileDir, int counter)
        {
            //string filename = Path.GetFileName(doc.OriginalPath);
            string destDir = storedFileDir + fileName;
            if (File.Exists(destDir))
            {
                string name = originalName.Substring(0, originalName.LastIndexOf('.'));
                string type = originalName.Substring(originalName.LastIndexOf('.') + 1);
                fileName = string.Format("{0}({1}).{2}", name, counter, type);

                return FindRecursiveFileName(originalName, fileName, storedFileDir, counter+1);
            }
            else return fileName;
        }

        private void DelSourceFile(List<Document> docs)
        {
            string defSourceFolder = ConstantStrings.BasePath + @"StoredFiles\";

            foreach (Document doc in docs)
            {
                string filename = Path.GetFileName(doc.OriginalPath);

                // Delete a file from source dir
                if (doc.OriginalPath.StartsWith(defSourceFolder) && System.IO.File.Exists(doc.OriginalPath))
                {
                    try
                    {
                        System.IO.File.Delete(doc.OriginalPath);
                    }
                    catch (System.IO.IOException e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }
                }
            }
        }

        /** send files to Parsing to array of words + num of hits
         * insert values to the terms table at the DB 
         * moving the files to the stored file directory  */
        public void InsertNewDocuments(List<Document> docs)
        {
            Dictionary<string, int> indexWords = new Dictionary<string, int>();
            List<string> words = new List<string>();
            int wordId = -1;

            TransferInvertedDocs(ref docs);
            foreach (Document doc in docs)
            {
                doc.Path = doc.Path.Replace(@"\", @"\\");
                doc.Id = da.AddDocument(doc);
                words = PrepareDoc(doc.Path);
                indexWords = SortingWords(words);

                KeyValuePair<string, int> cuurWord;

                foreach (KeyValuePair<string, int> word in indexWords)
                {
                    try
                    {
                        cuurWord = word;
                        string key = cuurWord.Key.Replace("'", "''");
                        wordId = da.GetTermId(key);

                        if (wordId == -1)
                            da.AddNewTerm(key);

                        Term term = new Term(key, cuurWord.Value, doc.Id.ToString());
                        da.AddTermToPostingfile(term);
                    }
                    catch (Exception ex)
                    {
                        int i = 5;
                        i++;
                        //do nothing
                        // throw;

                    }
                }
                DelSourceFile(docs);
                UpdatePostingFileToDictionary();
            }
           
        }

        /** Parsing the Docs to list of words **/
        public List<string> PrepareDoc(string doc)
        {
            List<string> new_words = new List<string>();

            string[] words = Utilities.ParseFiles(doc);
            new_words = Utilities.ListToLower(words);
            new_words = Utilities.StemmWords(new_words);
            new_words = Utilities.RemoveStopWords(new_words);

            return new_words;
        }

        public void RemoveFile(string file_id)
        {
            da.RemoveDocument(file_id);
            UpdatePostingFileToDictionary();
        }

        public void RestoreFile(string file_id)
        {
            da.RestoreDocument(file_id);
            UpdatePostingFileToDictionary();
        }


        #endregion

        #region Terms

        /**
         * Count hits of Term in a Doc and sorting them to Dictionary **/
        public Dictionary<string, int> SortingWords(List<string> words)
        {
            Dictionary<string, int> sortedWords = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (!sortedWords.ContainsKey(word))
                    sortedWords.Add(word, 1);

                else
                    sortedWords[word]++;
            }

            //sort words in Alphabetical order 
            var sorted = sortedWords.OrderBy(key => key.Key);
            var sortedIndex = sorted.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);

            return sortedIndex;
        }


        public void UpdatePostingFileToDictionary()
        {
            termsDictionary = da.GetDictionary();
        }

        #endregion Terms

        #region Query result

        /** the main searching function -- call from UI **/
        public List<Document> Search(string query)
        {
            Stack<List<string>> result = new Stack<List<string>>();
            result = ParseQuery(query);
            List<string> docs = new List<string>();

            if (result.Count() > 0)
            {
                foreach (string doc in result.Pop())
                {
                    if (!docs.Contains(doc))
                        docs.Add(doc);
                }
            }
            var retDocs = da.GetDocsById(docs);
            GetDescriptionForDocs(ref retDocs);
            return retDocs;
        }

        /**
         * searching terms with the boolean operators in the Docs by this logic:
         * AND: Include two search terms. Example: dog AND cat
         * OR: Broaden your search with multiple terms. Example: dog OR cat (docs with "dog" or "cat", not both terms together.
         * NOT: Use to exclude a specific term.
         * **/
        public Stack<List<string>> ParseQuery(string query)
        {
            List<string> operators = new List<string>() { "and", "or", "not" };
            List<string> queryList = SplitQueryToArray(query);
            Queue<string> queryQueue = new Queue<string>(OrderQuery(queryList));
            Stack<List<string>> result = new Stack<List<string>>();

            while (queryQueue.Count() != 0)
            {
                string token = queryQueue.Dequeue();

                if (!operators.Contains(token))
                {
                    if (this.termsDictionary.ContainsKey(token))
                        result.Push(this.termsDictionary[token]);
                    else
                    {
                        result.Push(new List<string>());
                    }
                }

                else if (token.CompareTo("and") == 0)
                {
                    var right_word = result.Pop();
                    var left_word = result.Pop();
                    var tmpResult = (right_word.Intersect(left_word)); //AND == intersect
                    List<string> tempList = new List<string>();
                    foreach (string doc in tmpResult)
                    {
                        tempList.Add(doc);
                    }
                    result.Push(tempList);
                }

                else if (token.CompareTo("or") == 0)
                {
                    var right_opr = result.Pop();
                    var left_opr = result.Pop();
                    var tmpResult = right_opr.Union(left_opr); //OR == UNION
                    List<string> tempList = new List<string>();
                    foreach (string doc in tmpResult)
                    {
                        tempList.Add(doc);
                    }
                    result.Push(tempList);

                }

                else if (token.CompareTo("not") == 0)
                {
                    var right_opr = result.Pop();
                    if (result.Count == 0)
                        result.Push(new List<string>());

                    var tmpResult = result.Pop().Except(right_opr);
                    List<string> tempList = new List<string>();
                    foreach (string doc in tmpResult)
                    {
                        tempList.Add(doc);
                    }

                    result.Push(tempList);
                }
            }

            if (result.Count == 2)
            {
                var right_word = result.Pop();
                var left_word = result.Pop();
                var tmpResult = (right_word.Intersect(left_word)); //AND == intersect
                List<string> tempList = new List<string>();
                foreach (string doc in tmpResult)
                {
                    tempList.Add(doc);
                }
                result.Push(tempList);
            }

            return result;
        }


        /**
        * turn over all words to lower case + stemming.
        * Return a list of splited elements(terms) from the query
        * **/
        public List<string> SplitQueryToArray(string query)
        {
            List<string> words = new List<string>();
            query = query.Replace("(", " ( ");
            query = query.Replace(")", " ) ");

            string[] wordsOfQuery = query.Split(' ');

            foreach (string word in wordsOfQuery)
            {
                if (word.CompareTo("") != 0)
                {
                    string tmp_word = word.ToLower();
                    tmp_word = Utilities.Stemming(tmp_word);
                    words.Add(tmp_word);
                }
            }

            return words;
        }

        /**
         * Sets the query in order of precedence rules 
         * Return the words ordered in Queue (FIFO)**/
        public Queue<string> OrderQuery(List<string> words)
        {
            Dictionary<string, int> precedence = new Dictionary<string, int>();
            precedence.Add("not", 3);
            precedence.Add("and", 2);
            precedence.Add("or", 1);
            precedence.Add("(", 0);
            precedence.Add(")", 0);

            Queue<string> output = new Queue<string>();
            Stack<string> operator_stack = new Stack<string>();

            foreach (string word in words)
            {
                if (word.CompareTo("(") == 0)
                {
                    operator_stack.Push(word);
                }
                else if (word.CompareTo(")") == 0)
                {
                    string _operator = operator_stack.Pop();
                    while (_operator.CompareTo("(") != 0)
                    {
                        output.Enqueue(_operator);
                        _operator = operator_stack.Pop();
                    }
                }
                else if (precedence.ContainsKey(word))
                {
                    if (operator_stack.Count() != 0)
                    {
                        string tmp_operator = operator_stack.Peek();
                        while (operator_stack.Count() != 0 && (precedence[tmp_operator] > precedence[word]))
                        {
                            output.Enqueue(operator_stack.Pop());
                            if (operator_stack.Count() != 0)
                            {
                                tmp_operator = operator_stack.Peek();
                            }
                        }
                    }
                    operator_stack.Push(word);
                }

                else //some term
                    output.Enqueue(word);
            }

            while (operator_stack.Count() != 0)
            {
                output.Enqueue(operator_stack.Pop());
            }

            return output;
        }
       

        /**
         * takes 3 lines from the document and dispay them in the final result 
         * in the UI to the user **/
        private void GetDescriptionForDocs(ref List<Document> docs)
        {
            if(docs != null && docs.Count > 0)
            {
                string storedFileDir = ConstantStrings.BasePath + @"StoredFiles\";
                foreach (Document doc in docs)
                {
                    if (System.IO.File.Exists(doc.Path))
                    {
                        StringBuilder str = new StringBuilder();
                        var first3Lines = File.ReadLines(doc.Path).Take(3).ToList();
                        foreach (var line in first3Lines)
                        {
                            str.AppendLine(line);
                        }
                        doc.Description = str.ToString();
                    }
                }
            }
        }


        public List<Document> GetAllDocsByName(string name)
        {
            var retDocs = da.GetAllDocsByName(name);
            GetDescriptionForDocs(ref retDocs);
            return retDocs;
        }

        #endregion Query result

    }
}









