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
            //DisplayGridDev();
            //DisplayGridTest();
        }

        private void DisplayGrid()
        {
            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Question";
            dataGridView1.Columns[1].Name = "Tips";

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
           if( Validate().Equals(true))
           {
            return;
           }

            int TotalPoints = 0;
            string text = null;
            string text1 = null;
            string text2 = null;
            string text3 = null;
            string text4 = null;
            string text5 = null;

            string texthead = "Application Name:" + textBox1.Text.ToString() + Environment.NewLine +
                              "Programming Language:" + comboBox1.Text.ToString() + Environment.NewLine + Environment.NewLine +
                              "Card Holder Data - requirements regarding PCI-DSS" + Environment.NewLine +
                              "In order to verify the veracity of your answers regarding these questions, we strongly recommend the following steps:" + Environment.NewLine +
                              "The application should be properly tested against Security vulnerabilities as described in the OWASP top ten" + Environment.NewLine +
                              "It is recommended by the Security Council to use ASV(Approved Scanning Vendors) scanning tools" + Environment.NewLine +
                              "Optional tools recommended here are : Wireshark,Nessus, OWASP ZAP, FindBugs, and using the IDE features to search on source" + Environment.NewLine +
                              "The most difficult part of the test is to verify that the application is indeed storing, trasmitting or process CHD"+ Environment.NewLine+
                              Environment.NewLine ;

           System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead);

            //First answer
           if (dataGridView1.Rows[0].Cells[3].Value.Equals(false))
           { 
            text =
                            "The Web Application does not fall directly into the main PCI-DSS Scopeb because it does not trasmit, process or store card holder data" + Environment.NewLine;
                            System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text);
           
           }
           if (dataGridView1.Rows[0].Cells[3].Value.Equals(true))
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
            if (dataGridView1.Rows[1].Cells[3].Value.Equals(true))
            {

                text1 = "Authentication" + Environment.NewLine +
                   "HTTP authentication should be implemented over TLS if the application has sensitive information" + Environment.NewLine +
                   "Please check your application is using SSL (HTTPS) process to verify that HTTPS protocol has been implemented" + Environment.NewLine +
                   "Read the following guidelines regarding secure authentication:" + Environment.NewLine +
                    "https://www.owasp.org/index.php/Authentication_Cheat_Sheet" + Environment.NewLine +
                    "https://www.owasp.org/index.php/Session_Management_Cheat_Sheet" + Environment.NewLine + Environment.NewLine;
                System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1);

            }
            if (dataGridView1.Rows[1].Cells[3].Value.Equals(false) && dataGridView1.Rows[0].Cells[3].Value.Equals(true))
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


            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{                
            //        DataGridViewTextBoxCell chk = (DataGridViewTextBoxCell)row.Cells[0];

            //        if (chk.RowIndex.Equals(0) && chk.Value == null)
            //        {
            //             text =
            //                "The Web Application does not fall directly into the main PCI-DSS Scope" + Environment.NewLine ;
            //            System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text);
                                               
            //        }

            //        if (chk.RowIndex.Equals(0) && chk.Value.Equals(true))
            //        {
            //            text =
            //               "The Web Application falls into the main PCI-DSS Scope" + Environment.NewLine +
            //               "We strongly recommend to read the OWASP Top 10 guidelines"+Environment.NewLine +
            //               "https://www.owasp.org/index.php/Category:OWASP_Top_Ten_Project#tab=OWASP_Top_10_for_2013" + Environment.NewLine +
            //               "The following checks are obligatory in order to become PCI-DSS complaint" + Environment.NewLine +
            //               "Requirement 3 is about Protection of Card Holder Data" + Environment.NewLine +
            //               "3.1 Keep cardholder data storage to a  minimum by implementing data retention"+ Environment.NewLine +
            //               "and disposal policies, procedures and processes that include at least the following :" + Environment.NewLine +
            //                "-For all cardholder data (CHD) storage: Limiting data storage amount and  retention time to that which is "+ Environment.NewLine +
            //                "required for legal, regulatory, and business requirements "+ Environment.NewLine +
            //                "-Processes for secure deletion of data when no longer needed" + Environment.NewLine +
            //                "-Specific retention requirements for cardholder data "+ Environment.NewLine +
            //                "-A quarterly process for identifying and securely deleting stored cardholder data that exceeds defined retention."+
            //                Environment.NewLine + Environment.NewLine;
            //            System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text);

            //        }
                
            //        if (chk.RowIndex.Equals(1) && chk.Value == null)
            //        {

            //            text1 = "Authentication" + Environment.NewLine +
            //               "HTTP authentication should be implemented over TLS" + Environment.NewLine +
            //               "Please check your deployment process to verify that HTTPS protocol has been implemented" + Environment.NewLine +
            //               "Read the following guidelines regarding secure authentication:" + Environment.NewLine +
            //                "https://www.owasp.org/index.php/Authentication_Cheat_Sheet" + Environment.NewLine +
            //                "https://www.owasp.org/index.php/Session_Management_Cheat_Sheet" + Environment.NewLine + Environment.NewLine;
            //            System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1);

            //        }

            //        if (chk.RowIndex.Equals(2) && chk.Value != null)
            //        {

                   
            //            text2 ="Credit Card numbers, PAN's must be masked if displayed to web users for example : XXXX-XXXX-XXXX-3440"+ Environment.NewLine +
            //                          "Only the last 4 digits can be displayed back to the user"+ Environment.NewLine+ Environment.NewLine;
            //            System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1 + text2);

            //        }
            //    //4
            //     if (chk.RowIndex.Equals(3) &&  chk.Value != null)
            //        {

            //            text3 =
            //                         "According to PCI-DSS 3.2.1 Do not store the full contents of any track (from the magnetic stripe" + Environment.NewLine +
            //                          "located on the back of a card, equivalent data contained on a chip, or elsewhere). This data is alternatively " + Environment.NewLine +
            //                          "called full track, track, track 1, track 2, and magnetic-stripe data" + Environment.NewLine +
            //                          "The purpose of the card validation code(CVV) is to protect card-not-present transactions—Internet" + Environment.NewLine + 
            //                           "or mail order/telephone order (MO/TO) transactions—where the consumer and the card are not present. " + Environment.NewLine +
            //                           "If this data is stolen, malicious individuals can execute fraudulent Internet and MO/TO transactions.+" + Environment.NewLine + Environment.NewLine;

            //            System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1 + text2 + text3);

            //        }
            //    //5
            //     if (chk.RowIndex.Equals(4) &&  chk.Value != null)
            //     {

            //         text4 = "If your organization must store Card Holder data, it must be encrypted using strong cryptography, Truncation, Index tokens and securely stored pads" + Environment.NewLine +
            //                       "Please refer to the following document for more info: https://www.pcisecuritystandards.org/pdfs/pci_fs_data_storage.pdf" + Environment.NewLine +
            //                       "https://www.owasp.org/index.php/Cryptographic_Storage_Cheat_Sheet" + Environment.NewLine +
            //                       "https://www.owasp.org/index.php/Top_10_2010-A7-Insecure_Cryptographic_Storage" + Environment.NewLine;
            //         System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1 + text2 + text3 + text4);

            //     }

            //     //6
            //     if (chk.RowIndex.Equals(6) &&  chk.Value != null)
            //     {

            //         text5 = "Transmition of CHD " + Environment.NewLine +
            //                "HTTP authentication should be implemented over TLS and any information that contains CHD" + Environment.NewLine +
            //                "Please check your deployment process to verify that HTTPS protocol has been implemented properly" + Environment.NewLine +
            //                "https://owasp.org/index.php/Transport_Layer_Protection_Cheat_Sheet" + Environment.NewLine 
            //                + Environment.NewLine + Environment.NewLine;
            //            System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1);
            //         System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1 + text2 + text3 + text4 +text5);

            //     }

            //     //7
            //     if (chk.RowIndex.Equals(7) &&  chk.Value != null)
            //     {

            //         text1 = "Set secure Headers" + Environment.NewLine +
            //                "Please check your deployment process to verify that HTTPS protocol has been implemented" + Environment.NewLine+
            //                "Visit:https://www.owasp.org/index.php/HTTP_Strict_Transport_Security"+ Environment.NewLine + Environment.NewLine;
            //         System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1 + text2 + text3 + text4);

            //     }


                   
            //    }
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex= dataGridView1.CurrentCell.ColumnIndex; 

            dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString();


                dataGridView1.EndEdit();
                MessageBox.Show("Information has been processed-Open the report to find out analysis");
         
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

        private bool Validate()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please fill in the application name");
                return true;
            
            }
            return false;
        
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
