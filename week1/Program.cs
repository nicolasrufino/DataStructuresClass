// int SumRecursive(int n)
// {
//     if (n == 1)
//     {
//         return 1;
//     }
//     else
//     {
//         return n + SumRecursive(n - 1);
//     }
// }

// Console.WriteLine(CoolMath(1000));

// int CoolMath(int amount)
// {
//     return (amount + 1) * (amount / 2);
// }

/*---------------- FRIDAY AUGUST 31st ----------------*/

// char letter = 'a';

// int asciiNumber = letter;

// Console.WriteLine(asciiNumber);

List<string> soccerStuff = new List<string>();

soccerStuff.Add("Jersey");
soccerStuff.Add("Cleats");
soccerStuff.Add("Goals");

soccerStuff.Sort();

foreach (string s in soccerStuff)
{
    Console.WriteLine(s);
}