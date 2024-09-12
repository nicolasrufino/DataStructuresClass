// int listOfInts(List<int> integers)
// {
//     int one = 1;
//     int two = 2;
//     int three = 3;
//     int four = 4;
//     int five = 5;
//     int six = 6;
//     int seven = 7;



//     return 0;
// }

// WHAT PROFESSOR CRAIG HAD IS THE FOLLOWING

List<int> listOfInts = new List<int> { 7, 24, 7, 2, 1, 6, 3, 2, 4 };

//  int countInterface(char x, string s)
// {
//     int count = 0;
//     foreach (char c in s)
//     {
//         if (c == x)
//         {
//             count++;
//         }
//     }
//     return count;
// }


 static int recursiveSum(int n)
{
    if (n == 1)
    {
        return 1;
    }
    else
    {
        return n + recursiveSum(n - 1);
    }
}

Console.WriteLine(recursiveSum(1000));