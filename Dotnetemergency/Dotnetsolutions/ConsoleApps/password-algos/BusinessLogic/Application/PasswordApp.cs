using System;
using BusinessLogic.Algorithms;

namespace BusinessLogic.Application {
    class PasswordApp{

        public string run(string password, string algo){
            AlgorithmFactory factory = new AlgorithmFactory(algo);
            IAlgo algorithm = factory.create();

            if(algorithm == null){
                return null;    
            }

            string newPassword = algorithm.generate(password);
            return newPassword;
        }
    }
}