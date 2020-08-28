using System;

namespace sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hey, I will calculate the sum of the given integers as long as the input is a number!");

            int sum = 0;
            bool isNumeric = false;
            string input = "";
            do{
                Console.WriteLine("Give a number plz:");
                input = Console.ReadLine();

                int number = 0;
                isNumeric = int.TryParse(input, out number);

                if(isNumeric){
                    sum += number;
                }else if(input != "stop"){
                    Console.WriteLine("Sorry that was not an integer");
                }

            }while(input != "stop");

            Console.WriteLine("The sum is {0}", sum);
        }
    }
}
