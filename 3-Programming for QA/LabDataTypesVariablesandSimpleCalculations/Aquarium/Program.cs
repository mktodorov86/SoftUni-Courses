//      For his birthday, Lyubomir received an aquarium in the shape of a parallelepiped.Initially, we read from the console in separate rows its dimensions – length, width and height in centimeters.It is necessary to calculate how many liters of water the aquarium will collect, if it is known that a certain percentage of its capacity is occupied by sand, plants, heater and pump.
            //One liter of water is equal to one cubic decimeter(1 l = 1 dm3).
            //Write a program that calculates the liters of water that are needed to fill the aquarium.
            //Input
            //From the console read 4 lines:
            //           1.Length in cm – an integer number in the range[10... 500].
            //   2.Width in cm – an integer number in the range[10... 300].
            //   3.Height in cm – an integer number in the range[10... 200].
            //   4.Percentage – floating point number in the range[0.000... 100.000].
            //Output
            //Print one number on the console:
            //  the liters of water that the aquarium will collect, rounded to the second decimal place.

            int lenghtInCm = int.Parse(Console.ReadLine());
            int widthInCM = int.Parse(Console.ReadLine());
            int heightInCm = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double volAqua = lenghtInCm * widthInCM * heightInCm;
            double volInL = volAqua * 0.001;
            double reqL= volInL * (1-percent/100);
            Console.WriteLine($"{reqL:F2}");







