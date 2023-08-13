int answer = 0;
for (int number = 1; number < 21; number++)
{
    if (number % 3 == 0)
    {
        Console.WriteLine($"{number} is divisible by 3");
        answer += number;
    }
    else
    {
        Console.WriteLine($"{number} is not divisible by 3");
    }
}
Console.WriteLine($"The answer is {answer}");