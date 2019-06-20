using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingTest
{
    
    class Encoding
    {       
        List<List<int>> EncodedNumberValues;
        private List<string> fullEncodedString;
        string StringBeingEncoded;

        List<string> StringsYouwantEncoded;

        public List<string> FullEncodedString
        {
            get
            {
                return fullEncodedString;
            }

            set
            {
                fullEncodedString = value;
            }
        }

        public void SetupEncoder(List<string> StringsToBeEncoded)
        {
            EncodedNumberValues = new List<List<int>>();
            StringsYouwantEncoded = new List<string>();
            FullEncodedString = new List<string>();

            string tempstring;
            List<int> TempNumberList = new List<int>();

            for (int a = 0; a < StringsToBeEncoded.Count; a++)
            {
                tempstring = StringsToBeEncoded[a];
                EncodedNumberValues.Add(new List<int>());

                for (int i = 0; i < tempstring.Length; i++)
                {
                    EncodedNumberValues[a].Add(ConvertToNumber(tempstring[i]));
                }
            }

        }
        public void CleanUpEncoder()
        {
            EncodedNumberValues.Clear();
            FullEncodedString.Clear();
            StringsYouwantEncoded.Clear();
    }


        public void StartEncoding()
        {

            //AtoE = 1 to 5
            //FtoJ = 6 to 10
            //KtoO = 11 to 15
            //PtoT = 16 to 20
            //UtoZ = 21 to 26
            for (int a = 0; a < EncodedNumberValues.Count; a++)
            {
                StringBeingEncoded = "";

                for (int i = 0; i < EncodedNumberValues[a].Count; i++)
                {
                                  
                    if (EncodedNumberValues[a][i] >= 1 && EncodedNumberValues[a][i] <= 5)
                    {
                     
                        StringBeingEncoded += AtoE(a,i);
                    }
                    else if (EncodedNumberValues[a][i] >= 6 && EncodedNumberValues[a][i] <= 10)
                    {
  
                        StringBeingEncoded += FtoJ(a,i);
                    }
                    else if (EncodedNumberValues[a][i] >= 11 && EncodedNumberValues[a][i] <= 15)
                    {
                        
                        StringBeingEncoded += KtoO(a,i);
                    }
                    else if (EncodedNumberValues[a][i] >= 16 && EncodedNumberValues[a][i] <= 20)
                    {
                        
                        StringBeingEncoded += PtoT(a,i);
                    }
                    else if (EncodedNumberValues[a][i] >= 21 && EncodedNumberValues[a][i] <= 26)
                    {
                        
                        StringBeingEncoded += UtoZ(a,i);
                    }
                    
                }
                FullEncodedString.Add(StringBeingEncoded);
            }           
        }
        //Multiple value by 2.
        public char AtoE(int index1,int Index2)
        {
            if (Index2 == 0)
            {
                return LoopCalculation(1, EncodedNumberValues[index1][Index2]*2);
            }
            else
            {
                return LoopCalculation(ConvertToNumber(StringBeingEncoded[Index2 - 1]), EncodedNumberValues[index1][Index2] * 2);
            }
        }

        //Divide its numerical value by 3, multiple the remainder by 5.
        public char FtoJ(int index1, int Index2)
        {

            int RemainderMultiplied;
            RemainderMultiplied = ((EncodedNumberValues[index1][Index2] % 3) * 5);

            if (Index2 == 0)
            {
                return LoopCalculation(1, RemainderMultiplied);
            }
            else
            {
                return LoopCalculation(ConvertToNumber(StringBeingEncoded[Index2 - 1]), RemainderMultiplied);
            }
        }

        //Divide its numerical value by 4, multiply the interger part of the quotient by 8.
        public char KtoO(int index1, int Index2)
        {

            int FullNumberMulti = ((EncodedNumberValues[index1][Index2] / 4) * 8);
            if (Index2 == 0)
            {
                return LoopCalculation(1, FullNumberMulti);
            }
            else
            {
                return LoopCalculation(ConvertToNumber(StringBeingEncoded[Index2 - 1]), FullNumberMulti);
            }
        }

        //Multiply the sum of the digits of its numerical value by 10
        public char PtoT(int index1, int Index2)
        {
            int SumMulti = SumDigits(EncodedNumberValues[index1][Index2]) * 10;

            if (Index2 == 0)
            {
                return LoopCalculation(1, SumMulti);
            }
            else
            {
                return LoopCalculation(ConvertToNumber(StringBeingEncoded[Index2 - 1]), SumMulti);
            }          
        }

        //Find the largest integer factor of its numerical value less than the value itself. Multiple by 12.
        public char UtoZ(int index1, int Index2)
        {

            int HighestFactor = 0;            
            for (int i=1; i < EncodedNumberValues[index1][Index2]; i++)
            {
                if(EncodedNumberValues[index1][Index2] % i == 0 && i > HighestFactor)
                {
                    HighestFactor = i;
                }
            }
            if (Index2 == 0)
            {
                return LoopCalculation(1, HighestFactor * 12);
            }
            else
            {
                return LoopCalculation(ConvertToNumber(StringBeingEncoded[Index2 - 1]), HighestFactor * 12);
            }
        }

        public char LoopCalculation(int StartingPoint,int Value)
        {

            if(Value > 26 && (StartingPoint + (Value % 26)) <= 26)
            {
                return ConvertToLetter((StartingPoint + (Value % 26)));
            }
            else if (Value > 26 && StartingPoint + (Value % 26) > 26)
            {
                return ConvertToLetter((StartingPoint + (Value % 26) - 26));
            }
            else if (Value < 26 && (StartingPoint + Value) > 26)
            {

                return ConvertToLetter((StartingPoint + Value) - 26);
            }
            else
            {
                return ConvertToLetter(StartingPoint + Value);
            }
            
        }

        public int ConvertToNumber(char LetterToConvert)
        {
            return (Convert.ToInt32(LetterToConvert) - Convert.ToInt32('a')+1);
        }
        public char ConvertToLetter(int NumberToConvert)
        {
            return (Convert.ToChar(((NumberToConvert) + Convert.ToInt32('a'))-1));
        }

        public int SumDigits(int value)
        {
            int sum = 0;
            while (value != 0)
            {
                int rem;
                value = Math.DivRem(value, 10, out rem);
                sum += rem;
            }
            return sum;
        }
    }
}
