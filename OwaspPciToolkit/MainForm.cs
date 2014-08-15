using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.IO;
using MigraDoc;
using MigraDoc.Rendering;
using MigraDoc.RtfRendering;
using MigraDoc.DocumentObjectModel;
using System.Diagnostics;


namespace OwaspPciToolkit
{
    public partial class MainForm : Form
    {
        #region public variables
        string texthead = null;
        string textL = null;
        string text = null;
        string text1 = null;
        string text2 = null;
        string text3 = null;
        string text4 = null;
        string text5 = null;
        string text6 = null;
        string text7 = null;
        #endregion

        public MainForm()
        {
           
            InitializeComponent();
            DisplayGrid();
            DisplayGridDev();
            DisplayGridTest();
            CreateButton();
            CreateButtonDeveloper();

            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
            //custom events
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            //dataGridView2.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            //dataGridView3.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            //PrintPDFReport();

        }
       
        #region Display-Layout
        private void DisplayGrid()
        {
            #region Style
            dataGridView1.AllowUserToAddRows = false;   
            this.dataGridView1.DefaultCellStyle.WrapMode =DataGridViewTriState.True;
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Question";
            dataGridView1.Columns[0].Width = 500;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns[1].Name = "Quick Tips";
            dataGridView1.RowsDefaultCellStyle.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Red;
            dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToResizeColumns = false;
            #endregion

            #region Grid Content
            string[] row = new string[] { "Does the application store, transmit or process cardholder data?", "Search text the source code of the application for keywords such as :credit card number,PAN"};
            dataGridView1.Rows.Add(row);
            row = new string[] { "Does the application have access controls and authentication mechanism?", "Search for text in source code as: username,password" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Are full credit card numbers or the credit card account numbers displayed to the users ?", "Do a text regex search on source code and database for credit card number format" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Are Card Holder name, PAN, Expiration date or service code stored in the the database or any form of data storage?", "Do a SQL query seraching for credit card number values" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Is any of this data stored in clear text long term, including backups of this data?", "" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Is any of this data transmitted in clear text, internally or externally? Internet traffic is especially dangerous.", "Use WireShark to capture packets and sniff transmission" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Do you share any card holder data with other applications or web services in the same network?", "Use Wireshark to sniff transmission within the network" };
            dataGridView1.Rows.Add(row);
            //row = new string[] { "Does the application have any form of debug log system?", "Do a search on the Web server on the folders containing the logs" };
            //dataGridView1.Rows.Add(row);
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chk);
            chk.HeaderText = "YES";
            chk.Name = "chk";
            DataGridViewCheckBoxColumn chkNo = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chkNo);
            chkNo.HeaderText = "NO";
            chkNo.Name = "chkNo";
            #endregion

        }

        private void DisplayGridDev()
        {
            #region Style
            dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView2.ColumnCount = 2;
            dataGridView2.Columns[0].Name = "Question";
            dataGridView2.Columns[0].Width = 500;
            dataGridView2.Columns[1].Width = 300;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.Columns[1].Name = "Quick Tips";
            dataGridView2.RowsDefaultCellStyle.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView2.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridView2.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AllowUserToResizeColumns = false;
            #endregion

            #region Grid Content
            string[] row = new string[] { "Is there a process to identify security vulnerabilities in the frameworks used?","Is your organization using CWE?" };
            dataGridView2.Rows.Add(row);
            row = new string[] { "Are the framework components regularly up to date?","Example:Using a PHP vulnerable framework such as PHP 5.3.X" };
            dataGridView2.Rows.Add(row);
            row = new string[] { "Does the developer team use industry standards and best practices such as OWASP, SANS or CERT?", "Do you know any OWASP projects? SANS TOP 25?" };
            dataGridView2.Rows.Add(row);
            row = new string[] { "Does the developer team get proper training on OWASP top ten vulnerabilities?", "Ask your developers if they know what is XSS?" };
            dataGridView2.Rows.Add(row);
            row = new string[] { "Do developers and Project Lead use a code review guidelines to implement proper security into the application?", "Has anyone read OWASP Code Review?" };
            dataGridView2.Rows.Add(row);
            row = new string[] { "Do you use production data during development?(example restore a production database)", "Check for BAK files and how they get to the Developer" };
            dataGridView2.Rows.Add(row);
            row = new string[] { "Are there change control process and procedures when changes are done in the code?", "When changes are done to the code...who is in charge to verify the process?" };
            dataGridView2.Rows.Add(row);
            row = new string[] { "Do developers have access to production environment?", "Check if Developers are able to login to production servers with their user accounts" };
            dataGridView2.Rows.Add(row);
            DataGridViewCheckBoxColumn chkDev = new DataGridViewCheckBoxColumn();
            dataGridView2.Columns.Add(chkDev);
            chkDev.HeaderText = "YES";
            chkDev.Name = "chkDev";
            DataGridViewCheckBoxColumn chkDevNo = new DataGridViewCheckBoxColumn();
            dataGridView2.Columns.Add(chkDevNo);
            chkDevNo.HeaderText = "NO";
            chkDevNo.Name = "chkDevNo";
            #endregion

        }

        private void DisplayGridTest()
        {
            #region Style
            dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView3.ColumnCount = 2;
            dataGridView3.Columns[0].Name = "Question";
            dataGridView3.Columns[0].Width = 500;
            dataGridView3.Columns[1].Width = 300;
            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView3.Columns[1].Name = "Quick Tips";
            dataGridView3.RowsDefaultCellStyle.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView3.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
            dataGridView3.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridView3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.AllowUserToResizeColumns = false;
            #endregion

            #region Grid Content
            string[] row = new string[] { "Is the test environment separated from development and production environment?" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Do administrators of the test environment have credentaials to production environment?" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Is the test environment in a DMZ zone and isolated properly from the production environment?", "Do a text regex search on source code and database for credit card number format" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Do the testers use test data exclusively during the testing of the application?", "Do a SQL query seraching for credit card number values" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Do the testers use production data such as real PAN's, CVV or names?", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Are any form of code analysis regularly executed?", "Use WireShark to capture packets and sniff transmission" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Are the penetration tests executed to verify any potential security vulnerability in the application?", "Use Wireshark to sniff transmission within the network" };
            dataGridView3.Rows.Add(row);
            //row = new string[] { "Does the application have any form of debug log system?", "Do a search on the Web server on the folders containing the logs" };
            //dataGridView1.Rows.Add(row);
            DataGridViewCheckBoxColumn chkDTest = new DataGridViewCheckBoxColumn();
            dataGridView3.Columns.Add(chkDTest);
            chkDTest.HeaderText = "YES";
            chkDTest.Name = "chkDTest";
            DataGridViewCheckBoxColumn chkDTestNo = new DataGridViewCheckBoxColumn();
            dataGridView3.Columns.Add(chkDTestNo);
            chkDTestNo.HeaderText = "NO";
            chkDTestNo.Name = "chkDTestNo";
            #endregion



        }


