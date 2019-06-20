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
            List<string> StringsToBeEncoded = new List<string>();
            string StringToBeEncoded = "";
            Encoding Encoder = new Encoding();
            bool GoAgain = true;
            bool DoneReading = false;
          
            while (GoAgain == true)
            { 
            
            Console.WriteLine("Please enter in strings to be encoded from A to Z, use $ to enter new string and press enter when done.");
                do
                {
                    ConsoleKeyInfo c = Console.ReadKey();

                    if (char.IsLetter(c.KeyChar))
                    {
                        StringToBeEncoded += c.KeyChar;
                    }
                    else if (c.Key != ConsoleKey.Enter && !char.IsLetter(c.KeyChar) && c.KeyChar != '$')
                    {
                        StringToBeEncoded = "";
                        Console.WriteLine('\n' + "Please enter only letters from A to Z.");
                    }
                    else if (c.KeyChar == '$')
                    {
                        Console.WriteLine('\n');
                        StringsToBeEncoded.Add(StringToBeEncoded);
                        StringToBeEncoded = "";
                    }
                    else if (c.Key == ConsoleKey.Enter)
                    {
                        StringsToBeEncoded.Add(StringToBeEncoded);
                        StringToBeEncoded = "";
                        DoneReading = true;
                    }
                } while (DoneReading == false); // Limit to 4 chars

            Encoder.SetupEncoder(StringsToBeEncoded);


                Console.WriteLine('\n' + "The encoded version of your strings are as follows." + '\n');
                Encoder.StartEncoding();

                for (int i = 0; i < StringsToBeEncoded.Count();i++)
                {
                    Console.WriteLine('\n'+ Encoder.FullEncodedString[i]);
                }
                          
                Console.WriteLine('\n' + "Go Again ? press y or n for yes or no. ");
                char c2 = Console.ReadKey().KeyChar;
                if (char.IsLetter(c2) && c2 == 'y')
                { 

                    StringToBeEncoded = "";
                    StringsToBeEncoded.Clear();
                    Encoder.CleanUpEncoder();
                    Console.WriteLine('\n');
                    DoneReading = false;
                }
                else
                {
                    GoAgain = false;
                }
            
            }

        }          
    }
}
