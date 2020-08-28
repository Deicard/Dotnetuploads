using System;

namespace BusinessLogic.Algorithms {
    class Ascii: IAlgo{
        public string generate(string password){

            int sum = getAsciiSum(password);
            return reverse(password) + reverse(sum.ToString());
        }

        private int getAsciiSum(string password){
            int sum = 0;
            foreach(char letter in password){
                int code = (int) letter;
                sum += code;
            }

            return sum;
        }

        private string reverse(string text){
            char[] charArray = text.ToCharArray();
            Array.Reverse( charArray );
            return new string( charArray );
        }

    }
}