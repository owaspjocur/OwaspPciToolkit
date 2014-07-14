using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OwaspPciToolkit
{
    public class Clarifications
    {

        public List<string[]> clarification()
        {
            string line;
            List<string[]> clarifications = new List<string[]>();
            // Read each line of the file into a string array. Each element 
            // of the array is one line of the file.
            System.IO.StreamReader file =
            new System.IO.StreamReader(@"Domain/clarifications.txt");

            // Display the file contents by using a foreach loop. 
            while ((line = file.ReadLine()) != null)
            {
                clarifications.Add(new string[] { line });
            }

            return clarifications;

        }

    }
}
