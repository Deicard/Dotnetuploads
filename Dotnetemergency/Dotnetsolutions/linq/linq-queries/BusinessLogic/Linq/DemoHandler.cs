using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;


namespace BusinessLogic.Linq
{
    class DemoHandler{
        private int[] numbers = { 10, 9, 8, 7, 6 };
        private string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

        public void Demo1(){
            // first
            var result1 = numbers.First();
            Console.WriteLine($"==> {result1}");

            Console.WriteLine("-----------------");

            // smallest
            var result2= numbers.OrderBy(n => n).First();
            Console.WriteLine($"==> {result2}");

            Console.WriteLine("-----------------");

            // contains
            var result3 = numbers.Contains(9);
            Console.WriteLine($"==> {result3}");

            Console.WriteLine("-----------------");

            // more then 8
            var result4 = numbers.Where(n => n > 8);
            foreach(var item in result4){
                Console.WriteLine($"==> {item}");
            }

            Console.WriteLine("-----------------");

            // multiply by 10
            var result5 = numbers.Select(n => n  * 10);
            foreach(var item in result5){
                Console.WriteLine($"==> {item}");
            }

            Console.WriteLine("-----------------");
        }

        public void Demo2(){
            // Chaining
            IEnumerable<string> filtered   = names.Where      (n => n.Contains ("a"));
            IEnumerable<string> sorted     = filtered.OrderBy (n => n.Length);
            IEnumerable<string> finalQuery = sorted.Select    (n => n.ToUpper());


            foreach(var item in filtered){
                Console.WriteLine($"==> {item}");
            }
            Console.WriteLine("-----------------");

            foreach(var item in sorted){
                Console.WriteLine($"==> {item}");
            }
            Console.WriteLine("-----------------");
            foreach(var item in finalQuery){
                Console.WriteLine($"==> {item}");
                
            }
            Console.WriteLine("-----------------");
            
        }

        public void Demo3(){
            // strip vowels
            var results = names
                .Select(n => n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", ""))
                .Where(n => n.Length > 2)
                .OrderBy(n => n);

            foreach(var item in results){
                Console.WriteLine($"==> {item}");
            }
            
            Console.WriteLine("-----------------");

            // mind the sequence!
            var results2 = names
                .Where(n => n.Length > 2)
                .Select(n => n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", ""))
                .OrderBy(n => n);

            foreach(var item in results2){
                Console.WriteLine($"==> {item}");
            }
        }

        public void Demo4(){
            // Anonymous projection 
            var results = names
			 .Select( n => new
				 {
					 Original = n,
					 Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "")
				 }
			  );

            foreach(var item in results){
                Console.WriteLine($"==> {item}");
            }

            Console.WriteLine("-----------------");


            // Concrete projection 

            var results2 = names
			 .Select( n => new Names
				 {
					 Original = n,
					 Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "")
				 }
			  );

            foreach(var item in results){
                Console.WriteLine($"==> {item}");
            }

        }
    }

    class Names
    {
        public string Original;      // Original name
        public string Vowelless;     // Vowel-stripped name
    }
}