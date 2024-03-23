// See https://aka.ms/new-console-template for more information
using gt_code_test;


//FIBONACCI
var number = 0;
while (number == 0)
{
    Console.WriteLine("Which n:th fibonacci number do you want?");
    int.TryParse(Console.ReadLine(), out var input);
    number = input;
    try
    {
        Console.WriteLine(FibonacciGenerator.GetNthNumberInFibbonaciSequence(number));
    }
    catch(ArgumentException ex) 
    {
        Console.WriteLine(ex.Message);
        number = 0;
    }    
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        number = 0;
    }
}

//ROTATED SQUARE 
number = 0;
while (number == 0)
{
    Console.WriteLine("What diagonal length of the square do you want?");
    int.TryParse(Console.ReadLine(), out var input);
    number = input;
    try
    {
        Console.WriteLine(RotatedSquarePrinter.Print(number));
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        number = 0;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        number = 0;
    }
}


//BUBBLE SORT
number = 0;
while (number == 0)
{
    Console.WriteLine("How many items do you want to sort?");
    int.TryParse(Console.ReadLine(), out var input);
    number = input;
    try
    {
        var rand = new Random();
        var list = new List<int>();
        for (int i = 0; i < number; i++)
        {
            list.Add(rand.Next(0, number));
        }
        Console.WriteLine("Here's your list");
        Console.WriteLine(string.Join(", ", list));
        Console.WriteLine("Hang on while we sort it, we are very busy today...");
        var result = BubbleSorter.Sort(list);
        Console.WriteLine("Here's your sorted list, please check that we got it right");
        Console.WriteLine(string.Join(", ", result));
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        number = 0;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        number = 0;
    }
}