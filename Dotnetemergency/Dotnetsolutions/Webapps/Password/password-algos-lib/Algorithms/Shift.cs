using System;
using System.Collections.Generic;

namespace password_algos_lib.Algorithms {
    public class Shift: IAlgo{
        private int start  = 97;
        private int stop = 123;
        private int jump = 57;
        private Dictionary<char, char> list = new Dictionary<char, char>();

        public Shift(){
            list.Add('a', '4');
            list.Add('b', '8');
            list.Add('e', '3');
            list.Add('i', '!');
            list.Add('o','0');
        }

        public string generate(string password){
            return shift(password);
        }

        private string shift(string password){

            int end = stop  - start;
            int counter = 0;

            string newPassword  = "";
            foreach(char letter in password){
                int code = (int) letter - start;

                // -- may not below 0
                if(code < 0){
                    code = counter; // that way we do not always have the same value when less then zero
                }//endif

                code += jump;
                code = (code % end) + start;
                newPassword += convertSpecialChar((char) code);
                counter++;

                // variable jumps makes it stronger to decrypt ;)
                jump += (counter*counter);
                jump = (jump % end);
               
            }//endforeach

            return newPassword;
        }

        private char convertSpecialChar(char letter){
            if(list.ContainsKey(letter)){
                letter = list[letter];
            }//endif

            return letter;
        }
    }
}