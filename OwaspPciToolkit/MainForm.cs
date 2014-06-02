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
        }

        private void DisplayGrid()
        {
            CardHolderQuestions listQ = new CardHolderQuestions();
            List<string[]> QuestionsC = listQ.chdQuestions().ToList();
            DataTable table = ConvertListToDataTable(QuestionsC);
            BSchd.DataSource = table;
            dataGridView1.DataSource = BSchd;
            dataGridView1.AutoResizeColumns();

            dataGridView1.Columns[0].HeaderText = "Questions";

            // Configure the details DataGridView so that its columns automatically 
            // adjust their widths when the data changes.
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Columns.Add(CreateCheckBox());



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


        DataGridViewCheckBoxColumn CreateCheckBox()
        {
            DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn();
            checkBox.DataPropertyName = "Answer";
            checkBox.Width = 100;
            checkBox.Name = "Answer -(checked is YES)";
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
                             "In order to verify the veracity of your answers regarding these questions, we strongly recommend the following steps:"+ Environment.NewLine + 
                             "The application should be properly tested against Security vulnerabilities as described in the OWASP top ten"+ Environment.NewLine + 
                             "It is recommended by the Security Council to use ASV(Approved Scanning Vendors) scanning tools" + Environment.NewLine +
                              "The most difficult part of the test is to verify that the application is indeed storing, trasmitting or process CHD"+ Environment.NewLine+
                              Environment.NewLine ;

           System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {                
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];

                    if (chk.RowIndex.Equals(0) && chk.Value == null)
                    {
                         text =
                            "The Web Application does not fall directly into the main PCI-DSS Scope" + Environment.NewLine ;
                        System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text);
                                               
                    }

                    if (chk.RowIndex.Equals(0) && chk.Value.Equals(true))
                    {
                        text =
                           "The Web Application falls into the main PCI-DSS Scope" + Environment.NewLine +
                           "We strongly recommend to read the OWASP Top 10 guidelines"+Environment.NewLine +
                           "https://www.owasp.org/index.php/Category:OWASP_Top_Ten_Project#tab=OWASP_Top_10_for_2013" + Environment.NewLine +
                           "The following checks are obligatory in order to become PCI-DSS complaint" + Environment.NewLine +
                           "Requirement 3 is about Protection of Card Holder Data" + Environment.NewLine +
                           "3.1 Keep cardholder data storage to a  minimum by implementing data retention"+ Environment.NewLine +
                           "and disposal policies, procedures and processes that include at least the following :" + Environment.NewLine +
                            "-For all cardholder data (CHD) storage: Limiting data storage amount and  retention time to that which is "+ Environment.NewLine +
                            "required for legal, regulatory, and business requirements "+ Environment.NewLine +
                            "-Processes for secure deletion of data when no longer needed" + Environment.NewLine +
                            "-Specific retention requirements for cardholder data "+ Environment.NewLine +
                            "-A quarterly process for identifying and securely deleting stored cardholder data that exceeds defined retention."+
                            Environment.NewLine + Environment.NewLine;
                        System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text);

                    }
                
                    if (chk.RowIndex.Equals(1) && chk.Value == null)
                    {

                        text1 = "Authentication" + Environment.NewLine +
                           "HTTP authentication should be implemented over TLS" + Environment.NewLine +
                           "Please check your deployment process to verify that HTTPS protocol has been implemented" + Environment.NewLine +
                           "Read the following guidelines regarding secure authentication:" + Environment.NewLine +
                            "https://www.owasp.org/index.php/Authentication_Cheat_Sheet" + Environment.NewLine +
                            "https://www.owasp.org/index.php/Session_Management_Cheat_Sheet" + Environment.NewLine + Environment.NewLine;
                        System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1);

                    }

                    if (chk.RowIndex.Equals(2) && chk.Value != null)
                    {

                   
                        text2 ="Credit Card numbers, PAN's must be masked if displayed to web users for example : XXXX-XXXX-XXXX-3440"+ Environment.NewLine +
                                      "Only the last 4 digits can be displayed back to the user"+ Environment.NewLine+ Environment.NewLine;
                        System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1 + text2);

                    }
                //4
                 if (chk.RowIndex.Equals(3) &&  chk.Value != null)
                    {

                        text3 =
                                     "According to PCI-DSS 3.2.1 Do not store the full contents of any track (from the magnetic stripe" + Environment.NewLine +
                                      "located on the back of a card, equivalent data contained on a chip, or elsewhere). This data is alternatively " + Environment.NewLine +
                                      "called full track, track, track 1, track 2, and magnetic-stripe data" + Environment.NewLine +
                                      "The purpose of the card validation code(CVV) is to protect card-not-present transactions—Internet" + Environment.NewLine + 
                                       "or mail order/telephone order (MO/TO) transactions—where the consumer and the card are not present. " + Environment.NewLine +
                                       "If this data is stolen, malicious individuals can execute fraudulent Internet and MO/TO transactions.+" + Environment.NewLine + Environment.NewLine;

                        System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1 + text2 + text3);

                    }
                //5
                 if (chk.RowIndex.Equals(4) &&  chk.Value != null)
                 {

                     text4 = "If your organization must store Card Holder data, it must be encrypted using strong cryptography, Truncation, Index tokens and securely stored pads" + Environment.NewLine +
                                   "Please refer to the following document for more info: https://www.pcisecuritystandards.org/pdfs/pci_fs_data_storage.pdf" + Environment.NewLine +
                                   "https://www.owasp.org/index.php/Cryptographic_Storage_Cheat_Sheet" + Environment.NewLine +
                                   "https://www.owasp.org/index.php/Top_10_2010-A7-Insecure_Cryptographic_Storage" + Environment.NewLine;
                     System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1 + text2 + text3 + text4);

                 }

                 //6
                 if (chk.RowIndex.Equals(6) &&  chk.Value != null)
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
                 if (chk.RowIndex.Equals(7) &&  chk.Value != null)
                 {

                     text1 = "Set secure Headers" + Environment.NewLine +
                            "Please check your deployment process to verify that HTTPS protocol has been implemented" + Environment.NewLine+
                            "Visit:https://www.owasp.org/index.php/HTTP_Strict_Transport_Security"+ Environment.NewLine + Environment.NewLine;
                     System.IO.File.WriteAllText(@"PCI-DSS_analysis.txt", texthead + text + text1 + text2 + text3 + text4);

                 }


                   
                }
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
    }
}
