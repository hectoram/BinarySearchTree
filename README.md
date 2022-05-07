# Binary Search Tree
## Usage

Create new instance of class

```
var binarySearchTree = new BinarySearchTree<int>();
```

## Supported Data Types
All data types that implement IComparable can be used   

## Using Custom Classes
Implement IComparable
```
public class Car : IComparable
{
    public int Year { get; set; }
    public string Model { get; set; }
        
    public int CompareTo(object? other)
    {
        // Set equality conditions here
    }
}
```

Suggested to override ToString()
```
public override string ToString()
{
    return $"My Custom String";
}
```