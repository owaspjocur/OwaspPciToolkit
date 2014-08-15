using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OwaspPciToolkit
{
    public partial class LoginTest : Form
    {
        public LoginTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string targetURL = textBox1.Text;

            if (Uri.IsWellFormedUriString(targetURL, UriKind.RelativeOrAbsolute))
            {
                System.Diagnostics.Process.Start(targetURL);

                using (WebClient client = new WebClient())
                {
                    client.Headers["User-Agent"] =
                    "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
                    "(compatible; MSIE 6.0; Windows NT 5.1; " +
                    ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";

                    // Download data.
                    //basic search google results
                    client.DownloadFile(targetURL, "LoginTest.html");

                    //Login with fake account facebook

                }
            }
            else
            {

                MessageBox.Show("The URL provided is not correct");
            
            }


        }
    }
}
