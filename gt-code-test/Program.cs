// See https://aka.ms/new-console-template for more information
using gt_code_test;
using Microsoft.Extensions.Configuration;



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


//PALINDROMES
var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();
Console.WriteLine("Checking palindromes");
try
{
    var httpClient = new HttpClient();
    var palindromeService = new PalindromeService(config, httpClient);
    var testData = await palindromeService.GetTestData();
    Console.WriteLine(string.Join(", ", testData));
    var palindromeResult = palindromeService.FindPalindromes(testData);
    Console.WriteLine("Palindromes:");
    Console.WriteLine(string.Join(", ", palindromeResult.Palindromes));
    Console.WriteLine("Non palindromes");
    Console.WriteLine(string.Join(", ", palindromeResult.NonPalindromes));
    Console.WriteLine("Sending result");
    var isSuccess = await palindromeService.SendResult(palindromeResult);
    if (isSuccess)
    {
        Console.WriteLine("Result sent ok");
    }
}
catch(Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

