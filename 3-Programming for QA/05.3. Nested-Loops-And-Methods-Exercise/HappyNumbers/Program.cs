﻿// • Reads an integer number N from the console
//   • Generate all 4-digit happy numbers {d1}{ d2}
//{ d3}
//{ d4}
//for given integer N:
//      ◦ A number is happy if d1 + d2 == d3 + d4 == N
//      ◦ Print all happy numbers 


int N = int.Parse(Console.ReadLine());


for (int d1 = 1; d1 <= 9; d1++)
{
    for (int d2 = 0; d2 <= 9; d2++)
    {
        for (int d3 = 0; d3 <= 9; d3++)
        {
            for (int d4 = 0; d4 <= 9; d4++)
            {
                if (d3 + d4 == N && d1 + d2 == d3+d4)
                {

                    Console.Write($"{d1}{d2}{d3}{d4} ");
                }
            }
        }
    }
}



