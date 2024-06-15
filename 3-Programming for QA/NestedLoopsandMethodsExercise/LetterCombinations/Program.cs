//◦ Read a start letter s, end letter e and excluded letter x
//  ◦ Generate all combinations of 3 letters in the range [s…e], excluding x
//   ◦ Print all combinations on the first line
//   ◦ Print combinations count on the second line


char startLetter = char.Parse(Console.ReadLine());
char endLetter = char.Parse(Console.ReadLine());
char excludedLetter = char.Parse(Console.ReadLine());

var combinations = new System.Text.StringBuilder();


int count = 0;


for (char i = startLetter; i <= endLetter; i++)
{
    if (i == excludedLetter) continue; 

    for (char j = startLetter; j <= endLetter; j++)
    {
        if (j == excludedLetter) continue; 

        for (char k = startLetter; k <= endLetter; k++)
        {
            if (k == excludedLetter) continue; 

     
            combinations.Append($"{i}{j}{k} ");
            count++;
        }
    }
}


Console.WriteLine(combinations.ToString().Trim());


Console.WriteLine(count);
    