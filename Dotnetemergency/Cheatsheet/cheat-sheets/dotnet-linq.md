# LINQ

## Namespaces
```csharp
using System.Collections.Generic; // IEnumerable and generic collections
using System.Linq; // linq extension methods
```

## Chaining Where, OrderBy, Select

```csharp
new[] { 11, 5, 17, 7, 13 }
.Where(n => n > 10)
.OrderBy(n => n)
.Select(n => n * 10);
```

## OrderBy

```csharp
List<Product> Products = new List<Product>{
		new Product {
			Id = 1,
			Name = "Apple Mac Book Pro",
			Price = 3299
		},
		new Product {
			Id = 2,
			Name = "Deel XPS 15",
			Price = 1649
		}
	};
	
	Products.OrderBy(product => product.Price); // price, ASC
	Products.OrderByDescending(product => product.Price); // price, DESC
	Products.OrderBy(product => product.Id); // id, ASC
```
## Basic operators

```csharp
int[] numbers = { 10, 9, 8, 7, 6 };
```
### Element operators
```csharp

var result = numbers.First(); // 10
var result = numbers.Last(); // 6

var result = numbers.ElementAt (1); // 9

var result = numbers.OrderBy (n => n).First(); // 6
var result = numbers.OrderBy (n => n).Skip(1).First(); // 7
```
```csharp
var names = new[] { "Tom", "Dick", "Harry", "Mary", "Jay" };
```
```csharp
var result = names.where(n => n.StartsWith("M")); // Mary
```
### Sequence operators
```csharp
var result = numbers.Take(3); // 10,9,8
var result = numbers.Skip(3); // 7,6
var result = numbers.Reverse(); // 6,7,8,9,10
```
### Aggregation operators
```csharp
var result = numbers.Count(); // 5
var result = numbers.Min(); // 6
```

### Quantifiers
```csharp
var result = numbers.Contains (9); // Contains 9 as element? True
var result = numbers.Any(); // Has elements? True
var result = numbers.Any (n => n % 2 != 0); // Has odd numbered elements? True

```

### Merge operators
```csharp

int[] seq1 = { 1, 2, 3 };
int[] seq2 = { 3, 4, 5 };
var result = seq1.Concat (seq2); // 1,2,3,3,4,5
var result = seq1.Union (seq2); // 1,2,3,4,5


int[] s1 = { 1, 2, 3, 20, 15 }; //First sequence
int[] s2 = { 3, 2, 8, 10 }; //Second sequence						
var result = s1.Zip(s2, (a, b) => a * b); //dot product of sequence: 3,4,24,200


int[] values = { 1, 2, 3 };
int[] weights = { 3, 2, 8 };
var result = values.Zip(weights, (value, weight) => value * weight)
	  .Sum(); // 3+4+24 = 31
```

## Projection
```csharp
var names = new[] { "Tom", "Dick", "Harry", "Mary", "Jay" };
```
### Anonymous projection 
```csharp
var query = names
			 .Select( n => new
				 {
					 Original = n,
					 Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "")
				 }
			  );
			  
/*
[
  {
    Original: Tom,
    Vowelles: Tm    
  }, 
  {
    Original: Dick,
    Vowelles: Dck    
  }, 
  ...
]
*/
```



### Concrete projection 
```csharp
class NameItem
{
	public string Original;      // Original name
	public string Vowelless;     // Vowel-stripped name
}


var names = new[] { "Tom", "Dick", "Harry", "Mary", "Jay" };
	
	// extension mehods
	var temp =
		names
		.Select( n => new NameItem
			{
				Original  = n,
				Vowelless = n.Replace ("a", "").Replace ("e", "").Replace ("i", "").Replace ("o", "").Replace ("u", "")
			}
		);
		
/*
[
  {
    Original: Tom,
    Vowelles: Tm    
  }, 
  {
    Original: Dick,
    Vowelles: Dck    
  }, 
  ...
]
*/
```