        private void CreateButton()
        {

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "ButtonColumn";
            btn.HeaderText = "TIPS";
            btn.DataPropertyName = "c2";
            btn.Width = 75;
            //DO NOT SET THE UseColumnTextForButtonValue PROPERTY
            //btn.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(btn);


            //You can change the button text in a specify cell by changing the
            //value of that cell directly.
            this.dataGridView1["ButtonColumn", 0].Value = "TIP 1";
            this.dataGridView1["ButtonColumn", 1].Value = "TIP 2";
            this.dataGridView1["ButtonColumn", 2].Value = "TIP 3";
            this.dataGridView1["ButtonColumn", 3].Value = "TIP 4";
            this.dataGridView1["ButtonColumn", 4].Value = "TIP 5";
            this.dataGridView1["ButtonColumn", 5].Value = "TIP 6";
            this.dataGridView1["ButtonColumn", 6].Value = "TIP 7";
        }

        private void CreateButtonDeveloper()
        {

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "ButtonColumnDev";
            btn.HeaderText = "Test";
            btn.DataPropertyName = "c3";
            //DO NOT SET THE UseColumnTextForButtonValue PROPERTY
            //btn.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(btn);


            //You can change the button text in a specify cell by changing the
            //value of that cell directly.
            //this.dataGridView2["ButtonColumn", 0].Value = "TIP 1";
            this.dataGridView1["ButtonColumnDev", 1].Value = "Test";
            //this.dataGridView2["ButtonColumn", 2].Value = "TIP 3";
            

        }

        DataGridViewCheckBoxColumn CreateCheckBox()
        {
            DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn();
            checkBox.DataPropertyName = "Answer";
            checkBox.Width = 100;
            checkBox.Name = "YES";
            return checkBox;
        }
        DataGridViewCheckBoxColumn CreateCheckBoxNo()
        {
            DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn();
            checkBox.DataPropertyName = "NO";
            checkBox.Width = 100;
            checkBox.Name = "NO";
            return checkBox;
        }    

        #endregion

        #region Events

        void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            #region TIPS
            //TIP 1
            if (e.ColumnIndex == 4 && e.RowIndex == 0)
            {
                MessageBox.Show("First of all, you must confirm that the application stores,transmits or process Card Holder Data"
                    + "This can be done using the some of following steps: " +
                    "Open the source code-solution of the application in its corresponding IDE, example: " +
                     "If the application is written in .NET, open the solution in Visual Studio(2013) " +
                    "On the Bar Menu, Go to Edit==>Find & Replace==> Find in Files " +
                    "Be sure that the dropbox textbox is set to 'Look in:Entire Solution'" +
                    "Check the 'Find options' group click 'Use Regular Expressions " +
                    "Write the following Regular Expression to look for Credit Card Numbers, example VISA " +
                    "Visa: ^4[0-9]{12}(?:[0-9]{3})?$ " + "For more regular expressions examples: " +
                    "http://www.regular-expressions.info/creditcard.html." +
                    " You can look through these kind of search options into the source code " +
                    " On a Database, execute a SQL query for example " +
                    "http://www.codeproject.com/Articles/42764/Regular-Expressions-in-MS-SQL-Server-2005-2008 " +
                    " An effective way is to use ASV approved vendors, howeveer this is a more costly option " +
                    " https://www.pcisecuritystandards.org/approved_companies_providers/approved_scanning_vendors.php",
                    "OWASP PCI TIPS", MessageBoxButtons.OK);

            }
            //TIP 2
            if (e.ColumnIndex == 4 && e.RowIndex == 1)
            {
                MessageBox.Show(
                        "You can test this easily by" +
                        " checking that the application forces users to login using credentials. " +
                        "Go to the home page of the web app, are you forced to login or not? " +
                        "Do a quick source code search: " +
                         "Open the source code-solution of the application in its corresponding IDE, example: " +
                         "If the application is written in .NET, open the solution in Visual Studio(2013) " +
                        "On the Bar Menu, Go to Edit==>Find & Replace==> Find in Files " +
                         "Be sure that the dropbox textbox is set to 'Look in:Entire Solution' " +
                        "In the textbox 'Find What' write words such as 'username','login','password' " +
                "You must also be sure that no essential information is disclosed by the application because it was not properly secured " +
                "Check OWASP ZAP tool to execute a quick attack: https://www.owasp.org/index.php/OWASP_Zed_Attack_Proxy_Project ",
                        "OWASP PCI TIPS", MessageBoxButtons.OK);

            }
            //TIP 3
            if (e.ColumnIndex == 4 && e.RowIndex == 2)
            {
                MessageBox.Show(
                " On a Database, execute a SQL query for example " +
                "http://www.codeproject.com/Articles/42764/Regular-Expressions-in-MS-SQL-Server-2005-2008 " +
                "Don't forget to look into the LOG files. Make sure that you understand properly the functionalities of the application " +
                "especially how it generates its logs and pay attention on where are these saved" +
                "Look into the source code for Log functionalities such as :" +
                "log4net  in C#, or JAVA. More info about logging: http://logging.apache.org/" +
                "https://www.owasp.org/index.php/Error_Handling,_Auditing_and_Logging",
                        "OWASP PCI TIPS", MessageBoxButtons.OK);

            }
            //TIP 4
            if (e.ColumnIndex == 4 && e.RowIndex == 3)
            {
                MessageBox.Show(
                " On a Database, execute a SQL query looking for user or customer accounts " +
                " Ask a to log in in a test environment and log into a dummy account. Whta do you see? are any full PAN's " +
                "disclosed to the user? Any credit cards fully disclosed in the web interface?" +
                "Use also the same techniques on TIPS 3",
                        "OWASP PCI TIPS", MessageBoxButtons.OK);

            }

            //TIP 5
            if (e.ColumnIndex == 4 && e.RowIndex == 4)
            {
                MessageBox.Show(
                " Use a combination of TIPS 2, 3 and 4. " +
                "Read more about this on: " +
                "https://www.owasp.org/index.php/Top_10_2013-A6-Sensitive_Data_Exposure",
                        "OWASP PCI TIPS", MessageBoxButtons.OK);

            }
            //TIP 6
            if (e.ColumnIndex == 4 && e.RowIndex == 5)
            {
                MessageBox.Show(
                " Use the techniques described here: " +
                "https://www.owasp.org/index.php/Testing_for_Sensitive_information_sent_via_unencrypted_channels_(OTG-CRYPST-007)",
                        "OWASP PCI TIPS", MessageBoxButtons.OK);

            }

