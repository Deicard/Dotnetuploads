using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
//using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BusinessLogic.Linq;

// dotnet add package Newtonsoft.Json
// https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/supported-and-unsupported-linq-methods-linq-to-entities
namespace linq_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            runDemoHandler();
           //runNumbersHandler();
           //runStudentHandler();
           //runCardHandler();
        }

        private static void runDemoHandler(){
            DemoHandler handler = new DemoHandler();
            //handler.Demo1();
            //handler.Demo2();
            //handler.Demo3();
            handler.Demo4();
        }

        private static void runNumbersHandler(){
            NumbersHandler handler = new NumbersHandler();
            //handler.DivisibleBy(5);
            //handler.DivisibleByAndOrderedAsc(5);
            //handler.BiggestNumber();
            //handler.SecondLastNumber();
            //handler.SecondLargest();
        }

        private static void runCardHandler(){
            CardHandler handler = new CardHandler();
           //handler.CountCards();
           //handler.CardWithNumber(350);
           //handler.CardsStartingWith("A");
           //handler.CardsStartingWithUnique("A");
           //handler.allCreatureCardsWithRarity("Rare");
           //handler.allPosibleTypes();
           //handler.TranslationsOrderByNumberTop(3);
           //handler.InPrintings("USG");
        }

        private static void runStudentHandler(){
            StudentHandler handler = new StudentHandler();
            //handler.StudentOrderByFirstName();
            //handler.StartsWithSameCharInFirstNameAndLastName();
            //handler.AverageAgeFemaleStudents();
            //handler.StudentLargestCodeByFormula();

        }
    }
}
