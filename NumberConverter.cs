using System;
using System.Globalization;

namespace NumberConverter
{
    public class NumberConverter
    {
        private static readonly string[] OneToNineteen = {
            "", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX",
            "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE",
            "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN",
            "SEVENTEEN", "EIGHTEEN", "NINETEEN"
        };

        private static readonly string[] Tens = {
            "", "", "TWENTY", "THIRTY", "FORTY", "FIFTY",
            "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
        };

        // Handle numbers with two digits.
        public string TenDigits(long number)
        {
            if (number.ToString().Length != 2)
            {
                throw new ArgumentException("Number must be exactly 2 digits");
            }

            if (number <= 19 && number != 0)
            {
                return OneToNineteen[number];
            }
            else
            {
                int tenDigit = int.Parse(number.ToString().Substring(0, 1));
                int oneDigit = int.Parse(number.ToString().Substring(1, 1));
                if (oneDigit != 0)// Then add - to connect ten and one, e.g., Thirty-Four
                {
                    return Tens[tenDigit] + "-" + OneToNineteen[oneDigit];
                }
                else
                {
                    return Tens[tenDigit];
                }
            }
        }

        // Handle numbers with three digits.
        public string HundredDigits(long number)
        {
            if (number.ToString().Length != 3)
            {
                throw new ArgumentException("Number must be exactly 3 digits");
            }

            int hundredDigit = int.Parse(number.ToString().Substring(0, 1));
            string words = OneToNineteen[hundredDigit] + " HUNDRED";
            string secondPart = number.ToString().Substring(1);
            words += ConvertSecondPart(secondPart);
            return words;
        }

        // Handle numbers with 4 to 6 digits.
        public string ThousandDigits(long number)
        {
            int length = number.ToString().Length;
            if (length < 4 || length > 6)
            {
                throw new ArgumentException("Number must be between 4 and 6 digits");
            }

            string numStr = number.ToString();
            long thousandPart = long.Parse(numStr.Substring(0, numStr.Length - 3));
            string words;

            if (thousandPart < 20)
            {
                words = OneToNineteen[thousandPart];
            }
            else if (thousandPart <= 99)
            {
                words = TenDigits(thousandPart);
            }
            else
            {
                words = HundredDigits(thousandPart);
            }

            words += " THOUSAND";
            string secondPart = numStr.Substring(numStr.Length - 3);
            words += ConvertSecondPart(secondPart);
            return words;
        }

        // Handle numbers with 7 to 9 digits.
        public string MillionDigits(long number)
        {
            int length = number.ToString().Length;
            if (length < 7 || length > 9)
            {
                throw new ArgumentException("Number must be between 7 and 9 digits");
            }

            string numStr = number.ToString();
            long millionPart = long.Parse(numStr.Substring(0, numStr.Length - 6));
            string words;

            if (millionPart < 20)
            {
                words = OneToNineteen[millionPart];
            }
            else if (millionPart <= 99)
            {
                words = TenDigits(millionPart);
            }
            else
            {
                words = HundredDigits(millionPart);
            }

            words += " MILLION";
            string secondPart = numStr.Substring(numStr.Length - 6);
            words += ConvertSecondPart(secondPart);
            return words;
        }

        // Handle numbers with 10 to 12 digits.
        public string BillionDigits(long number)
        {
            int length = number.ToString().Length;
            if (length < 10 || length > 12)
            {
                throw new ArgumentException("Number must be between 10 and 12 digits");
            }

            string numStr = number.ToString();
            long billionPart = long.Parse(numStr.Substring(0, numStr.Length - 9));
            string words;

            if (billionPart < 20)
            {
                words = OneToNineteen[billionPart];
            }
            else if (billionPart <= 99)
            {
                words = TenDigits(billionPart);
            }
            else
            {
                words = HundredDigits(billionPart);
            }

            words += " BILLION";
            string secondPart = numStr.Substring(numStr.Length - 9);
            words += ConvertSecondPart(secondPart);
            return words;
        }

        // Handle numbers with 13 to 15 digits.
        public string TrillionDigits(long number)
        {
            int length = number.ToString().Length;
            if (length < 13 || length > 15)
            {
                throw new ArgumentException("Number must be between 13 and 15 digits");
            }

            string numStr = number.ToString();
            long trillionPart = long.Parse(numStr.Substring(0, numStr.Length - 12));
            string words;

            if (trillionPart < 20)
            {
                words = OneToNineteen[trillionPart];
            }
            else if (trillionPart <= 99)
            {
                words = TenDigits(trillionPart);
            }
            else
            {
                words = HundredDigits(trillionPart);
            }

            words += " TRILLION";
            string secondPart = numStr.Substring(numStr.Length - 12);
            words += ConvertSecondPart(secondPart);
            return words;
        }

        // Handle numbers with 16 to 18 digits.
        public string QuadrillionDigits(long number)
        {
            int length = number.ToString().Length;
            if (length < 16 || length > 18)
            {
                throw new ArgumentException("Number must be between 16 and 18 digits");
            }

            string numStr = number.ToString();
            long quadrillionPart = long.Parse(numStr.Substring(0, numStr.Length - 15));
            string words;

            if (quadrillionPart < 20)
            {
                words = OneToNineteen[quadrillionPart];
            }
            else if (quadrillionPart <= 99)
            {
                words = TenDigits(quadrillionPart);
            }
            else
            {
                words = HundredDigits(quadrillionPart);
            }

            words += " QUADRILLION";
            string secondPart = numStr.Substring(numStr.Length - 15);
            words += ConvertSecondPart(secondPart);
            return words;
        }

