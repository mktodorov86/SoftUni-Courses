
            //         The school year has already started and the 10B grade manager - Annie has to buy a certain number of packets of pens, packets with markers, as well as board cleaner.She is a regular client of a bookstore, so there is a discount for her, which represents some discount percentage of the total amount.Write a program that calculates how much money Annie will need to collect to pay the bill, keeping in mind the following price list: 
            //    • Package of pens - 5.80 lv.
            //   • Package of markers - 7.20 lv.
            //   • Board cleaner - 1.20 BGN(per liter)
            //Input
            //From the console read 4 numbers:
            //  • Number of packages of pens - integer in the range[0...100].
            //  • Number of packets of markers - integer in the range[0...100].
            //  • Liters of board cleaner - an integer in the range[0... 50].
            //  • Discount percentage - integer in the range[0...100].
            //Output
            //Print on the console how much money will Annie need to pay the bill.

            int packPens = int.Parse(Console.ReadLine());
            int packMarkers = int.Parse(Console.ReadLine());
            int litersCleaner = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double pens = 5.80;
            double markers = 7.20;
            double bCleaner = 1.20;

            double amount = (packPens * pens) + (packMarkers * markers) + (litersCleaner * bCleaner);
            double afterDisc = amount - (amount*discount/100);

            Console.WriteLine($"{afterDisc:F2}");
    