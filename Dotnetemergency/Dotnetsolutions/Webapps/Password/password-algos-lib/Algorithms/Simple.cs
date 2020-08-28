using System;

namespace password_algos_lib.Algorithms {
    public class Simple: IAlgo{
        public string generate(string password){
            return password  + "1234";
        }
    }
}