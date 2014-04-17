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

        private void tabPage2_Click(object sender, EventArgs e)
        {

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

        DataGridViewComboBoxColumn CreateComboBoxWithEnums()
        {
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.DataPropertyName = "Title";
            combo.Name = "Title";
            return combo;
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

        }


    }
}
