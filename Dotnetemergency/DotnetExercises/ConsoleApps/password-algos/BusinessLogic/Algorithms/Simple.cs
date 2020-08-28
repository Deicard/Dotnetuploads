using System;

namespace BusinessLogic.Algorithms {
    class Simple: IAlgo{
        public string generate(string password){
            return password  + "1234";
        }
    }
}