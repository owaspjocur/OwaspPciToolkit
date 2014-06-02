using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwaspPciToolkit
{
    public class DevelopQuestions
    {
        public List<string[]> developQuestions()
        {
            string line;
            List<string[]> devListQuestions = new List<string[]>();
            // Read each line of the file into a string array. Each element 
            // of the array is one line of the file.
            System.IO.StreamReader file =
            new System.IO.StreamReader("questionsDevelopment.txt");

            // Display the file contents by using a foreach loop. 
            while ((line = file.ReadLine()) != null)
            {
                devListQuestions.Add(new string[] { line });
            }

            return devListQuestions;

        }
    }
}
