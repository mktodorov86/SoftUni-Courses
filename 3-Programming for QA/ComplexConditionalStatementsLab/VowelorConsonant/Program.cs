////Write a program to check a letter for vowel or consonant:
//  • Reads a character (letter, part of the English alphabet) from the console 
//  • Based on the value of the character, print:
//     ◦ If the character is vowel letter print "Vowel"
//Hint: Vowels letters are: A, a, E, e, I, i, O, o, U, u
//        ◦ If the character is consonant letter print "Consonant"

char letter = char.Parse(Console.ReadLine());

if (letter == 'A' || letter == 'a' ||
    letter == 'E' || letter == 'e' ||
    letter == 'I' || letter == 'i' ||
    letter == 'O' || letter == 'o' ||
    letter == 'U' || letter == 'u')
{
    Console.WriteLine("Vowel");
}
else 
{
    Console.WriteLine("Consonant");
}