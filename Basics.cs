class Basics{

/* 
  This is a long comment 
  that spans multiple lines
  just to prove that it can
  be done.

  Never trust comments!
  Given the comments, you might be able to figure out what the code is doing 
  (assuming the comments accurately describe the current state and were updated as the code was updated).
  Do not unnecessarily explain the obvious functionality of individual lines of code. These are considered low-quality comments.


  What is an expression?
  An expression is any combination of values (literal or variable), operators, and methods that return a single value. 
  A statement is a complete instruction in C#, and statements are composed of one or more expressions.
*/

    public void conversionBasics(){

        // Would attempting to change the value's data type result in 
        //  i.  a loss of information?
        //      The term "narrowing conversion" means that you're attempting to convert a value from a data type that can hold more information to a data type that can hold less information. 
        //      In this case, you'll need to perform a cast. Casting is an instruction to the C# compiler that you know precision may be lost, but you're willing to accept it.
        //  ii. an exception at runtime?

        // To perform data conversion, you can use one of several techniques:
        //  * Use a helper method on the data type
        //        Most of the numeric data types have a Parse() method,
        //  * Use a helper method on the variable
        //        Every data type variable has a ToString() method. 
        //  * Use the Convert class' methods

        byte myByte = 100;
        int myInt = myByte;     // Since any byte value can easily fit inside of an int, the compiler implicitly converts.

        int x = 333;
        //byte bx = x;          // Cannot implicitly convert type 'int' to 'byte'
        byte bx = (byte)x;      // Narrowing conversion, we'll need to perform a cast.

        Console.WriteLine($"byte: {myByte} int: {myInt}");
        Console.WriteLine($"int: {x} byte: {bx}");          // int: 333 byte: 77 !!!


        int firstNum = 5;
        int secondNum = 7;
        string message = firstNum.ToString() + secondNum.ToString();
        Console.WriteLine(message);     // 57

        string firstStr = "5";
        string secondStr = "7";
        int sum = int.Parse(firstStr) + int.Parse(secondStr);
        int result = Convert.ToInt32(firstStr) + Convert.ToInt32(secondStr);        // Convert class' methods
        Console.WriteLine($"int.Parse(): {sum} Convert.ToInt32(): {result}");         // 12

    }
    public void variable_basics(){

        // Choose a descriptive name for variables that describe their purpose and intent.
        // The code you write should communicate your intent to both the compiler and to other developers who may read your code. 
        // Because you're likely to be the one reading your own code, sometimes months after you originally wrote it, you should focus on writing code that can be easily understood. 
        // Write code that is easily readable and understandable.

        // Variable scope is the visibility of the variable to the other code in your application. 
        // A locally scoped variable is only accessible inside of the code block in which it's defined.
        
        string firstName = "Bob";
        int widgetsSold = 7;

        // What happens if we try to use the + symbol with both string and int values?
        // Both string concatenation and addition use the plus + symbol. 
        // This is called overloading an operator, and the compiler infers the proper use based on the data types it's operating on.
        Console.WriteLine(firstName + " sold " + widgetsSold + 7 + " widgets.");    // Bob sold 77 widgets.
        Console.WriteLine(firstName + " sold " + (widgetsSold + 7) + " widgets.");  // Bob sold 14 widgets.


        int sum = 7 + 5;
        int quotient = 5 / 10;  // 0
        // The remainder operator % tells you the remainder of int division.
        // When the modulus is 0, that means the dividend is divisible by the divisor.
        int remainder = 7 % 5;

        Console.WriteLine("Sum: " + sum);
        Console.WriteLine($"Quotient: {quotient}"); 
        Console.WriteLine("Remainder of 7 / 5 : " + remainder);

        int fahrenheit = 94;
        float floatCelc = (fahrenheit - 32f) * (5f / 9f);
        decimal decimalCelc = (fahrenheit - 32m) * (5m / 9m);   // For money, always decimal. It's why it was created.
        Console.WriteLine($"[float] The temparature is {floatCelc} Celcius");   //34.44445 
        Console.WriteLine($"[decimal] The temparature is {decimalCelc} Celcius"); // 34.444444444444444444444444447

        // Operators like +=, -=, *=, ++, and -- are known as compound assignment operators, 
        // because they compound some operation in addition to assigning the result to the variable. 
        int value = 0;
        value += 5;
        value++;
        Console.WriteLine("First: " + value);       // First: 6
        Console.WriteLine("Second: " + value++);    // Second: 6
        Console.WriteLine("Third: " + value);       // Third: 7




        // Some methods don't rely on the current state of the application to work properly. 
        // In other words, stateless methods are implemented so that they can work without referencing or changing any values already stored in memory. 
        // Stateless methods are also known as static methods.
        // Other methods, however, must have access to the state of the application to work properly. 
        // In other words, stateful methods are built in such a way that they rely on values stored in memory by previous lines of code that have already executed, or they modify the state of the application by updating values or storing new values in memory. 
        // Stateful (instance) methods keep track of their state in fields, which are variables defined on the class. 
        // Each new instance of the class gets its own copy of those fields in which to store state.
        // A single class can support both stateful and stateless methods. 
        // However, when you need to call stateful methods, you must first create an instance of the class so that the method can access state.

        Random rand = new Random();
        int roll = rand.Next(1,7);
        Console.WriteLine("Dice: "+roll);

        // The new operator does several important things:
        //   * It first requests an address in the computer's memory large enough to store a new object based on the Random class.
        //   * It creates the new object and stores it at the memory address.
        //   * It returns the memory address so that it can be saved in the dice variable.

        // Why is the Next() method stateful?
        // Couldn't the .NET Class Library designers figure out a way to generate a random number without requiring state? And what exactly is being stored or referenced by the Next() method?
        // These are fair questions. To create the illusion of randomness, the developers of the Next() method decided to capture the date and time down to the fraction of a millisecond and use that to seed an algorithm that produces a different number each time. 
        // While not entirely random, it suffices for most applications. The state that is captured and maintained through the life time of the rand object is the seed value. Each subsequent call to the Next() method is rerunning the algorithm, but ensures that the seed changes so that the same value isn't (necessarily) returned.

        // Overloaded methods
        // An overloaded method is defined with multiple method signatures. 
        // Many methods in the .NET Class Library have overloaded method signatures.

        int number = 7;
        string text = "seven";

        Console.WriteLine(number);      // version 1
        Console.WriteLine(text);        // version 2

        Random dice = new Random();
        int roll1 = dice.Next();            // version 1
        int roll2 = dice.Next(101);         // version 2
        int roll3 = dice.Next(50, 101);     // version 3

        Console.WriteLine($"First roll: {roll1}");      
        Console.WriteLine($"Second roll: {roll2}");     
        Console.WriteLine($"Third roll: {roll3}"); 

    }

    public void arrayBasics(){

        // imagine a single variable that can hold many values.
        // An array is a sequence of individual data elements accessible through a single variable name. (multiple values of the same data type.)
        // You use a zero-based numeric index to access each element of an array. 


        // you can initialize a new array at the time you declare it using a special syntax featuring curly braces.
        string[] IDs = { "A123", "B456", "C789" };

        // Declare a new array
        string[] fraudulentOrderIDs = new string[3];

        // Assign values to elements on an array
        fraudulentOrderIDs[0] = "A123";
        fraudulentOrderIDs[1] = "B456";
        fraudulentOrderIDs[2] = "C789";

        // Retrieve values of an array
        Console.WriteLine($"First: {fraudulentOrderIDs[0]}");

        // Reassign the value of an array
        fraudulentOrderIDs[0] = "F000";
        Console.WriteLine($"Reassign First: {fraudulentOrderIDs[0]}");

        // To determine the size of an array, you can use the Length property
        Console.WriteLine($"There are {fraudulentOrderIDs.Length} fraudulent orders to process.");

        // Looping through an array using foreach
        string[] names = { "Bob", "Conrad", "Grant" };
        foreach (string name in names){
            Console.WriteLine(name);
        }


        // The Array class has methods that can manipulate an array.
        string[] pallets = { "B14", "A11", "B12", "A13" };
        Array.Sort(pallets);
        Array.ForEach(pallets, Console.WriteLine);

        Array.Reverse(pallets);
        Array.ForEach(pallets, Console.WriteLine);

        Array.Resize(ref pallets, 6);
        Console.WriteLine($"Resizing 6 ... count: {pallets.Length}");

        string value = "abc123";
        char[] valueArray = value.ToCharArray();


        // Question: 
        // Parse Order IDs out of a string containing a sequence of incoming orders (the orderStream). Then, you'll print each Order ID that starts with the letter 'B'.
        string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";

        string[] orders = orderStream.Split(',');
        foreach (string order in orders){
            if(!order.StartsWith("B")) continue;
            Console.WriteLine(order);
        }
    }


    public void formattingBasics(){

        // String interpolation is a newer technique that simplifies composite formatting. 
        string first = "Hello";
        string second = "World";
        Console.WriteLine($"{first} {second}!");

        int invoiceNumber = 1201;
        decimal productMeasurement = 25.4568m;
        decimal subtotal = 2750.00m;
        decimal taxPercentage = .15825m;
        decimal total = 3185.19m;

        Console.WriteLine();
        Console.WriteLine("Details".PadLeft(14, '*'));      // The PadLeft() method will add blank spaces (or specified chars) to the left-hand side of the string so that the total number of characters equals the argument.
        Console.WriteLine($"Invoice Number: {invoiceNumber}");
        Console.WriteLine($"   Measurement: {productMeasurement:N3} mg");
        Console.WriteLine($"     Sub Total: {subtotal:C}");
        Console.WriteLine($"           Tax: {taxPercentage:P2}");
        Console.WriteLine($"     Total Due: {total:C}");        // ₺3.185,19

        string formatted_m = $"{total:C}".PadLeft(12, '+');       // +++₺3.185,19
        Console.WriteLine(formatted_m);
    }

    public void stringBasics(){

        // before checking strings for equality, 
        // remove remove leading or trailing blank spaces and make sure both strings are all upper-case or all lower-case
        string value1 = " a";
        string value2 = "A ";
        Console.WriteLine(value1.Trim().ToLower() == value2.Trim().ToLower());

        // Word reversal challenge BEGIN
        string pangram = "The quick brown fox jumps over the lazy dog";

        string[] words = pangram.Split(' ');

        string message = "";
        foreach (var word in words){

            char[] chars = word.ToCharArray();
            Array.Reverse(chars);
            message += new string(chars) + ' ';
        }

        Console.WriteLine(message);
        //  Word reversal challenge END

    }
    public static char letterOfScore(double score){

        char grade = '-';

        // If you realize you only have one line of code in a code block, you can remove the curly braces and white space.
        // if(score >= 90){
        //     grade = 'A';
        // } 

        if(score >= 90) grade = 'A';
        else if(score >= 80) grade = 'B';
        else if(score >= 70) grade = 'C';
        else if(score >= 60) grade = 'D';
        else grade = 'F';

        return grade;

    }

    // The switch is best used when you have a single value you want to match against many possible values
    public static string getEmployeeTitle(int employeeLevel){
        string title = "Employee";
        switch (employeeLevel)
        {
            case 100:
                title = "Junior Associate";
                break;
            case 200:
                title = "Senior Associate";
                break;
            case 300:   //  use fall through
            case 400:
                title = "Manager";
                break;
            case 500:   //  use fall through
            case 600:
                title = "Senior Manager";
                break;
            default:
                title = "Employee";
                break;

        } 

        return title;

    }

    public static string SKU(string SKUCode){
        // SKU = Stock Keeping Unit
        //string sku = "01-MN-L";

        string[] features = SKUCode.Split('-');

        string type = "" ;
        string color = "";
        string size = "";

        switch (features[0])
        {
            case "01":
                type = "Sweat shirt";
                break;
            case "02":
                type = "T-Shirt";
                break;
            case "03":
                type = "Sweat pants";
                break;
            default:
                type = "Other";
                break;
        }

        switch (features[1]) {

            case "BL":
                color = "Black";
                break;
            case "MN":
                color = "Maroon";
                break;
            default:
                color = "White";
                break;
        }

        switch (features[2]){
            
            case "S":
                size = "Small";
                break;
            case "M":
                size = "Medium";
                break;
            case  "L":
                size = "Large";
                break;
            default:
                size = "One Size Fits All";
                break;
        }

        
        string title =  $"Product: {size} {color} {type}";
        Console.WriteLine(title);
        return title;
    }
    public static int min_of_three(int x, int y, int z){

        int min = x;

        if(y < min){
            min = y;
        }
        if(z < min){
            min = z;
        }

        return min;

        // The logical AND operator:    && 
        // The logical OR operator:     || 
    }

    // The for statement iterates through a code block a specific number of times.
    public static void drawSquare(int size){

        for(int i = 0; i < size; i++){
            for (int j = 0; j < size; j++){
                Console.Write("*");
            }
            Console.WriteLine("");
        }
    }

    public static string coinFlip(){

        Random rand = new Random();
        int roll = rand.Next(0,2);

        // The conditional operator ?:, commonly known as the ternary conditional operator, 
        // evaluates a Boolean expression, and returns the result of evaluating one of two expressions, 
        // depending on whether the Boolean expression evaluates to true or false.
        // Use the conditional operator when you need to add branching logic inline.
        return (roll == 0) ? "heads" : "tails";
    }

    public static bool isEven(int number){
        return number % 2 == 0;
    }
}