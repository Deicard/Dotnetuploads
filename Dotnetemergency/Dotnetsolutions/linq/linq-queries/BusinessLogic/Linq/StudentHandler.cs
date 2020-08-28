using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;


namespace BusinessLogic.Linq
{
    class StudentHandler{
        private List<Student> students = new List<Student> {
							new Student { Id= 1, FirstName = "Freddie", LastName = "Fish", Age = 18 , Sex = "M"},
							new Student { Id= 2, FirstName = "Bill", LastName = "Jones", Age = 21, Sex = "M" },
							new Student { Id= 3, FirstName = "Kitty", LastName = "Cat", Age = 19, Sex = "F" },
							new Student { Id= 4, FirstName = "Suzy", LastName = "Wan", Age = 20, Sex = "F" }
					   };
     

        /*
        ==> Bill Jones
        ==> Freddie Fish
        ==> Kitty Cat
        ==> Suzy Wan
        */
        public void StudentOrderByFirstName(){
            var results = students.OrderBy(n => n.FirstName);

            foreach(var student in results){
                Console.WriteLine($"==> {student.FirstName} {student.LastName}");
            }
        }

        /*
        ==> Freddie Fish
        */
        public void StartsWithSameCharInFirstNameAndLastName(){
            var results = students.Where(s => s.FirstName.Substring(0, 1) == s.LastName.Substring(0, 1));
            
            foreach(var student in results){
                Console.WriteLine($"==> {student.FirstName} {student.LastName}");
            }
        }

        /*
        ==> 19,5
        */
        public void AverageAgeFemaleStudents(){
            var result = students.Where(s => s.Sex == "F").Average(s => s.Age);

            Console.WriteLine($"==> {result}");
        }

        /*
        ==> { Name = Suzy Wan, Code = 21 }


        Formula = id*id + 5
        */
        public void StudentLargestCodeByFormula(){
            var result = students.Select(s => new
            {
                Name = $"{s.FirstName} {s.LastName}",
                Code = Math.Pow(s.Id, 2) + 5
            })
            .OrderBy(s => s.Code).Last();

            Console.WriteLine($"==> {result}");
        }
     }
}