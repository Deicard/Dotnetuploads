# DOTNET C

## DATA TYPES

```csharp
int // -2,147,483,648 to 2,147,483,647
long // -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
float // ±1.5e−45 to ±3.4e38, 7 precision
double // ±5.0e−324 to ±1.7e308, 15-16 precision
decimal // Financial datatype
string // text
char // character
bool // true or false
```

## VARIABLE DECLARATION

```csharp
int number = 0;
cont int number = 0; // constant
```

## VAR KEYWORD

```csharp
// The compiler automatically infers the type.
var number = 5;
/**
Variable persons is of type List<Person> assuming GetListOfPersons()
returns a List<Person>;
**/
var persons = GetListOfPersons();
// Using keyword var in a for-each loop.
foreach (var activeOrder in activeOrders) { … }
```

## Parse to int

```csharp
int result = Int32.Parse(input);
```

```csharp
int number = 0;
bool  isNumeric = int.TryParse(input, out number);

if(isNumeric){
    sum += number;
}else{
    Console.WriteLine("Sorry that was not an integer");
}
```

## IF ELSE STRUCTURE

```csharp
if (person.Age < 30)
{
    Console.WriteLine("The person is younger than 30");
}
else
{
    Console.WriteLine("The person is 30 or older.");
}
```

## WHILE LOOP

```csharp
int i = 0;
while (i < 10)
{
    Console.WriteLine(i);
}
```

## FOR LOOP

```csharp
for(int i = 0; i < 10; i++)
{
    statements;
}
```

## FOR EACH

```csharp
// generic collection
List<Person> persons = new List<Person>();
persons.ForEach(person =>
{
    Console.WriteLine(person.Name);
});
```

## FOR EACH ALTERNATIVE

```csharp
foreach (var activeOrder in activeOrders) { … }
```

## SWITCH CASE

```csharp
switch(algo)
{
    case "simple":
        algoritme = new Simple();
        break;

    case "ascii":
        algoritme = new Ascii();
        break;

    default:
        break;
}
```

## DICTIONARIES

**Namespace:** System.Collections.Generic

```csharp
// init a dictionary
Dictionary openWith = new Dictionary<string, string>();

// add to dictionary
openWith.Add("txt", "notepad.exe");
openWith.Add("bmp", "paint.exe");
openWith.Add("dib", "paint.exe");
openWith.Add("rtf", "wordpad.exe");

// remove an entry
openWith.Remove("rtf");

// remove all
openWith.Clear;

// access a key value pair
string app = openWith["txt"];

// check if key exists
openWith.ContainsKey("rtf");

// check if value exists
openWith.ContainsValue("paint.exe");

//  number of entries in dictionary
int count = opentWith.Count

// loop dictionary
foreach(var item in opentWith)
{
    Console.WriteLine($"{item.Key}: {item.Value}");
}
```

## INHERITANCE AND OVERRIDING

```csharp
abstract class Person
{
    public virtual void Study()
    {
        // code here
    }
}

class Student: Person
{
    public override void Study()
    {
        // more code here
    }
}
```

## CLASS IMPLEMENTS INTERFACE

```csharp
// IPerson.cs
using System;
namespace Person
{
    interface IPerson
    {

    }
}

// Person.cs
using System;

namespace Person
{
    class Teacher: IPerson
    {
        private string name = null;
        public string giveFullName()
        {
            return this.name;
        }
    }
}
```

## GETTERS AND SETTERS

```csharp
using System;
namespace BusinessLogic
{
    class Fraction
    {
        public Fraction(){}

        public Fraction(int numerator, int denominator){
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public int Numerator{ get; set;}

        public int Denominator{ get; set;}

        // -- overriding a method
        public override string ToString(){
            return $"{this.Numerator}/{this.Denominator}";
        }
    }
}
```

## INITIALIZING AN OBJECT

```csharp
// -- constructor
Fraction f = new Fraction(12,5);
Console.WriteLine($"Hello {f}");

// -- object initializer
Fraction f2 = new Fraction{
    Numerator = 15,
    Denominator = 7
};
Console.WriteLine($"Hello {f2}");
```

## CONSOLE APPLICATION

```csharp
\\ Write to the console
Console.WriteLine("Hello world");

\\ Read from the console
string input = Console.ReadLine();
```

## CLASS TEMPLATE

```csharp
using System;
namespace <Namespace>
{
    class <ClassName>
    {

    }
}
```

## INTERFACE TEMPLATE

```csharp
using System;
namespace <Namespace>
{
    interface <InterfaceName>
    {

    }
}
```
