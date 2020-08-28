using System;

namespace password_algos_lib.Algorithms {
    public class AlgorithmFactory{
        private string algo = null;

        public AlgorithmFactory(string algo){
            this.algo = algo;
        }

        public IAlgo create(){
            IAlgo algoritme = null;

            switch(this.algo){
                case "simple":
                    algoritme = new Simple();
                    break; 

                case "ascii":
                    algoritme = new Ascii();
                    break;
                case "shift":
                    algoritme = new Shift();
                    break;
                default:
                    break;
            }

            if(algoritme == null){
                return null;
            }

            return algoritme;
        }
    }
}