## Git
# Command Shell (Bash)
The working directory (aka, folder) </br>
-pwd -- print working directory </br>
-cd -- changes the current working directory </br>
Absolute paths are like hardcoding the file location, where as relative paths let us go "up" or down </br>
ex.   ..\.. </br>
-mkdir -- Make directory </br>
-rmdir -- remove directory </br>
/ == root directory (also maybe \ in windows, / in UNIX) </br>
~ user's home directory </br>
.. the current directory's parent </br>
-ls -- list contents of directory </br>
touch filename.txt - creates an empty file (updates the mod date of an existing file) </br>
rm filename.txt - remove/delete a file </br>
mv source.txt target.txt - move (rename) a file </br>
cp source.txt target.txt - copy a file </br>

To recursively delete folders and files rm -r foldername (careful) 

• Git clone • Git pull • Git add • Git commit • (git pull & git commit) • Git push

Three tree architecture 

1. The working Directory (your local folder tree)
2. The Staging Index (This is a place that collects changes to be committed to the repo)
3. The Repo( Or Head. This is where committed code is stored for posterity). T
4. This is all local, you can then push this to GitHub or Bitbucket

## Variables and Data Types

Variables are a name for a location in memory </br>
Must be declared before it is used </br>
Type must be specified </br>
Declared only once; can be assigned multiple times</br>

    //Declare/Allocate, then assign
    int age;
    age = 25;
    //Declare, allocate and assign
    int height = 71;
    //Value cannot be changed
    const int daysInWeek = 7;
Value types vs Reference type </br>
Value types generally take up a small amount of memory </br>
Size can always be determined at compile time </br>
Reference types have the potential to require more space </br>
Compiler may not be able to determine the amount of space needed (done at runtime) </br>
ex. String</br>
Implicit conversion is done by the compiler , type-safe, smaller to larger values 
Explicit conversion must be specified by the programmer, this is called casting
Methods aka functions aka subroutines </br>
    Method header
    access modifier (public, private etc), method return type (any data type or void) , method parameters/arguments
Arrays are a set of related values , all the same type , stored contiguously in memory , referenced by a single variable name </br>
Array is a reference type, the array variable points to the location of the start of the array </br>
The items in the array may be reference or value types, they are called elements, and can be accessed by an index  (int) </br>

    //Declare a place to hold the array
    int[] scores;
    //Allocate the storage for scores
    scores = new int[5]
    //Assign the values
    scores[0] = 92;
    scored[1] = 78;
    etc..
    or in one line 
    int[] scores = new int[5] {92, 78, 69, 96, 88};
Length property tells us how many indexes

## Loops 
foreach</br>
for</br>
while</br>
break;</br>
Transfers control to the statement following the loops and exits the loop </br>
continue;</br>
Transfers control to the top of the loop for the next for the next iteration, skips only a portion of the current iteration</br>
return;</br>
exits the method and exits the loop</br>
Parsing a number to a string</br>

    int numAsInt = 123;
    string intAsString = string.Parse(numAsInt);

## Abstraction
Preserving information that is relevant in a given context and forgetting information that is relevant </br>
I think of the leap from C to C#, where instead of using an array of characters we can just call a string, which is still effectively that, but now we don't have to worry about the size of the array or declaring it, however we can still index the string as if it was.
Modeling is abstraction. It's one of the pillars of OOP. (Really though it's a pillar of all programming)</br>

## OOP
Objects are a further level of abstraction</br>
Combining data and behavior into an abstraction of a real world thing.</br>
Classes and data types are the same thing essentially in C# </br>
Class is just another word for data type, we still declare, allocate and assign</br>


Stack is fixed memory allocation (known at compile time), created when a method is invoked , destroyed when method exits, fast access</br>
Runtime maintains a stack as your program runs. C# value types are stored here.</br>

Heap is dynamic memory allocation (at run-time). Global in scope. Slower access as it can fragment. Reference types are allocated (new'd) here, and their address is stored in the Stack. 
## Common String Methods
-length (property)</br>
-substring</br>
-Contains</br>
-StartsWith/EndsWith</br>
-IndexOf</br>
-Replace</br>
-ToUpper/ToLower</br>
-Split/Join</br>
-Trim</br>

## List
Array on steroids, can shrink and grow.

    List<string> daysOfWeek;</br>
    //Allocate and initialize</br>
    List<string> daysOfWeek = new List<string>();
Access with an index just like an array</br>
To add elements 

    listName.Add(elementToAdd);
    listName.Insert(index, elementToAdd);
    listName.AddRange(elementsToAdd []); <-- adds another collection
    listName.Remove(elementToRemove); <-- Removes first occurrence 
    listName.Contains(element); <-- returns bool
    listName.IndexOf(element); <-- returns int
    listName.ToArray() <-- returns array
    listName.Sort() <-- sorts the list in place

Stack</br>
Last-in , First Out, </br>
Undo, driveway parking , browser back</br>
push, pop, peek</br>
comes out in the reverse order we put them in, no index access</br>
Queue </br>
First In , First Out</br>
store checkout , print queue</br>
Enqueue , Dequeue, Peek </br>
Comes out in the order we put them in </br>

Dictionary</br>
Associative array, Key and Value, they don't have to be the same type

    Dictionary <string, string> stateCodes = new Dictionary<string, string>();
    {
        {"AL", "Alabama"},
        {"AK", "Alaska"},
        {"AZ", "Arizona"},
    }
    If (stateCodes.Contains("CO"))
    {
        stateCodes["CO"] = "Colorado";
    }
    stateCodes.Remove("CO"); <--- would remove the key and the value 

# Intro to Classes

Data describes it (properties)</br>
Behavior, what it can do, verbs (methods)</br>

    public class Car //defining a class
        {
            public string Make {get; set;} //automatic property
            public string Condition {get; } //derived property
        }

For class and for properties and variables</br>
Users of the object can "see" public</br>
Only class itself can access private</br>
We can have a public get with a private set.</br>
Class constructors are a special method that is invoked as the object is instantiated.</br>
Same name as the class with no return type. If you don't define one , a "default constructor" exists automatically.</br>

Method Overloading </br>
Change behavior of a method based on how its called </br>
Define another method </br>
with the same name</br>
with a different set of parameters as defined by their data type and order.</br>
You have to have a different set of parameters, must have the same, can change return type, can change access modifier</br>
    
    
    
    virtual public string DoMonthlyProcessing()
        {
            return "";
        }

      public override string DoMonthlyProcessing()
        {
            decimal totalFees = (numberOfChecksWritten * TransactionFee) + overDraftFees;
            Balance -= totalFees;

            numberOfChecksWritten = 0;
            overDraftFees = 0;

            return $"Checking was charged {totalFees:C} in transaction / overdraft fees.";


    