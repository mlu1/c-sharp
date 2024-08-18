using System;

namespace HellowWord
{
    class Customer{
        public string firstname;
        public string  lastName;
        
        public void setName(string customerName){
                firstname = customerName;
        }

        public void setLastName(string customerLastName){
            lastName = customerLastName;
        }

        public string getName(){
            return this.firstname;
        }

        public string getLastName(){
            return this.lastName;
        }

    }

    class BankAccount{
        public string BankAccountNumber;
        public string BankAccountOwner;

        public string Credit(){
            return "ValueTask";
        }

        public string Debit(){
            return "value";
        }
    }

    class Program
    {
        static void Main(string[] args ){
            
            const int vat = 20;
            const double percentVat = vat/100D;
            int balance  = 1000;

            Console.WriteLine(balance)

            string textAge  = "-23";
            int convertedText = Convert.ToInt32(textAge);
            int age;
            long bigNumber  = 90000000L;
            decimal floatNumber = 4.09M;
            float myFloat = 1.000001F;
            age =50;
            string name = "Mlu";
            char letter = 'a';
            char letter2 = '\0';
            string textPrecision = "5.00001";
            float precision = Convert.ToSingle(textPrecision);  
            long bigNumber2  = Convert.ToInt32(bigNumber);
            double negative = -55.2D;
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
            Console.WriteLine(negative);
            Customer customer  = new Customer();
            BankAccount bankAc = new BankAccount(); 
        }
    }
}