//Three athletes finish in a certain number of seconds (between 1 and 50). 
//Write a program that:
//   • Read three integers - the athletes' times in seconds, from console
//   •  Calculate their total time in the format "minutes:seconds"
//Note: The seconds should be displayed with leading zero (2 as "02", 7 as "07", 35 as "35").


int time1 = int.Parse(Console.ReadLine());
int time2 = int.Parse(Console.ReadLine());
int time3 = int.Parse(Console.ReadLine());


int totalTimeInSeconds = time1 + time2 + time3;


int minutes = totalTimeInSeconds / 60;
int seconds = totalTimeInSeconds % 60;


string formattedSeconds = seconds.ToString("D2");

Console.WriteLine($"{minutes}:{formattedSeconds}");
    
