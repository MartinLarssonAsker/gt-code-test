// See https://aka.ms/new-console-template for more information
using gt_code_test;

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

