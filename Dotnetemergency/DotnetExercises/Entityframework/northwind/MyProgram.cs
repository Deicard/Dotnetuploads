using System;
using Library.Applications;

namespace northwind_app
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome in the Category Application");
            commandlist();
            string input = "";
            
            CategoryApp app = new CategoryApp();
            do{
                input = Console.ReadLine();
                Console.WriteLine("");
                switch(input){
                    case "help":
                        commandlist();
                        Console.WriteLine("");
                        break;
                    case "category:list":
                        app.ShowList();
                        Console.WriteLine("");
                        break;
                    case "category:add":
                        app.Add();
                        Console.WriteLine("");
                        break;
                    case "category:show":
                        app.Show();
                        Console.WriteLine("");
                        break;
                    case "category:update":
                        app.Update();
                        Console.WriteLine("");
                        break;
                    case "category:delete":
                        app.Delete();
                        Console.WriteLine("");
                        break;
                    default:
                        Console.WriteLine("Command not found in the list. Use help to show the list.");
                        Console.WriteLine("");
                        break;
                }
            }while(input != "stop");
            Console.WriteLine("Thank you for using this application!");
            Console.WriteLine("");
        }

        static void commandlist(){
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Commandlist");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("stop                  exit application");
            Console.WriteLine("help                  show commandlist");
            Console.WriteLine("------------------------------------------------");
            CategoryApp.ShowCommandList();
            Console.WriteLine("------------------------------------------------");
        }
    }
}
