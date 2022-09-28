using System;
using System.Collections.Specialized;
using System.Linq;

/****
 * Roman Numeral Comparison
 * Compares to Roman numerals in value.
 * Tyler Housand
 * 9/28/2022
 ***/

namespace Roman_Numeral_Comparison
{
    class Program
    {
        private static readonly OrderedDictionary RomanNumerals = new OrderedDictionary()
        {
            {"I",1}, {"V",5}, {"X",10}, {"L",50}, {"C",100}, {"D",500}, {"M", 1000}
        };
        static void Main(string[] args)
        {
            bool acceptableValue = false;
            string romanNumeralOne;
            int romanNumeralOneValue;
            string romanNumeralTwo;
            int romanNumeralTwoValue;
            do
            {
                Console.Write("Please enter a Roman numeral: ");
                romanNumeralOne = Console.ReadLine();
                romanNumeralOne = romanNumeralOne.ToUpper();
                romanNumeralOne = String.Concat(romanNumeralOne.Where(c => !Char.IsWhiteSpace(c)));
                acceptableValue = CheckRomanNumeral(romanNumeralOne);
            } while (acceptableValue == false);
            acceptableValue = false;
            do
            {
                Console.Write("Please enter a second Roman numeral: ");
                romanNumeralTwo = Console.ReadLine();
                romanNumeralTwo = romanNumeralTwo.ToUpper();
                romanNumeralTwo = String.Concat(romanNumeralTwo.Where(c => !Char.IsWhiteSpace(c)));
                acceptableValue = CheckRomanNumeral(romanNumeralTwo);
            } while (acceptableValue == false);
            romanNumeralOneValue = CalculateRomanNumeral(romanNumeralOne);
            romanNumeralTwoValue = CalculateRomanNumeral(romanNumeralTwo);
            if (romanNumeralOneValue > romanNumeralTwoValue)
            {
                Console.WriteLine(romanNumeralOne + " is greater than " + romanNumeralTwo);
            }
            else if (romanNumeralOneValue < romanNumeralTwoValue)
            {
                Console.WriteLine(romanNumeralTwo + " is greater than " + romanNumeralOne);
            }
            else Console.WriteLine("The two Roman numerals are equal.");
        }

        //calculates the value of a roman numeral
        public static int CalculateRomanNumeral(String romanNumeral)
        {
            int romanNumeralSum = 0;
            for (int x = 0; x < romanNumeral.Length; x++)
            {
                if(x < romanNumeral.Length - 1)
                {
                    if ((int)RomanNumerals[romanNumeral[x].ToString()] < (int)RomanNumerals[romanNumeral[x + 1].ToString()])
                    {
                        romanNumeralSum += (int)RomanNumerals[romanNumeral[x + 1].ToString()] - (int)RomanNumerals[romanNumeral[x].ToString()];
                        x++;
                    } else romanNumeralSum += (int)RomanNumerals[romanNumeral[x].ToString()];
                } else romanNumeralSum += (int)RomanNumerals[romanNumeral[x].ToString()];
            }
            Console.WriteLine(romanNumeral + " equals " + romanNumeralSum);
            return romanNumeralSum;
        }

        //checks if roman numeral entered is valid
        public static bool CheckRomanNumeral(String romanNumeral)
        {
            string romanNumeralLetters = "IVXLCDM";
            int index = 0;
            string twoNumeralCombination;
            foreach(char c in romanNumeral)
            {
                if (!romanNumeralLetters.Contains(c.ToString()))
                {
                    return badRomanNumeral();
                }
                if(index < romanNumeral.Length - 3)
                {
                    if (c.Equals(romanNumeral[index + 1]) && c.Equals(romanNumeral[index + 2]) && c.Equals(romanNumeral[index + 3]))
                    {
                        return badRomanNumeral();
                    }
                }
                if(index < romanNumeral.Length - 1)
                {
                    twoNumeralCombination = romanNumeral[index].ToString() + romanNumeral[index + 1].ToString();
                    switch(twoNumeralCombination){
                        case "IL":
                            return badRomanNumeral();
                        case "IC":
                            return badRomanNumeral();
                        case "ID":
                            return badRomanNumeral();
                        case "IM":
                            return badRomanNumeral();
                        case "VX":
                            return badRomanNumeral();
                        case "VL":
                            return badRomanNumeral();
                        case "VC":
                            return badRomanNumeral();
                        case "VD":
                            return badRomanNumeral();
                        case "VM":
                            return badRomanNumeral();
                        case "XD":
                            return badRomanNumeral();
                        case "XM":
                            return badRomanNumeral();
                        case "LC":
                            return badRomanNumeral();
                        case "LD":
                            return badRomanNumeral();
                        case "LM":
                            return badRomanNumeral();
                        case "DM":
                            return badRomanNumeral();
                        default:
                            break;
                    }
                }
                index++;
            }
            return true;
        }

        //a quick method to give an invalid input message for bad numbers
        public static bool badRomanNumeral()
        {
            Console.WriteLine("Invalid Input. Please try again.");
            return false;
        }
    }
}
