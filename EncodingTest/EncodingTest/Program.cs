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
            bool DoneReading = false;

            while (GoAgain == true)
            { 
            
            Console.WriteLine("Please enter in letters from A to Z.");
            do
            {
                ConsoleKeyInfo c = Console.ReadKey();
                    if (char.IsLetter(c.KeyChar))
                    {
                        StringToBeEncoded += c.KeyChar;
                    }
                    else if (c.Key != ConsoleKey.Enter && !char.IsLetter(c.KeyChar))
                    {
                        StringToBeEncoded = "";
                        Console.WriteLine('\n' + "Please enter only letters from A to Z.");
                    }
                    else if(c.Key == ConsoleKey.Enter)
                    {
                        DoneReading = true;
                    }
                } while (DoneReading == false);

            Encoder.SetupEncoder(StringToBeEncoded);

            Console.WriteLine('\n'+ "The encoded version of your string is"+'\n'+ Encoder.StartEncoding());
                
                Console.WriteLine('\n' + "Go Again ? press y or n for yes or no. ");
                char c2 = Console.ReadKey().KeyChar;
                if (char.IsLetter(c2) && c2 == 'y')
                { 
                    DoneReading = false;
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