            //TIP 7
            if (e.ColumnIndex == 4 && e.RowIndex == 6)
            {
                MessageBox.Show(
                " It's essential to understand the architecture of the application. Request a the CARD HOLDER DATA diagram " +
                "If the organization does not have one, it's essetial to construct one and understand how is the CHD information moving" +
                "around the network, Example: https://www.fishnetsecurity.com/sites/default/files/Blogs/john-clark-image3.jpg",
                        "OWASP PCI TIPS", MessageBoxButtons.OK);

            }

            #endregion

            #region TEST
            if (e.ColumnIndex == 5 && e.RowIndex == 1)
            {
                LoginTest lg = new LoginTest();
                lg.ShowDialog();
                            
            }

            #endregion
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateAppName().Equals(true))
           {
               return;
           }
           if ( ValidateCheckBox().Equals(false))
           {
               return;
           };

           #region Output text
           OutPutCHDAnalysis();

            ////8
            //if (dataGridView1.Rows[7].Cells[2].Value.Equals(true))
            //{

            //    text4 = "IF the application saves information such as credit card in log files and this is no properly encrypted" + Environment.NewLine +
            //               "The application will not comply with requirement 3 and 4" + Environment.NewLine +
            //                  "Please refer to the following document for more info: https://www.pcisecuritystandards.org/pdfs/pci_fs_data_storage.pdf" + Environment.NewLine +
            //                  "https://www.owasp.org/index.php/Cryptographic_Storage_Cheat_Sheet" + Environment.NewLine +
            //                  "https://www.owasp.org/index.php/Top_10_2010-A7-Insecure_Cryptographic_Storage" + Environment.NewLine;
            //    System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", textL + texthead + text + text1 + text2 + text3 + text4 + text5 + text6 + text7);

            //}

           #endregion

            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex= dataGridView1.CurrentCell.ColumnIndex; 

            dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString();


                dataGridView1.EndEdit();
                MessageBox.Show("Information has been processed-Open the report to find out analysis");
         
            }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateAppName().Equals(true))
            {
                return;
            }
            if (ValidateCheckBox2().Equals(false))
            {
                return;
            };

            OutPutCHDAnalysisDeveloper();
            MessageBox.Show("Information has been processed-Open the report to find out analysis");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidateAppName().Equals(true))
            {
                return;
            }
            if (ValidateCheckBox3().Equals(false))
            {
                return;
            };

            OutPutCHDAnalysisTester();
            MessageBox.Show("Information has been processed-Open the report to find out analysis");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreatePDFReport();
        }

        #endregion

        #region Analysis
        private void OutPutCHDAnalysis()
        {
            

            texthead = "Application Name:" + textBox1.Text.ToString() + Environment.NewLine +
                              "Programming Language:" + comboBox1.Text.ToString() + Environment.NewLine + Environment.NewLine +
                              "Card Holder Data - requirements regarding PCI-DSS" + Environment.NewLine +
                              "In order to verify the veracity of your answers regarding these questions, check the tips and we strongly recommend the following steps:" + Environment.NewLine +
                              "The application should be properly tested against Security vulnerabilities as described in the OWASP top ten" + Environment.NewLine +
                              "It is recommended by the Security Council to use ASV(Approved Scanning Vendors) scanning tools" + Environment.NewLine +
                              "Optional tools recommended here are : Wireshark,Nessus, OWASP ZAP, FindBugs, and using the IDE features to search on source code" + Environment.NewLine +
                              "The most difficult part of the test is to verify that the application is indeed storing, trasmitting or process Card Holder Data" + Environment.NewLine +
                              Environment.NewLine;

            System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead);
            //Programming language
            if (comboBox1.Text.ToString() == ".NET")
            {
                textL =
                    "Please check OWASP Code Review Guidelines to learn more about vulnerabilities in .NET applications" + Environment.NewLine +
                    "Old version Code Review Guide: https://www.owasp.org/images/2/2e/OWASP_Code_Review_Guide-V1_1.pdf" + Environment.NewLine +
                     "New version Beta: https://www.owasp.org/index.php/OWASP_Code_review_V2_Table_of_Contents";
                System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead +textL);

            }

            if (comboBox1.Text.ToString() == ".Java")
            {
                textL = "Please check OWASP Code Review Guidelines to learn more about vulnerabilities in Java applications" + Environment.NewLine +
                         "Old version Code Review Guide: https://www.owasp.org/images/2/2e/OWASP_Code_Review_Guide-V1_1.pdf" + Environment.NewLine +
                         "New version Beta: https://www.owasp.org/index.php/OWASP_Code_review_V2_Table_of_Contents"+ Environment.NewLine + Environment.NewLine ;
                System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + textL);

            }
            //First answer
            if (dataGridView1.Rows[0].Cells[3].Value != null)
            {
                if (dataGridView1.Rows[0].Cells[3].Value.Equals(true))
                {
                    text =
                                    "The Web Application does not fall directly into the main PCI-DSS Scope because it does not trasmit, process or store card holder data" +Environment.NewLine + Environment.NewLine;
                    System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + textL + text);

                }
            }
            if (dataGridView1.Rows[0].Cells[2].Value != null)
            {
                if (dataGridView1.Rows[0].Cells[2].Value.Equals(true))
                {
                    text =
                                    text =
                                "The Web Application falls into the main PCI-DSS Scope" + Environment.NewLine +
                                "We strongly recommend to read the OWASP Application Security Verification Standard Project" + Environment.NewLine +
                                "https://www.owasp.org/index.php/Category:OWASP_Application_Security_Verification_Standard_Project" + Environment.NewLine +
                                "The following checks are obligatory in order to become PCI-DSS complaint" + Environment.NewLine +
                                "Requirement 3 is about Protection of Card Holder Data" + Environment.NewLine +
                                "3.1 Keep cardholder data storage to a  minimum by implementing data retention" + Environment.NewLine +
                                "and disposal policies, procedures and processes that include at least the following :" + Environment.NewLine +
                                 "-For all cardholder data (CHD) storage: Limiting data storage amount and  retention time to that which is " + Environment.NewLine +
                                 "required for legal, regulatory, and business requirements " + Environment.NewLine +
                                 "-Processes for secure deletion of data when no longer needed" + Environment.NewLine +
                                 "-Specific retention requirements for cardholder data " + Environment.NewLine +
                                 "-A quarterly process for identifying and securely deleting stored cardholder data that exceeds defined retention." +
                                 "3.2 Do not store sensitive authentication data after authorization (even if encrypted). If sensitive authentication" + Environment.NewLine +
                                 "data is received, render all data unrecoverable upon completion of the authorization process." + Environment.NewLine +

                                 Environment.NewLine;
                    System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + textL + text);

                }
            }
            //2nd
            if (dataGridView1.Rows[1].Cells[2].Value != null)
            {
                if (dataGridView1.Rows[1].Cells[2].Value.Equals(true))
                {

                    text1 = "Authentication" + Environment.NewLine +
                       "HTTP authentication should be implemented over SSL/TLS if the application has sensitive information" + Environment.NewLine +
                       "Please check your application is using SSL (HTTPS) process to verify that HTTPS protocol has been implemented" + Environment.NewLine +
                       "Read the following guidelines regarding secure authentication:" + Environment.NewLine +
                        "https://www.owasp.org/index.php/Authentication_Cheat_Sheet" + Environment.NewLine +
                        "https://www.owasp.org/index.php/Session_Management_Cheat_Sheet" + Environment.NewLine + Environment.NewLine;
                    System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + textL + text + text1);

                }
            }
            if (dataGridView1.Rows[1].Cells[3].Value != null)
            {
                if (dataGridView1.Rows[1].Cells[3].Value.Equals(true))
                {

                    text1 = "Authentication" + Environment.NewLine +
                       "HTTP authentication MUST be implemented over TLS. Right now you are NOT compliant with requirement 4 " + Environment.NewLine +
                       "Requirement 4: Encrypt transmission of cardholder data across open, public networks" + Environment.NewLine +
                       "Please check your application is using SSL (HTTPS) process to verify that HTTPS protocol has been implemented" + Environment.NewLine +
                       "Read the following guidelines regarding secure authentication:" + Environment.NewLine +
                        "https://www.owasp.org/index.php/Authentication_Cheat_Sheet" + Environment.NewLine +
                        "https://www.pcisecuritystandards.org/documents/PCI_DSS_v3.pdf" + Environment.NewLine +
                        "https://www.owasp.org/index.php/Session_Management_Cheat_Sheet" + Environment.NewLine + Environment.NewLine;
                    System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + textL + text + text1);

                }
            }

            //3rd
            if (dataGridView1.Rows[2].Cells[2].Value != null)
            {
                if (dataGridView1.Rows[2].Cells[2].Value.Equals(true))
                {


                    text2 = "Credit Card numbers, PAN's must be masked if displayed to web users for example : XXXX-XXXX-XXXX-3440" + Environment.NewLine +
                            "Only the last 4 digits can be displayed back to the user" + Environment.NewLine + Environment.NewLine;
                    System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + textL + text + text1 + text2);

                }
            }

            //4rd
            if (dataGridView1.Rows[3].Cells[2].Value != null)
            {
                if (dataGridView1.Rows[3].Cells[2].Value.Equals(true))
                {

                    text3 =
                                 "According to PCI-DSS 3.2.1 Do not store the full contents of any track (from the magnetic stripe" + Environment.NewLine +
                                  "located on the back of a card, equivalent data contained on a chip, or elsewhere). This data is alternatively " + Environment.NewLine +
                                  "called full track, track, track 1, track 2, and magnetic-stripe data" + Environment.NewLine +
                                  "The purpose of the card validation code(CVV) is to protect card-not-present transactions—Internet" + Environment.NewLine +
                                   "or mail order/telephone order (MO/TO) transactions—where the consumer and the card are not present. " + Environment.NewLine +
                                   "3.4 Render PAN unreadable anywhere it is stored (including on portable digital media, backup media, and in logs) by" + Environment.NewLine +
                                   "using any of the following approaches:" + Environment.NewLine +
                                   "-One-way hashes based on strong cryptography, (hash must be of the entire PAN)" + Environment.NewLine +
                                   "-Truncation (hashing cannot be used to replace the truncated segment of PAN)" + Environment.NewLine +
                                   "-Index tokens and pads (pads must be securely stored)" + Environment.NewLine +
                                   "-Strong cryptography with associated key-management processes and procedures." + Environment.NewLine +
                                   "If your organization must store Card Holder data, it must be encrypted using strong cryptography, Truncation, Index tokens and securely stored pads" + Environment.NewLine +
                                   "Please refer to the following document for more info: https://www.pcisecuritystandards.org/pdfs/pci_fs_data_storage.pdf" + Environment.NewLine +
                                   "https://www.owasp.org/index.php/Cryptographic_Storage_Cheat_Sheet" + Environment.NewLine +
                                   "https://www.owasp.org/index.php/Top_10_2010-A7-Insecure_Cryptographic_Storage" + Environment.NewLine +
                                   "If this data is stolen, malicious individuals can execute fraudulent Internet and MO/TO transactions.+" + Environment.NewLine + Environment.NewLine;

                    System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + textL + text + text1 + text2 + text3);

                }
            }

            //5
            if (dataGridView1.Rows[4].Cells[2].Value != null)
            {
                if (dataGridView1.Rows[4].Cells[2].Value.Equals(true))
                {

                    text4 = "Only certain Card Holder Data can be stored, please check requirement 3.2. Only if you must stored it also must be" + Environment.NewLine +
                               "stored using strong Cryptography" + Environment.NewLine +
                                  "Please refer to the following document for more info: https://www.pcisecuritystandards.org/pdfs/pci_fs_data_storage.pdf" + Environment.NewLine +
                                  "https://www.owasp.org/index.php/Cryptographic_Storage_Cheat_Sheet" + Environment.NewLine +
                                  "https://www.owasp.org/index.php/Top_10_2010-A7-Insecure_Cryptographic_Storage" + Environment.NewLine;
                    System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + textL + text + text1 + text2 + text3 + text4);

                }
            }
            //6
            if (dataGridView1.Rows[5].Cells[2].Value != null)
            {
                if (dataGridView1.Rows[5].Cells[2].Value.Equals(true))
                {

                    text5 = "Transmition of CHD " + Environment.NewLine +
                                 "HTTP authentication should be implemented over TLS and any information that contains CHD" + Environment.NewLine +
                                 "Please check your deployment process to verify that HTTPS protocol has been implemented properly" + Environment.NewLine +
                                 "https://owasp.org/index.php/Transport_Layer_Protection_Cheat_Sheet" + Environment.NewLine
                                 + Environment.NewLine + Environment.NewLine;
                    System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + textL + text + text1 + text2 + text3 + text4 + text5);

                }
            }

            //7
            if (dataGridView1.Rows[6].Cells[2].Value != null)
            {
                if (dataGridView1.Rows[6].Cells[2].Value.Equals(true))
                {

                    text4 = "Transmission in clear text means the application is not compliant with requiremet 4. To  Verify that the application is not transmitting any of this data" + Environment.NewLine +
                               "test this using WireShark" + Environment.NewLine +
                                  "Please refer to the following document for more info: https://www.pcisecuritystandards.org/pdfs/pci_fs_data_storage.pdf" + Environment.NewLine +
                                  "https://www.owasp.org/index.php/Cryptographic_Storage_Cheat_Sheet" + Environment.NewLine +
                                  "https://www.owasp.org/index.php/Top_10_2010-A7-Insecure_Cryptographic_Storage" + Environment.NewLine;
                    System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + textL + text + text1 + text2 + text3 + text4 + text5 + text6);

                }
            }
        }

        private void OutPutCHDAnalysisDeveloper()
        {


            texthead = "Application Name:" + textBox1.Text.ToString() + Environment.NewLine +
                       "Programming Language:" + comboBox1.Text.ToString() + Environment.NewLine + Environment.NewLine +
                       "Developer Environment and Process - requirements regarding PCI-DSS" + Environment.NewLine +
                              Environment.NewLine+ Environment.NewLine ;

            System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", texthead);
            //Programming language
            if (comboBox1.Text.ToString() == ".NET")
            {
                textL =
                    "Please check OWASP Code Review Guidelines to learn more about vulnerabilities in .NET applications" + Environment.NewLine +
                    "Old version Code Review Guide: https://www.owasp.org/images/2/2e/OWASP_Code_Review_Guide-V1_1.pdf" + Environment.NewLine +
                     "New version Beta: https://www.owasp.org/index.php/OWASP_Code_review_V2_Table_of_Contents" +Environment.NewLine+ Environment.NewLine;
                System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", textL + texthead);

            }

            if (comboBox1.Text.ToString() == ".Java")
            {
                textL = "Please check OWASP Code Review Guidelines to learn more about vulnerabilities in Java applications" + Environment.NewLine +
                         "Old version Code Review Guide: https://www.owasp.org/images/2/2e/OWASP_Code_Review_Guide-V1_1.pdf" + Environment.NewLine +
                         "New version Beta: https://www.owasp.org/index.php/OWASP_Code_review_V2_Table_of_Contents" + Environment.NewLine + Environment.NewLine;
                System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", textL + texthead);

            }
            //First answer
            if (dataGridView2.Rows[0].Cells[2].Value != null )
            {
                if (dataGridView2.Rows[0].Cells[2].Value.Equals(true))
                {
                    text =
                 "To comply with Requirement 6: Develop and maintain secure systems it is essential to have policies and procedures to identify security vulnerabilities" + Environment.NewLine +
                 "6.1 Establish a process to identify security vulnerabilities, using reputable outside sources for security vulnerability information," + Environment.NewLine +
                 "and assign a risk ranking (for example, as “high,” “medium,” or “low”) to newly discovered security vulnerabilities. " + Environment.NewLine + Environment.NewLine + Environment.NewLine;

                    System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", textL + texthead + text);

                }
            }
            if (dataGridView2.Rows[0].Cells[3].Value != null)
            {
                if (dataGridView2.Rows[0].Cells[3].Value.Equals(true))
                {
                    text =
                        "The application does not comply with requirement 6.1" + Environment.NewLine +
                 "To comply with Requirement 6: Develop and maintain secure systems it is essential to have policies and procedures to identify security vulnerabilities" + Environment.NewLine +
                 "6.1 Establish a process to identify security vulnerabilities, using reputable outside sources for security vulnerability information," + Environment.NewLine +
                 "and assign a risk ranking (for example, as “high,” “medium,” or “low”) to newly discovered security vulnerabilities. " + Environment.NewLine + Environment.NewLine + Environment.NewLine;

                    System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", textL + texthead + text);

                }
            }

            //2nd
            if (dataGridView2.Rows[1].Cells[2].Value != null)
            {
                if (dataGridView2.Rows[1].Cells[2].Value.Equals(true))
                {
                    text = "The application Development process is  in compliance with Requirement 6.2 :" + Environment.NewLine +
                        "6.2 Ensure that all system components and software are protected from known vulnerabilities by installing applicable " + Environment.NewLine +
                        "vendor-supplied security patches. Install critical security patches within one month of release" + Environment.NewLine +
                        "It is essential to have a process that regular monitors the latest security issues in network components such as http://cwe.mitre.org/" + Environment.NewLine + Environment.NewLine;

                    System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", textL + texthead + text + text1);

                }
            }
             if (dataGridView2.Rows[1].Cells[3].Value != null)
             {
                if (dataGridView2.Rows[1].Cells[3].Value.Equals(true))
                {

                    text = "The application Development process is NOT in compliance with Requirement 6.2 :" + Environment.NewLine +
                                     "6.2 Ensure that all system components and software are protected from known vulnerabilities by installing applicable " + Environment.NewLine +
                        "vendor-supplied security patches. Install critical security patches within one month of release" + Environment.NewLine +
                        "It is essential to have a process that regular monitors the latest security issues in network components such as http://cwe.mitre.org/" + Environment.NewLine + Environment.NewLine;


                    System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", textL + texthead + text + text1);

                }
            }

            //3rd

            if (dataGridView2.Rows[2].Cells[2].Value != null)
            {
                if (dataGridView2.Rows[2].Cells[2].Value.Equals(true))
                {


                    text2 = "The application is in compliance with requirement 6.3" + Environment.NewLine +
                        "6.3 Develop internal and external software applications (including web-based administrative access to applications) securely, as follows:" + Environment.NewLine +
                        "-In accordance with PCI DSS (for example, secure authentication and logging)" + Environment.NewLine +
                        "-Based on industry standards and/or best practices." + Environment.NewLine +
                        "-Incorporating information security throughout the software-development life cycle" + Environment.NewLine +
                        "Some important OWASP guidelines to follow during Application Development:" + Environment.NewLine +
                        "https://www.owasp.org/index.php/Category:OWASP_Guide_Project" + Environment.NewLine +
                        "https://www.owasp.org/index.php/Category:OWASP_Application_Security_Verification_Standard_Project" + Environment.NewLine +
                        "https://www.owasp.org/index.php/Category:Software_Assurance_Maturity_Model" + Environment.NewLine +
                        "https://www.owasp.org/index.php/OWASP_Cornucopia" + Environment.NewLine +
                        "https://www.owasp.org/index.php/Category:OWASP_Code_Review_Project" + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                    System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", textL + texthead + text + text1 + text2);

                }
            }
            if (dataGridView2.Rows[2].Cells[3].Value != null)
            {

                if (dataGridView2.Rows[2].Cells[3].Value.Equals(true))
                {


                    text2 = "The application is NOT in compliance with requirement 6.3" + Environment.NewLine +
                        "6.3 Develop internal and external software applications (including web-based administrative access to applications) securely, as follows:" + Environment.NewLine +
                        "-In accordance with PCI DSS (for example, secure authentication and logging)" + Environment.NewLine +
                        "-Based on industry standards and/or best practices." + Environment.NewLine +
                        "-Incorporating information security throughout the software-development life cycle" + Environment.NewLine +
                        "Some important OWASP guidelines to follow during Application Development:" + Environment.NewLine +
                        "https://www.owasp.org/index.php/Category:OWASP_Guide_Project" + Environment.NewLine +
                        "https://www.owasp.org/index.php/Category:OWASP_Application_Security_Verification_Standard_Project" + Environment.NewLine +
                        "https://www.owasp.org/index.php/Category:Software_Assurance_Maturity_Model" + Environment.NewLine +
                        "https://www.owasp.org/index.php/OWASP_Cornucopia" + Environment.NewLine +
                        "https://www.owasp.org/index.php/Category:OWASP_Code_Review_Project" + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                    ;
                    System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", textL + texthead + text + text1 + text2);

                }
            }

            //4rd
            if (dataGridView2.Rows[3].Cells[2].Value != null)
            {
                if (dataGridView2.Rows[3].Cells[2].Value.Equals(true))
                {

                    text3 =
                                 "The application is in compliance with 6.3.c -Knowing and understanding the vulnerabilities in the OWASP TOP 10 is an important and essential first step into understanding security vulnerabilities" + Environment.NewLine + Environment.NewLine;

                    System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", textL + texthead + text + text1 + text2 + text3);

                }
            }
            if (dataGridView2.Rows[3].Cells[3].Value != null)
            {
                if (dataGridView2.Rows[3].Cells[3].Value.Equals(true))
                {

                    text3 =
                                 "Knowing and understanding the vulnerabilities in the OWASP TOP 10 is an important and essential first step into understanding security vulnerabilities" +Environment.NewLine+
                                 "Please visit OWASP.org to understand more about Security vulnerabilities"+Environment.NewLine+
                                 "Read more about Application security: https://www.owasp.org/index.php/Category:OWASP_Application_Security_Verification_Standard_Project" +Environment.NewLine+
                                  Environment.NewLine + Environment.NewLine;

                    System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", textL + texthead + text + text1 + text2 + text3);

                }
            }

            //5
            if (dataGridView2.Rows[4].Cells[2].Value != null)
            {
                if (dataGridView2.Rows[4].Cells[2].Value.Equals(true))
                {

                    text4 = "The applicaion is in compliance with requirememnt 6.3.2 "+ Environment.NewLine+
                        "6.3.2 Review custom code prior to release to production or customers in order to identify any potential coding vulnerability (using either manual or automated processes)" + Environment.NewLine+
                        "to include at least the following:"+ Environment.NewLine+
                        "- Code changes are reviewed by individuals other than the originating code author, and by individuals knowledgeable about code-review techniques and secure coding practices."+ Environment.NewLine+
                        "- Code reviews ensure code is developed according to secure coding guidelines"+ Environment.NewLine+
                        "- Appropriate corrections are implemented prior to release."+ Environment.NewLine+
                        "Code-review results are reviewed and approved by management prior to release."+Environment.NewLine+
                        "Check the OWASP Code Review guidelines: https://www.owasp.org/index.php/Category:OWASP_Code_Review_Project"
                        + Environment.NewLine+Environment.NewLine;

                    System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", textL + texthead + text + text1 + text2 + text3 + text4);

                }
            }

            if (dataGridView2.Rows[4].Cells[3].Value != null)
            {
                if (dataGridView2.Rows[4].Cells[3].Value.Equals(true))
                {

                    text5 = "The application is NOT in compliance with requirememnt 6.3.2 " + Environment.NewLine +
                        "6.3.2 Review custom code prior to release to production or customers in order to identify any potential coding vulnerability (using either manual or automated processes)" + Environment.NewLine +
                        "to include at least the following:" + Environment.NewLine +
                        "- Code changes are reviewed by individuals other than the originating code author, and by individuals knowledgeable about code-review techniques and secure coding practices." + Environment.NewLine +
                        "- Code reviews ensure code is developed according to secure coding guidelines" + Environment.NewLine +
                        "- Appropriate corrections are implemented prior to release." + Environment.NewLine +
                        "Code-review results are reviewed and approved by management prior to release." + Environment.NewLine +
                         "Check the OWASP Code Review guidelines: https://www.owasp.org/index.php/Category:OWASP_Code_Review_Project"
                        + Environment.NewLine + Environment.NewLine; ;
                    System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", textL + texthead + text + text1 + text2 + text3 + text4);

                }
            }
            //6
            if (dataGridView2.Rows[5].Cells[2].Value != null)
            {
                if (dataGridView2.Rows[5].Cells[2].Value.Equals(true))
                {

                    text5 = "Application is in compliance with 6.4.3 , Production data (live PANs) are not used for testing or development"
                        + Environment.NewLine + Environment.NewLine; ;
                    System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", textL + texthead + text + text1 + text2 + text3 + text4 + text5);

                }
            }

            if (dataGridView2.Rows[5].Cells[3].Value != null)
            {
                if (dataGridView2.Rows[5].Cells[3].Value.Equals(true))
                {

                    text5 = "Application is NOT compliance with 6.4.3 , Production data (live PANs) are not used for testing or development"
                        + Environment.NewLine + Environment.NewLine; ;
                    System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", textL + texthead + text + text1 + text2 + text3 + text4 + text5);

                }
            }

            //7
            if (dataGridView2.Rows[6].Cells[2].Value != null)
            {
                if (dataGridView2.Rows[6].Cells[2].Value.Equals(true))
                {

                    text4 = "Application is in compliance with requirement 6.4.4 : Removal of test data and accounts before production systems become active" + Environment.NewLine;
                    System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", textL + texthead + text + text1 + text2 + text3 + text4 + text5 + text6);

                }
            }
            if (dataGridView2.Rows[6].Cells[3].Value != null)
            {
                if (dataGridView2.Rows[6].Cells[3].Value.Equals(true))
                {

                    text4 = "Application is NOT in compliance with requirement 6.4.4 : Removal of test data and accounts before production systems become active" + Environment.NewLine;
                    System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", textL + texthead + text + text1 + text2 + text3 + text4 + text5 + text6);

                }
            }
        }

        private void OutPutCHDAnalysisTester()
        {


            texthead = "Application Name:" + textBox1.Text.ToString() + Environment.NewLine +
                              "Programming Language:" + comboBox1.Text.ToString() + Environment.NewLine + Environment.NewLine +
                              "Developer Environment and Process - requirements regarding PCI-DSS" + Environment.NewLine +                           
                              Environment.NewLine;

            System.IO.File.WriteAllText(@"PCI-DSS_analysis_Developer.txt", texthead);
            //Programming language
            if (comboBox1.Text.ToString() == ".NET")
            {
                textL =
                    "Please check OWASP Code Review Guidelines to learn more about vulnerabilities in .NET applications" + Environment.NewLine +
                    "Old version Code Review Guide: https://www.owasp.org/images/2/2e/OWASP_Code_Review_Guide-V1_1.pdf" + Environment.NewLine +
                     "New version Beta: https://www.owasp.org/index.php/OWASP_Code_review_V2_Table_of_Contents";
                System.IO.File.WriteAllText(@"PCI-DSS_analysis_Tester.txt", textL + texthead);

            }

            if (comboBox1.Text.ToString() == ".Java")
            {
                textL = "Please check OWASP Code Review Guidelines to learn more about vulnerabilities in Java applications" + Environment.NewLine +
                         "Old version Code Review Guide: https://www.owasp.org/images/2/2e/OWASP_Code_Review_Guide-V1_1.pdf" + Environment.NewLine +
                         "New version Beta: https://www.owasp.org/index.php/OWASP_Code_review_V2_Table_of_Contents";
                System.IO.File.WriteAllText(@"PCI-DSS_analysis_Tester.txt", textL + texthead);

            }
            //First answer
            if (dataGridView1.Rows[0].Cells[2].Value.Equals(true) || dataGridView1.Rows[0].Cells[2].Value.Equals(false))
            {
                text =
             "To comply with Requirement 6: Develop and maintain secure systems and applications Production Environment must be separated" + Environment.NewLine +
             "from the testing environment" + Environment.NewLine +
              "6.4.1 Separate development/test environments from production environments, and enforce the separation with access controls."
                + Environment.NewLine + Environment.NewLine +
                "Development/test environments are separate from production environments with access control in place to enforce separation." + Environment.NewLine;

                System.IO.File.WriteAllText(@"PCI-DSS_analysis_Tester.txt", textL + texthead + text);

            }
            
            //2nd
            if (dataGridView1.Rows[1].Cells[2].Value.Equals(true))
            {
                                text ="The application Development process is  in compliance with Requirement 6.4 :"+Environment.NewLine+
                                    "-A separation of duties between personnel assigned to the development/test environments and those assigned to the production environment is a must to comply."+ Environment.NewLine+
                                      "Please read how OpenSamm can help you understand and implement a Software Assurance Maturity Model"+Environment.NewLine+
                                    "http://www.opensamm.org/";

                                System.IO.File.WriteAllText(@"PCI-DSS_analysis_Tester.txt", textL + texthead + text + text1);

            }
            if (dataGridView1.Rows[1].Cells[2].Value.Equals(false))
            {

                   text ="The application Development process is NOT in compliance with Requirement 6.4 :"+Environment.NewLine+
                                    "-A separation of duties between personnel assigned to the development/test environments and those assigned to the production environment is a must to comply."+ Environment.NewLine +
                                    "Please read how OpenSamm can help you understand and implement a Software Assurance Maturity Model"+Environment.NewLine+
                                    "http://www.opensamm.org/";


                   System.IO.File.WriteAllText(@"PCI-DSS_analysis_Tester.txt", textL + texthead + text + text1);

            }

            //3rd

            if (dataGridView1.Rows[2].Cells[2].Value.Equals(true))
            {


                text2 = "Credit Card numbers, PAN's must be masked if displayed to web users for example : XXXX-XXXX-XXXX-3440" + Environment.NewLine +
                        "Only the last 4 digits can be displayed back to the user" + Environment.NewLine + Environment.NewLine;
                System.IO.File.WriteAllText(@"PCI-DSS_analysis_Tester.txt", textL + texthead + text + text1 + text2);

            }

            //4rd
            if (dataGridView1.Rows[3].Cells[2].Value.Equals(true))
            {

                text3 =
                             "According to PCI-DSS 3.2.1 Do not store the full contents of any track (from the magnetic stripe" + Environment.NewLine +
                              "located on the back of a card, equivalent data contained on a chip, or elsewhere). This data is alternatively " + Environment.NewLine +
                              "called full track, track, track 1, track 2, and magnetic-stripe data" + Environment.NewLine +
                              "The purpose of the card validation code(CVV) is to protect card-not-present transactions—Internet" + Environment.NewLine +
                               "or mail order/telephone order (MO/TO) transactions—where the consumer and the card are not present. " + Environment.NewLine +
                               "3.4 Render PAN unreadable anywhere it is stored (including on portable digital media, backup media, and in logs) by" + Environment.NewLine +
                               "using any of the following approaches:" + Environment.NewLine +
                               "-One-way hashes based on strong cryptography, (hash must be of the entire PAN)" + Environment.NewLine +
                               "-Truncation (hashing cannot be used to replace the truncated segment of PAN)" + Environment.NewLine +
                               "-Index tokens and pads (pads must be securely stored)" + Environment.NewLine +
                               "-Strong cryptography with associated key-management processes and procedures." + Environment.NewLine +
                               "If your organization must store Card Holder data, it must be encrypted using strong cryptography, Truncation, Index tokens and securely stored pads" + Environment.NewLine +
                               "Please refer to the following document for more info: https://www.pcisecuritystandards.org/pdfs/pci_fs_data_storage.pdf" + Environment.NewLine +
                               "https://www.owasp.org/index.php/Cryptographic_Storage_Cheat_Sheet" + Environment.NewLine +
                               "https://www.owasp.org/index.php/Top_10_2010-A7-Insecure_Cryptographic_Storage" + Environment.NewLine +
                               "If this data is stolen, malicious individuals can execute fraudulent Internet and MO/TO transactions.+" + Environment.NewLine + Environment.NewLine;

                System.IO.File.WriteAllText(@"PCI-DSS_analysis_Tester.txt", textL + texthead + text + text1 + text2 + text3);

            }

            //5
            if (dataGridView1.Rows[4].Cells[2].Value.Equals(true))
            {

                text4 = "Only certain Card Holder Data can be stored, please check requirement 3.2. Only if you must stored it also must be" + Environment.NewLine +
                           "stored using strong Cryptography" + Environment.NewLine +
                              "Please refer to the following document for more info: https://www.pcisecuritystandards.org/pdfs/pci_fs_data_storage.pdf" + Environment.NewLine +
                              "https://www.owasp.org/index.php/Cryptographic_Storage_Cheat_Sheet" + Environment.NewLine +
                              "https://www.owasp.org/index.php/Top_10_2010-A7-Insecure_Cryptographic_Storage" + Environment.NewLine;
                System.IO.File.WriteAllText(@"PCI-DSS_analysis_Tester.txt", textL + texthead + text + text1 + text2 + text3 + text4);

            }
            //6
            if (dataGridView1.Rows[5].Cells[2].Value.Equals(true))
            {

                text5 = "Transmition of CHD " + Environment.NewLine +
                             "HTTP authentication should be implemented over TLS and any information that contains CHD" + Environment.NewLine +
                             "Please check your deployment process to verify that HTTPS protocol has been implemented properly" + Environment.NewLine +
                             "https://owasp.org/index.php/Transport_Layer_Protection_Cheat_Sheet" + Environment.NewLine
                             + Environment.NewLine + Environment.NewLine;
                System.IO.File.WriteAllText(@"PCI-DSS_analysis_Tester.txt", textL + texthead + text + text1 + text2 + text3 + text4 + text5);

            }

            //7
            if (dataGridView1.Rows[6].Cells[2].Value.Equals(true))
            {

                text4 = "Transmission in clear text means the application is not compliant with requiremet 4. To  Verify that the application is not transmitting any of this data" + Environment.NewLine +
                           "test this using WireShark" + Environment.NewLine +
                              "Please refer to the following document for more info: https://www.pcisecuritystandards.org/pdfs/pci_fs_data_storage.pdf" + Environment.NewLine +
                              "https://www.owasp.org/index.php/Cryptographic_Storage_Cheat_Sheet" + Environment.NewLine +
                              "https://www.owasp.org/index.php/Top_10_2010-A7-Insecure_Cryptographic_Storage" + Environment.NewLine;
                System.IO.File.WriteAllText(@"PCI-DSS_analysis_Tester.txt", textL + texthead + text + text1 + text2 + text3 + text4 + text5 + text6);

            }
        }

        #endregion

        #region Validation
        private bool ValidateCheckBox()
        {
            //logic
            //bool selectedYES = false;
            //bool selectedNo = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool cheked = ((bool)(row.Cells["chk"].EditedFormattedValue));
                bool chekedNo = ((bool)(row.Cells["chkNo"].EditedFormattedValue));
                if (cheked && chekedNo)
                {
                    MessageBox.Show("You cannot select YES and NO in the same row, please check one only");
                    return false;

                }
                if (chekedNo)
                {
                    return true;
                }

                if (cheked)
                {
                    return true;
                }

            }

            MessageBox.Show("Please select at least one record !!");
            return false;
        }

        private bool ValidateCheckBox2()
        {
            //logic
            //bool selectedYES = false;
            //bool selectedNo = false;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                bool cheked = ((bool)(row.Cells["chkDev"].EditedFormattedValue));
                bool chekedNo = ((bool)(row.Cells["chkDevNo"].EditedFormattedValue));
                if (cheked && chekedNo)
                {
                    MessageBox.Show("You cannot select YES and NO in the same row, please check one only");
                    return false;

                }
                if (chekedNo)
                {
                    return true;
                }

                if (cheked)
                {
                    return true;
                }

            }

            MessageBox.Show("Please select at least one record !!");
            return false;
        }

        private bool ValidateCheckBox3()
        {
            //logic
            //bool selectedYES = false;
            //bool selectedNo = false;
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                bool cheked = ((bool)(row.Cells["chk"].EditedFormattedValue));
                bool chekedNo = ((bool)(row.Cells["chkNo"].EditedFormattedValue));
                if (cheked && chekedNo)
                {
                    MessageBox.Show("You cannot select YES and NO in the same row, please check one only");
                    return false;

                }
                if (chekedNo)
                {
                    return true;
                }

                if (cheked)
                {
                    return true;
                }

            }

            MessageBox.Show("Please select at least one record !!");
            return false;
        }

        private bool ValidateAppName()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please fill in the application name");
                return true;

            }
            return false;

        }
        #endregion

        #region Print reports

        private void CreatePDFReport()
        {



        }
        private static void PrintPDFReport()
        {
            //doc printing PDF
            #region print
            DateTime now = DateTime.Now;
            string filename = "MixMigraDocAndPdfSharp.pdf";
            filename = Guid.NewGuid().ToString("D").ToUpper() + ".pdf";
            PdfDocument document = new PdfDocument();
            document.Info.Title = "PDFsharp XGraphic Sample";
            document.Info.Author = "Stefan Lange";
            document.Info.Subject = "Created with code snippets that show the use of graphical functions";
            document.Info.Keywords = "PDFsharp, XGraphics";

            SamplePage1(document);

            //SamplePage2(document);

            Debug.WriteLine("seconds=" + (DateTime.Now - now).TotalSeconds.ToString());

            // Save the document...
            document.Save(filename);
            // ...and start a viewer
            Process.Start(filename);
            #endregion
        }
        static void SamplePage1(PdfDocument document)
        {
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            // HACK²
            gfx.MUH = PdfFontEncoding.Unicode;
            gfx.MFEH = PdfFontEmbedding.Default;

            XFont font = new XFont("Verdana", 13, XFontStyle.Bold);

            gfx.DrawString("The following paragraph was rendered using MigraDoc:", font, XBrushes.Black,
              new XRect(100, 100, page.Width - 200, 300), XStringFormats.Center);

            // You always need a MigraDoc document for rendering.
            Document doc = new Document();
            Section sec = doc.AddSection();
            // Add a single paragraph with some text and format information.
            Paragraph para = sec.AddParagraph();
            para.Format.Alignment = ParagraphAlignment.Justify;
            para.Format.Font.Name = "Times New Roman";
            para.Format.Font.Size = 12;
            para.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.DarkGray;
            para.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.DarkGray;
            para.AddText("Duisism odigna acipsum delesenisl ");
            para.AddFormattedText("ullum in velenit", TextFormat.Bold);
            para.AddText(" ipit iurero dolum zzriliquisis nit wis dolore vel et nonsequipit, velendigna " +
              "auguercilit lor se dipisl duismod tatem zzrit at laore magna feummod oloborting ea con vel " +
              "essit augiati onsequat luptat nos diatum vel ullum illummy nonsent nit ipis et nonsequis " +
              "niation utpat. Odolobor augait et non etueril landre min ut ulla feugiam commodo lortie ex " +
              "essent augait el ing eumsan hendre feugait prat augiatem amconul laoreet. ≤≥≈≠");
            para.Format.Borders.Distance = "5pt";
            para.Format.Borders.Color = Colors.Gold;

            // Create a renderer and prepare (=layout) the document
            MigraDoc.Rendering.DocumentRenderer docRenderer = new DocumentRenderer(doc);
            docRenderer.PrepareDocument();

            // Render the paragraph. You can render tables or shapes the same way.
            docRenderer.RenderObject(gfx, XUnit.FromCentimeter(5), XUnit.FromCentimeter(10), "12cm", para);
        }
        #endregion

        #region Help Methods

        static DataTable ConvertListToDataTable(List<string[]> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }
        #endregion

    }
}
