using System;
using BusinessLogic.Application;

namespace math_vkv
{
    class Program
    {

        static void Main(string[] args)
        {
            
            int a = ReadNumber("A:");
            int b = ReadNumber("B:");
            int c = ReadNumber("C:");

            MathApp app = new MathApp();
            Console.WriteLine(app.Vkv(a,b,c));
        }

        private static int ReadNumber(string text){
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
