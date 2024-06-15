//Write a program, which sums the numbers 1…n:
//        ◦ Reads an integer number n from the console
//     ◦ Sums all numbers from 1 to n
//     ◦ Prints the numbers and the sum on the console as shown below


         int n = int.Parse(Console.ReadLine());
         
         int sum = 0;
        string equation = "";
         
         for (int i = 1; i <= n; i++)
        {
             sum += i;
             equation += i;
             if (i < n)
             {
                equation += "+";
             }
         }
         
         
         Console.WriteLine($"{equation}={sum}");