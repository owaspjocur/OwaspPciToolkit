using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OwaspPciToolkit
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DisplayGrid();
            DisplayGridDev();
            DisplayGridTest();
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void DisplayGrid()
        {
            #region Style
            dataGridView1.AllowUserToAddRows = false;   
            this.dataGridView1.DefaultCellStyle.WrapMode =DataGridViewTriState.True;
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Question";
            dataGridView1.Columns[0].Width = 600;
            dataGridView1.Columns[1].Width = 350;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns[1].Name = "Tips";
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.PapayaWhip;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
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
            row = new string[] { "Does the application have any form of debug log system?", "Do a search on the Web server on the folders containing the logs" };
            dataGridView1.Rows.Add(row);
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chk);
            chk.HeaderText = "YES";
            chk.Name = "chk";
            DataGridViewCheckBoxColumn chkNo = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chkNo);
            chkNo.HeaderText = "NO";
            chkNo.Name = "chkNo";
            #endregion
            //dataGridView1.Rows[2].Cells[3].Value = true;
        }

        private void DisplayGridDev()
        {
            DevelopQuestions listQ = new DevelopQuestions();
            List<string[]> QuestionsC = listQ.developQuestions().ToList();
            DataTable table = ConvertListToDataTable(QuestionsC);
            BSDev.DataSource = table;
            dataGridView2.DataSource = BSDev;
            dataGridView2.AutoResizeColumns();

            dataGridView2.Columns[0].HeaderText = "Questions Development";

            // Configure the details DataGridView so that its columns automatically 
            // adjust their widths when the data changes.
            dataGridView2.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.Columns.Add(CreateCheckBox());
            dataGridView2.Columns.Add(CreateHyperLink());
            dataGridView2.AllowUserToAddRows = false;



        }

        private void DisplayGridTest()
        {
            testQuestions listQ = new testQuestions();
            List<string[]> QuestionsC = listQ.testerQuestions().ToList();
            DataTable table = ConvertListToDataTable(QuestionsC);
            BSTest.DataSource= table;
            dataGridView3.DataSource = BSTest;
            dataGridView3.AutoResizeColumns();

            dataGridView3.Columns[0].HeaderText = "Test Development";

            // Configure the details DataGridView so that its columns automatically 
            // adjust their widths when the data changes.
            dataGridView3.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView3.Columns.Add(CreateCheckBox());
            dataGridView3.AllowUserToAddRows = false;



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
        DataGridViewLinkColumn CreateHyperLink()
        {
            DataGridViewLinkColumn link = new DataGridViewLinkColumn();
            link.DataPropertyName = "External resource";
            link.Width = 100;
            link.Name = "External Resource";
            return link;
        
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
            string text = null;
            string text1 = null;
            string text2 = null;
            string text3 = null;
            string text4 = null;
            string text5 = null;
            string text6 = null;
            string text7 = null;

            string texthead = "Application Name:" + textBox1.Text.ToString() + Environment.NewLine +
                              "Programming Language:" + comboBox1.Text.ToString() + Environment.NewLine + Environment.NewLine +
                              "Card Holder Data - requirements regarding PCI-DSS" + Environment.NewLine +
                              "In order to verify the veracity of your answers regarding these questions, we strongly recommend the following steps:" + Environment.NewLine +
                              "The application should be properly tested against Security vulnerabilities as described in the OWASP top ten" + Environment.NewLine +
                              "It is recommended by the Security Council to use ASV(Approved Scanning Vendors) scanning tools" + Environment.NewLine +
                              "Optional tools recommended here are : Wireshark,Nessus, OWASP ZAP, FindBugs, and using the IDE features to search on source code" + Environment.NewLine +
                              "The most difficult part of the test is to verify that the application is indeed storing, trasmitting or process CHD"+ Environment.NewLine+
                              Environment.NewLine ;

           System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead);

            //First answer
           if (dataGridView1.Rows[0].Cells[2].Value.Equals(true))
           {
               text =
                               "The Web Application does not fall directly into the main PCI-DSS Scopeb because it does not trasmit, process or store card holder data" + Environment.NewLine;
               System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text);

           }
           if (dataGridView1.Rows[0].Cells[2].Value.Equals(true))
           {
               text =
                               text =
                           "The Web Application falls into the main PCI-DSS Scope" + Environment.NewLine +
                           "We strongly recommend to read the OWASP Top 10 guidelines" + Environment.NewLine +
                           "https://www.owasp.org/index.php/Category:OWASP_Top_Ten_Project#tab=OWASP_Top_10_for_2013" + Environment.NewLine +
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

                            Environment.NewLine ;
               System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text);

           }
            //2nd
            if (dataGridView1.Rows[1].Cells[2].Value.Equals(true))
            {

                text1 = "Authentication" + Environment.NewLine +
                   "HTTP authentication should be implemented over TLS if the application has sensitive information" + Environment.NewLine +
                   "Please check your application is using SSL (HTTPS) process to verify that HTTPS protocol has been implemented" + Environment.NewLine +
                   "Read the following guidelines regarding secure authentication:" + Environment.NewLine +
                    "https://www.owasp.org/index.php/Authentication_Cheat_Sheet" + Environment.NewLine +
                    "https://www.owasp.org/index.php/Session_Management_Cheat_Sheet" + Environment.NewLine + Environment.NewLine;
                System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1);

            }
            if (dataGridView1.Rows[1].Cells[2].Value.Equals(true))
            {

                text1 = "Authentication" + Environment.NewLine +
                   "HTTP authentication MUST be implemented over TLS. Right now you are NOT compliant with requirement 4 " + Environment.NewLine +
                   "Requirement 4: Encrypt transmission of cardholder data across open, public networks"+ Environment.NewLine +
                   "Please check your application is using SSL (HTTPS) process to verify that HTTPS protocol has been implemented" + Environment.NewLine +
                   "Read the following guidelines regarding secure authentication:" + Environment.NewLine +
                    "https://www.owasp.org/index.php/Authentication_Cheat_Sheet" + Environment.NewLine +
                    "https://www.pcisecuritystandards.org/documents/PCI_DSS_v3.pdf" + Environment.NewLine +
                    "https://www.owasp.org/index.php/Session_Management_Cheat_Sheet" + Environment.NewLine + Environment.NewLine;
                System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1);

            }

            //3rd

            if (dataGridView1.Rows[2].Cells[2].Value.Equals(true))
              {


                  text2 = "Credit Card numbers, PAN's must be masked if displayed to web users for example : XXXX-XXXX-XXXX-3440" + Environment.NewLine +
                          "Only the last 4 digits can be displayed back to the user" + Environment.NewLine + Environment.NewLine;
                  System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1 + text2);

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
                               "using any of the following approaches:"+ Environment.NewLine +
                               "-One-way hashes based on strong cryptography, (hash must be of the entire PAN)"+ Environment.NewLine +
                               "-Truncation (hashing cannot be used to replace the truncated segment of PAN)" + Environment.NewLine +
                               "-Index tokens and pads (pads must be securely stored)" + Environment.NewLine +
                               "-Strong cryptography with associated key-management processes and procedures." + Environment.NewLine +
                               "If your organization must store Card Holder data, it must be encrypted using strong cryptography, Truncation, Index tokens and securely stored pads" + Environment.NewLine +
                               "Please refer to the following document for more info: https://www.pcisecuritystandards.org/pdfs/pci_fs_data_storage.pdf" + Environment.NewLine +
                               "https://www.owasp.org/index.php/Cryptographic_Storage_Cheat_Sheet" + Environment.NewLine +
                               "https://www.owasp.org/index.php/Top_10_2010-A7-Insecure_Cryptographic_Storage" + Environment.NewLine +
                               "If this data is stolen, malicious individuals can execute fraudulent Internet and MO/TO transactions.+" + Environment.NewLine + Environment.NewLine;

                System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1 + text2 + text3);

            }

            //5
            if (dataGridView1.Rows[4].Cells[2].Value.Equals(true))
                 {

                     text4 = "Only certain Card Holder Data can be stored, please check requirement 3.2. Only if you must stored it also must be" + Environment.NewLine +
                                "stored using strong Cryptography" + Environment.NewLine +
                                   "Please refer to the following document for more info: https://www.pcisecuritystandards.org/pdfs/pci_fs_data_storage.pdf" + Environment.NewLine +
                                   "https://www.owasp.org/index.php/Cryptographic_Storage_Cheat_Sheet" + Environment.NewLine +
                                   "https://www.owasp.org/index.php/Top_10_2010-A7-Insecure_Cryptographic_Storage" + Environment.NewLine;
                     System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1 + text2 + text3 + text4);

                 }
            //6
            if (dataGridView1.Rows[5].Cells[2].Value.Equals(true))
            {

               text5 = "Transmition of CHD " + Environment.NewLine +
                            "HTTP authentication should be implemented over TLS and any information that contains CHD" + Environment.NewLine +
                            "Please check your deployment process to verify that HTTPS protocol has been implemented properly" + Environment.NewLine +
                            "https://owasp.org/index.php/Transport_Layer_Protection_Cheat_Sheet" + Environment.NewLine 
                            + Environment.NewLine + Environment.NewLine;
                        System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1);
                     System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1 + text2 + text3 + text4 +text5);

            }

            //7
            if (dataGridView1.Rows[6].Cells[2].Value.Equals(true))
            {

                text4 = "Transmission in clear text means the application is not compliant with requiremet 4. To  Verify that the application is not transmitting any of this data" + Environment.NewLine +
                           "test this using WireShark" + Environment.NewLine +
                              "Please refer to the following document for more info: https://www.pcisecuritystandards.org/pdfs/pci_fs_data_storage.pdf" + Environment.NewLine +
                              "https://www.owasp.org/index.php/Cryptographic_Storage_Cheat_Sheet" + Environment.NewLine +
                              "https://www.owasp.org/index.php/Top_10_2010-A7-Insecure_Cryptographic_Storage" + Environment.NewLine;
                System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1 + text2 + text3 + text4 +text5 + text6 );

            }

            //8
            if (dataGridView1.Rows[7].Cells[2].Value.Equals(true))
            {

                text4 = "IF the application saves information such as credit card in log files and this is no properly encrypted" + Environment.NewLine +
                           "The application will not comply with requirement 3 and 4" + Environment.NewLine +
                              "Please refer to the following document for more info: https://www.pcisecuritystandards.org/pdfs/pci_fs_data_storage.pdf" + Environment.NewLine +
                              "https://www.owasp.org/index.php/Cryptographic_Storage_Cheat_Sheet" + Environment.NewLine +
                              "https://www.owasp.org/index.php/Top_10_2010-A7-Insecure_Cryptographic_Storage" + Environment.NewLine;
                System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1 + text2 + text3 + text4 + text5 +text6 +text7);

            }

           #endregion

            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex= dataGridView1.CurrentCell.ColumnIndex; 

            dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString();


                dataGridView1.EndEdit();
                MessageBox.Show("Information has been processed-Open the report to find out analysis");
         
            }

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

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            // Set the window title text
            // ... to the MaskInputRejectedEventArgs information.
            this.Text = "Error: " +
            e.RejectionHint.ToString() +
            "; position: " +
            e.Position.ToString();
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

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                bool isChecked = (Boolean)dataGridView1[0, e.RowIndex].FormattedValue;

                if (isChecked)
                    dataGridView1[1, e.RowIndex].Value = true;
            }
        }

        

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
    }
}
