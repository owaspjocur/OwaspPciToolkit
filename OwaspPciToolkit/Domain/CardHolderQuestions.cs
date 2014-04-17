using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OwaspPciToolkit
{
    public class CardHolderQuestions
    {

        public List<string[]> chdQuestions()
        {
        
        List<string[]> chdListQuestions = new List<string[]>();
        // Read each line of the file into a string array. Each element 
        // of the array is one line of the file. 
        var lines = System.IO.File.ReadLines(@"questionsCHD.txt");

            // Display the file contents by using a foreach loop. 
            foreach(var line in lines)
            { 
                chdListQuestions.Add(new string[] {line});
            }     
       
        return chdListQuestions;
        
        }
        
    }
}
