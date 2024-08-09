using System;

namespace HellowWord
{
    class Program
    {
        static void Main(string[] args ){
        
            string textAge  = "-23";
            int convertedText = Convert.ToInt32(textAge);
            int age;
            long bigNumber  = 90000000;
            decimal floatNumber = 4.09m;
            float myFloat = 1.000001F;
            age =50;
            string name = "Mlu";
            char letter = 'a';
            char letter2 = '\0';
            char letter3 = '\t';
            string textPrecision = "5.00001";
            float precision = Convert.ToSingle(textPrecision);  
            long bigNumber2  = Convert.ToInt32(bigNumber);

            Console.WriteLine("Hello World");
            Console.WriteLine(age);
            Console.WriteLine(bigNumber);
            Console.WriteLine(floatNumber);
            Console.WriteLine(myFloat);
            Console.WriteLine(bigNumber);
            Console.WriteLine(bigNumber2);
            Console.WriteLine(name);
            Console.WriteLine(letter2);
            Console.WriteLine(letter);
            Console.WriteLine(convertedText);
            Console.WriteLine(precision);
        }
    }
}