        private string ConvertSecondPart(string secondPart)
        {
            long secondPartNum = long.Parse(secondPart);
            int digitNumber = secondPartNum.ToString().Length;
            string words = "";

            if (digitNumber == 1)
            {
                if (secondPartNum != 0)
                {
                    words = " AND " + OneToNineteen[secondPartNum];
                }// else do nothing
            }
            else if (digitNumber == 2)
            {
                words = " AND " + TenDigits(secondPartNum);
            }
            else if (digitNumber == 3)
            {
                words = " " + HundredDigits(secondPartNum);
            }
            else if (digitNumber >= 4 && digitNumber <= 6)
            {
                words = " " + ThousandDigits(secondPartNum);
            }
            else if (digitNumber >= 7 && digitNumber <= 9)
            {
                words = " " + MillionDigits(secondPartNum);
            }
            else if (digitNumber >= 10 && digitNumber <= 12)
            {
                words = " " + BillionDigits(secondPartNum);
            }
            else if (digitNumber >= 13 && digitNumber <= 15)
            {
                words = " " + TrillionDigits(secondPartNum);
            }

            return words;
        }

        public string ConvertNumToWords(long number)
        {
            int digitNumber = number.ToString().Length;
            string words;

            if (number < 20)
            {
                if (number == 0)
                {
                    words = "";
                }
                else
                {
                    words = OneToNineteen[number];
                }
            }
            else if (digitNumber == 2)
            {
                words = TenDigits(number);
            }
            else if (digitNumber == 3)
            {
                words = HundredDigits(number);
            }
            else if (digitNumber >= 4 && digitNumber <= 6)
            {
                words = ThousandDigits(number);
            }
            else if (digitNumber >= 7 && digitNumber <= 9)
            {
                words = MillionDigits(number);
            }
            else if (digitNumber >= 10 && digitNumber <= 12)
            {
                words = BillionDigits(number);
            }
            else if (digitNumber >= 13 && digitNumber <= 15)
            {
                words = TrillionDigits(number);
            }
            else if (digitNumber >= 16 && digitNumber <= 18)
            {
                words = QuadrillionDigits(number);
            }
            else
            {
                words = "Surpass maximum";
            }

            return words;
        }

        // Handle decimal part, perfom round up when decimal part has more than 2 digits.
        private long RoundupDecimalPart(string decimalPart)
        {
            int digitNumber = decimalPart.Length;
            if (digitNumber > 2)
            {
                long validPart = long.Parse(decimalPart.Substring(0, 2));
                if (int.Parse(decimalPart.Substring(2, 1)) >= 5)
                {
                    validPart += 1;
                }
                return validPart;
            }
            return long.Parse(decimalPart);
        }

        public string ConvertToCurrency(string num)
        {
            if (!num.Contains("."))
            {
                num += ".0";
            }

            string[] parts = num.Split('.');
            long integerPart = long.Parse(parts[0]);
            string decimalPart = parts[1]; // No need to convert decimalPart, if we do, if decimal part os 0006, then it will be 6. 

            // Handle rounding up for 0.995+ cases
            if (decimalPart.Length >= 3 && long.Parse(decimalPart.Substring(0, 3)) >= 995)
            {
                decimalPart = "0";
                integerPart += 1;
            }

            long decimalPartNum = RoundupDecimalPart(decimalPart);
            string decimalPartWords = ConvertNumToWords(decimalPartNum);
            string integerPartWords = ConvertNumToWords(integerPart);
            if (integerPartWords == "Surpass maximum")
            {
                return "Number too large, maximum number supported is 999,999,999,999,999,999.99";
            }

            // Add dollar/dollars
                if (integerPart == 1)
                {
                    integerPartWords += " DOLLAR";
                }
                else if (integerPart > 1)
                {
                    integerPartWords += " DOLLARS";
                }

            // Add cent/cents
            if (decimalPartNum == 1)
            {
                decimalPartWords += " CENT";
            }
            else if (decimalPartNum > 1)
            {
                decimalPartWords += " CENTS";
            }

            // Combine results
            string result;
            if (!string.IsNullOrEmpty(integerPartWords) && !string.IsNullOrEmpty(decimalPartWords))
            {
                result = integerPartWords + " AND " + decimalPartWords;
            }
            else if (string.IsNullOrEmpty(integerPartWords) && !string.IsNullOrEmpty(decimalPartWords))
            {
                result = decimalPartWords;
            }
            else if (!string.IsNullOrEmpty(integerPartWords) && string.IsNullOrEmpty(decimalPartWords))
            {
                result = integerPartWords;
            }
            else
            {
                result = "ZERO DOLLAR";
            }

            return result;
        }

        // For testing purposes
        public static void Main(string[] args)
        {
            var converter = new NumberConverter();

            // Test examples
            Console.WriteLine(converter.ConvertToCurrency("123.45"));
            Console.WriteLine(converter.ConvertToCurrency("0.99"));
            Console.WriteLine(converter.ConvertToCurrency("1000000.00"));
            Console.WriteLine(converter.ConvertToCurrency("0.995"));
            Console.WriteLine(converter.ConvertToCurrency("0.00"));
        }
    }
}