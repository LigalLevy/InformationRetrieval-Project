using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace IR_project
{
    class DBAccessor
    {
        private DBCConnector _db;

        //C'tor
        public DBAccessor()
        {
            _db = new DBCConnector();
            _db.Initialize();
            // createTables(_db); //ONLY at first time
        }

        private void createTables(DBCConnector _db)
        {
            var invertedFilesTable = new List<string>();
            invertedFilesTable.Add("File_id VARCHAR(50) NOT NULL");
            invertedFilesTable.Add("Name VARCHAR(50) NOT NULL");
            invertedFilesTable.Add("Author VARCHAR(30)");
            invertedFilesTable.Add("CreationYear INT");
            invertedFilesTable.Add("Path VARCHAR(200) NOT NULL");
            invertedFilesTable.Add("IsAvailable TINYINT(1) NOT NULL");
            invertedFilesTable.Add("PRIMARY KEY (File_id)");
            _db.CreateTable("Files", invertedFilesTable);

            var LookupTermsTable = new List<string>();
            LookupTermsTable.Add("Term_id INT NOT NULL AUTO_INCREMENT");
            LookupTermsTable.Add("Term_txt VARCHAR(30) NOT NULL");
            LookupTermsTable.Add("PRIMARY KEY (Term_id)");
            _db.CreateTable("LookupTerms", LookupTermsTable);

            var PostingFileTable = new List<string>();
            PostingFileTable.Add("Term_id INT NOT NULL AUTO_INCREMENT");
            PostingFileTable.Add("TermName VARCHAR(30) NOT NULL");
            PostingFileTable.Add("File_id  VARCHAR(50) NOT NULL");
            PostingFileTable.Add("Hits INT NOT NULL");
            PostingFileTable.Add("PRIMARY KEY (Term_id , File_id)");
            PostingFileTable.Add("FOREIGN KEY (File_id) REFERENCES Files(File_id)");
            PostingFileTable.Add("FOREIGN KEY (Term_id) REFERENCES LookupTerms(Term_id)");
            _db.CreateTable("PostingFile", PostingFileTable);


        }

        #region Insert to DB 

        public string AddDocument(Document doc)
        {
            Guid gd = Guid.NewGuid();
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add("File_id", gd.ToString());
            fields.Add("Name", doc.FileName);
            fields.Add("Author", doc.Author);
            fields.Add("CreationYear", doc.CreationYear.ToString());
            fields.Add("Path", doc.Path);
            fields.Add("IsAvailable", doc.IsAvailable.ToString());

            _db.Insert("sherlock.files", fields);

            return gd.ToString();
        }

        public void AddNewTerm(string term)
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add("Term_txt", term);

            _db.Insert("sherlock.lookupterms", fields);
        }

        public void AddTermToPostingfile(Term term)
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add("Term_id", term.Term_id.ToString());
            fields.Add("TermName", term.TermTxt);
            fields.Add("File_id", term.FileId.ToString());
            fields.Add("Hits", term.Hits.ToString());

            _db.Insert("Sherlock.PostingFile", fields);
        }

        #endregion INSERT to DB 

        #region Get data from DB

        /**
         * If returns empty string - there is no such a term in the lookup table 
         * if you get something it means it's the id of the term
         * */
        public int GetTermId(string term)
        {
            MySqlDataReader dataReader = _db.Select("SELECT distinct Term_id FROM sherlock.lookupterms WHERE Term_txt='" + term + "'", false);
            if (dataReader == null)
            {
                //close Connection
                _db.CloseConnection();
                return -1;
            }
            else
            {
                int term_id = -1;
                while (dataReader.Read())
                    term_id = int.Parse(dataReader["Term_id"].ToString());

                //close Connection
                _db.CloseConnection();

                return term_id;
            }
        }

        /**
         * return a Dictionary of Term + All Docs that conatain Term
         * call this function every insert of new doc**/
        public Dictionary<string, List<string>> GetDictionary()
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            List<string> terms = new List<string>();

            MySqlDataReader dataReader = _db.Select("SELECT Term_txt FROM sherlock.lookupterms ORDER BY Term_txt ", false);
            if (dataReader == null)
            {
                _db.CloseConnection();
                return dictionary;
            }
            else
            {
                while (dataReader.Read())
                {
                    string term = dataReader["Term_txt"].ToString().Replace("'", "''");
                    terms.Add(term);
                }
            }

            dataReader.Dispose();
            _db.CloseConnection();

            foreach (string term in terms)
            {
                List<string> docs = new List<string>();
                dataReader = _db.Select(@"SELECT DISTINCT sherlock.postingfile.File_id FROM sherlock.postingfile, sherlock.files 
                                        WHERE postingfile.TermName='" + term + @"' AND files.Isavailable = 1
                                        ORDER BY Hits DESC", false);

                if (dataReader == null)
                {
                    _db.CloseConnection();
                    return null;
                }
                else
                {
                    while (dataReader.Read())
                    {
                        docs.Add(dataReader["File_id"].ToString());
                    }

                    dictionary.Add(term, docs);
                    _db.CloseConnection();
                }
            }

            return dictionary;
        }

        public List<string> GetDocsByTerm(string term)
        {
            List<string> docList = new List<string>();
            MySqlDataReader dataReader = _db.Select(@"SELECT sherlock.PostingFile.File_id,sherlock.files.IsAvailable
                                                    FROM sherlock.PostingFile ,sherlock.files
                                                    WHERE sherlock.PostingFile.TermName ='" + term
                                                    + "' AND sherlock.files.IsAvailable = 1", false);

            if (dataReader == null)
            {
                //close Connection
                _db.CloseConnection();
                return null;
            }
            else
            {
                List<string> files = new List<string>();
                while (dataReader.Read())
                {
                    files.Add(dataReader["File_id"].ToString());
                }

                //close Connection
                _db.CloseConnection();
                return docList;
            }
        }

        public List<Document> GetAllDocsByName(string name)
        {
            List<Document> docList = new List<Document>();
            MySqlDataReader dataReader = _db.Select("SELECT * FROM sherlock.files WHERE files.Name LIKE '%" + name + "%'", false);

            if (dataReader == null)
            {
                //close Connection
                _db.CloseConnection();
                return null;
            }

            else
            {
                while (dataReader.Read())
                {
                    Document doc = new Document();

                    doc.Id = dataReader["File_id"].ToString();
                    doc.FileName = dataReader["Name"].ToString();
                    doc.Author = dataReader["Author"].ToString();
                    doc.CreationYear = int.Parse(dataReader["CreationYear"].ToString());
                    doc.Path = dataReader["Path"].ToString();
                    bool ia = bool.Parse(dataReader["IsAvailable"].ToString());
                    doc.IsAvailable = ia == true ? 1 : 0;

                    //if (doc.IsAvailable == 1)
                    docList.Add(doc);
                }

                //close Connection
                _db.CloseConnection();
                return docList;
            }
        }

        public List<Document> GetDocsById(List<string> files_id)
        {
            List<Document> docList = new List<Document>();
            foreach (string file_id in files_id)
            {
                MySqlDataReader dataReader = _db.Select("SELECT * FROM sherlock.Files WHERE sherlock.files.IsAvailable = 1 AND File_id='" + file_id + "'", false);

                if (dataReader == null)
                {
                    _db.CloseConnection();
                    return docList;
                }
                else
                {
                    while (dataReader.Read())
                    {
                        Document tmp_doc = new Document();

                        tmp_doc.Id = dataReader["File_id"].ToString();
                        tmp_doc.FileName = dataReader["Name"].ToString();
                        tmp_doc.Author = dataReader["Author"].ToString();
                        tmp_doc.CreationYear = int.Parse(dataReader["CreationYear"].ToString());
                        tmp_doc.Path = dataReader["Path"].ToString();
                        bool ia = bool.Parse(dataReader["IsAvailable"].ToString());
                        tmp_doc.IsAvailable = ia == true ? 1 : 0;

                        docList.Add(tmp_doc);
                    }  
                }
                dataReader.Close();
            }

            //close Connection
            _db.CloseConnection();
            return docList;
        }

        #endregion Get data from DB

        #region Updates to DB

        public void RemoveDocument(string file_id)
        {
            string where = string.Format("File_id = '{0}'", file_id);
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add("isAvailable", "0");

            _db.Update("Sherlock.Files", fields, where);
        }

        public void RestoreDocument(string file_id)
        {
            string where = string.Format("File_id = '{0}'", file_id);
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add("isAvailable", "1");

            _db.Update("Sherlock.Files", fields, where);
        }

        #endregion Updates to DB
    }


    public class DBCConnector
    {
        private MySqlConnection connection;

        //Initialize values
        public void Initialize()
        {
            string connectionString;
            connectionString = "server=127.0.0.1;uid=root;pwd=ligal;database=sherlock;Allow User Variables=True;" +
                              "Convert Zero Datetime = True; Allow Zero Datetime=True;";

            connection = new MySqlConnection(connectionString);

        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                if(connection.State != System.Data.ConnectionState.Open) { connection.Open();}
                Console.WriteLine("CONNECTED");
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                Console.WriteLine("ERROR");
                return false;
            }

        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException)
            {
                Console.WriteLine("ERROR");
                return false;
            }
        }

        //Create new table
        public void CreateTable(string tableName, List<string> fields)
        {
            string query = string.Format("Create Table {0} (", tableName);
            foreach (var field in fields)
            {
                query += string.Format("{0},", field);
            }
            query = query.Substring(0, query.Length - 1);
            query += ");";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Insert statement
        public void Insert(string tableName, Dictionary<string, string> fields)
        {
            string fieldsNames = string.Empty;
            string fieldsValues = string.Empty;
            foreach (var field in fields)
            {
                fieldsNames += string.Format(@"{0}, ", field.Key);
                fieldsValues += string.Format(@"'{0}', ", field.Value);
            }
            fieldsNames = fieldsNames.Substring(0, fieldsNames.Length - 2);
            fieldsValues = fieldsValues.Substring(0, fieldsValues.Length - 2);
            string query = string.Format(@"INSERT INTO {0} ({1}) VALUES ({2})", tableName, fieldsNames, fieldsValues);

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(string tableName, Dictionary<string, string> fields, string where)
        {
            string fieldsNames = string.Join(",", fields.Keys);
            string fieldsValues = string.Join(",", fields.Values);
            string query = string.Format("UPDATE {0} SET ", tableName);//, fieldsNames, fieldsValues);
            foreach (var field in fields)
            {
                query += string.Format("{0} = N'{1}', ", field.Key, field.Value);
            }
            query = query.Substring(0, query.Length - 2);
            if (!string.IsNullOrEmpty(where))
            {
                query += string.Format(" WHERE {0}", where);
            }
            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(string tableName, string where)
        {
            string query = string.Format("DELETE FROM {0}", tableName);
            if (!string.IsNullOrEmpty(where))
            {
                query += string.Format("WHERE {0}", where);
            }

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement 
        public MySqlDataReader Select(string query, bool closeConnection)
        {
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                ////close Connection
                if (closeConnection)
                {
                    this.CloseConnection(); return null;
                }

                //return list to be displayed
                return dataReader;
            }
            else
            {
                return null;
            }
        }

        public MySqlDataReader RunTransaction(string fullQuery, bool closeConnection)
        {
            fullQuery = string.Format("START TRANSACTION;\n {0}\n COMMIT;", fullQuery);
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(fullQuery, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (closeConnection)
                {
                    this.CloseConnection(); return null;
                }

                //return list to be displayed
                return dataReader;
            }
            else
            {
                return null;
            }
        }
    }
}