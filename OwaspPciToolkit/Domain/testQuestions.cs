using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwaspPciToolkit
{
    public class testQuestions
    {
        public List<string[]> testerQuestions()
        {
            string line;
            List<string[]> testListQuestions = new List<string[]>();
            // Read each line of the file into a string array. Each element 
            // of the array is one line of the file.
            System.IO.StreamReader file =
            new System.IO.StreamReader("questionsTest.txt");

            // Display the file contents by using a foreach loop. 
            while ((line = file.ReadLine()) != null)
            {
                testListQuestions.Add(new string[] { line });
            }

            return testListQuestions;

        }
    }
}
