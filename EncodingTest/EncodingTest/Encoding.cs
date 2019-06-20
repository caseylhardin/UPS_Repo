using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingTest
{
    
    class Encoding
    {       
        List<int> EncodedNumberValues;
        string FullEncodedString;
     
        public void SetupEncoder(string StringToBeEncoded)
        {            
            EncodedNumberValues = new List<int>();
            for(int i=0; i < StringToBeEncoded.Length;i++)
            {
                EncodedNumberValues.Add(ConvertToNumber(StringToBeEncoded[i]));
            }

        }
        public void CleanUpEncoder()
        {
            EncodedNumberValues.Clear();
            FullEncodedString = "";
        }


        public string StartEncoding()
        {

            //AtoE = 1 to 5
            //FtoJ = 6 to 10
            //KtoO = 11 to 15
            //PtoT = 16 to 20
            //UtoZ = 21 to 26

            for (int i = 0; i < EncodedNumberValues.Count; i++)
            {
                if (EncodedNumberValues[i] >= 1 && EncodedNumberValues[i] <= 5)
                {
                    FullEncodedString += AtoE(i);
                }
                else if (EncodedNumberValues[i] >= 6 && EncodedNumberValues[i] <= 10)
                {
                    FullEncodedString += FtoJ(i);
                }
                else if (EncodedNumberValues[i] >= 11 && EncodedNumberValues[i] <= 15)
                {
                    FullEncodedString += KtoO(i);
                }
                else if (EncodedNumberValues[i] >= 16 && EncodedNumberValues[i] <= 20)
                {
                    FullEncodedString += PtoT(i);
                }
                else if (EncodedNumberValues[i] >= 21 && EncodedNumberValues[i] <= 26)
                {
                    FullEncodedString += UtoZ(i);
                }

            }            
            return FullEncodedString;
        }
        //Multiple value by 2.
        public char AtoE(int Index)
        {
            if (Index == 0)
            {
                return LoopCalculation(1, EncodedNumberValues[Index]*2);
            }
            else
            {
                return LoopCalculation(ConvertToNumber(FullEncodedString[Index - 1]), EncodedNumberValues[Index] * 2);
            }
        }

        //Divide its numerical value by 3, multiple the remainder by 5.
        public char FtoJ(int Index)
        {

            int RemainderMultiplied;
            RemainderMultiplied = ((EncodedNumberValues[Index] % 3) * 5);

            if (Index == 0)
            {
                return LoopCalculation(1, RemainderMultiplied);
            }
            else
            {
                return LoopCalculation(ConvertToNumber(FullEncodedString[Index - 1]), RemainderMultiplied);
            }
        }

        //Divide its numerical value by 4, multiply the interger part of the quotient by 8.
        public char KtoO(int Index)
        {

            int FullNumberMulti = ((EncodedNumberValues[Index] / 4) * 8);
            if (Index == 0)
            {
                return LoopCalculation(1, FullNumberMulti);
            }
            else
            {
                return LoopCalculation(ConvertToNumber(FullEncodedString[Index - 1]), FullNumberMulti);
            }
        }

        //Multiply the sum of the digits of its numerical value by 10
        public char PtoT(int Index)
        {
            int SumMulti = SumDigits(EncodedNumberValues[Index]) * 10;

            if (Index == 0)
            {
                return LoopCalculation(1, SumMulti);
            }
            else
            {
                return LoopCalculation(ConvertToNumber(FullEncodedString[Index - 1]), SumMulti);
            }          
        }

        //Find the largest integer factor of its numerical value less than the value itself. Multiple by 12.
        public char UtoZ(int Index)
        {

            int HighestFactor = 0;            
            for (int i=1; i < EncodedNumberValues[Index]; i++)
            {
                if(EncodedNumberValues[Index] % i == 0 && i > HighestFactor)
                {
                    HighestFactor = i;
                }
            }
            if (Index == 0)
            {
                return LoopCalculation(1, HighestFactor * 12);
            }
            else
            {
                return LoopCalculation(ConvertToNumber(FullEncodedString[Index - 1]), HighestFactor * 12);
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
