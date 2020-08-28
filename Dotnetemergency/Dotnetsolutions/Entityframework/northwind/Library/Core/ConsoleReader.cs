using System;

namespace Library.Core
{
    public class ConsoleReader
    {
        public static int ReadNumber(string text){
            int number = 0;
            bool isNumeric = false;
            string input =  "";
            do{
                Console.WriteLine(text);
                input = Console.ReadLine();
                isNumeric = int.TryParse(input, out number);

            }while(!isNumeric);
           
            return number;
        }
    }
}