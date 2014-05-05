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
            checkBox.Name = "Answer";
            return checkBox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int TotalPoints = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (chk.Value == chk.FalseValue || chk.Value == null)
                    {
                        string text =
                            "PCI-DSS Scope Analysis" + Environment.NewLine +
                            "Application Name:" + textBox1.Text.ToString() + Environment.NewLine +
                            "Programming Language" + Environment.NewLine +
                            "The Web Application does not fall into the main PCI-DSS Scope" + Environment.NewLine +
                            "It does not" + Environment.NewLine;
                        // WriteAllText creates a file, writes the specified string to the file, 
                        // and then closes the file.
                        System.IO.File.WriteAllText(@"C:\Users\johanna\Documents\OWASP\WriteText.txt", text);
                        TotalPoints -= 1;

                    }
                    else
                    {
                        // Example #2: Write one string to a text file. 
                        string text = "Application falls into the PCI-DSS Scope " +
                                       "a class defines the data and behavior of the data type. ";
                        // WriteAllText creates a file, writes the specified string to the file, 
                        // and then closes the file.
                        System.IO.File.WriteAllText(@"C:\Users\johanna\Documents\OWASP\WriteText.txt", text);

                        TotalPoints += 1;

                    }

                    if (TotalPoints <= 0)
                    {
                        string text = "This application does not faal into the PCI-Scope";
                        System.IO.File.WriteAllText(@"C:\Users\johanna\Documents\OWASP\WriteText.txt", text); }
                    else
                    { string text = "This application falls into the PCI-Scope";
                        System.IO.File.WriteAllText(@"C:\Users\johanna\Documents\OWASP\WriteText.txt", text); }
                }


                dataGridView1.EndEdit();
         
            }
    }
}
