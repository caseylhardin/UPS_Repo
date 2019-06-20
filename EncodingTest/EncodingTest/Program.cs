using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace EncodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string StringToBeEncoded = "";
            Encoding Encoder = new Encoding();
            bool GoAgain = true;

            while (GoAgain == true)
            { 
            
            Console.WriteLine("Please enter in 3 letters from A to Z.");
            do
            {
                char c = Console.ReadKey().KeyChar;
                if (char.IsLetter(c))
                {
                    StringToBeEncoded += c;
                }
                else
                {
                    StringToBeEncoded = "";
                    Console.WriteLine('\n' + "Please enter only 3 letters from A to Z.");
                }                                  
            } while (StringToBeEncoded.Length < 3); // Limit to 3 chars

            Encoder.SetupEncoder(StringToBeEncoded);

            Console.WriteLine('\n'+ "The encoded version of your string is"+'\n'+ Encoder.StartEncoding());
                
                Console.WriteLine('\n' + "Go Again ? press y or n for yes or no. ");
                char c2 = Console.ReadKey().KeyChar;
                if (char.IsLetter(c2) && c2 == 'y')
                { 

                    StringToBeEncoded = "";
                    Encoder.CleanUpEncoder();
                    Console.WriteLine('\n');
                }
                else
                {
                    GoAgain = false;
                }
            
            }

        }          
    }
}
