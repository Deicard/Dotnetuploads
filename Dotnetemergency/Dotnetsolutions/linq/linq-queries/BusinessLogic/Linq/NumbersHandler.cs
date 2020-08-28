using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;


namespace BusinessLogic.Linq
{
     
     class NumbersHandler{
          private List<int> numbers = new List<int> { 20, 35, 17, 105, 90 };

          /*
          ==> 20
          ==> 35
          ==> 105
          ==> 90
          */
          public void DivisibleBy(int number){
               var results = numbers.Where(n => n % number == 0);

               foreach(var result in results){
                    Console.WriteLine($"==> {result}");
               }
          }
          /*
          ==> 20
          ==> 35
          ==> 90
          ==> 105
          */
          public void DivisibleByAndOrderedAsc(int number){
               var results = numbers.Where(n => n % number == 0).OrderBy(n => n);

               foreach(var result in results){
                    Console.WriteLine($"==> {result}");
               }
          }
          /*
          ==> 105
          */
          public void BiggestNumber(){
               var result = numbers.Max(n => n);
               Console.WriteLine($"==> {result}");
          }

          /*
          ==> 105
          */
          public void SecondLastNumber(){
               var results = numbers.Skip(numbers.Count - 2).Take(1);
               foreach(var result in results){
                    Console.WriteLine($"==> {result}");
               }
          }

          /*
          ==> 90
          */
          public void SecondLargest(){
               var results = numbers.OrderBy(n => n).Skip(numbers.Count - 2).Take(1);
               foreach(var result in results){
                    Console.WriteLine($"==> {result}");
               }
          }
     }
}