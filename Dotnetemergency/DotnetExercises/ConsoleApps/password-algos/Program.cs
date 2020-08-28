using System;
using BusinessLogic.Application;

namespace password
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 2){
                Console.WriteLine("Plz use 2 arguments \n argument 1: password \n argument 2: algorithm [simple|ascii])");
                return;
            }

            string password  = args[0];
            string algo = args[1];
            
            PasswordApp app = new PasswordApp();
            string newPassword = app.run(password, algo);

            if(newPassword == null){
                Console.WriteLine("Error");
                return;    
            }
            Console.WriteLine("generated password: " + newPassword);
        }
    }
}
