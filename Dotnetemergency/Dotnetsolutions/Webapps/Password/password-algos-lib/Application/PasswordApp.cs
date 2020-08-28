using System;
using password_algos_lib.Algorithms;

namespace password_algos_lib.Application {
    public class PasswordApp{

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