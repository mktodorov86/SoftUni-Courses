
            //         The restaurant opens its doors and offers several menus at preferential prices: 
            //   • Chicken menu – 10.35 lv.
            //   • Menu with fish – 12.40 lv.
            //  • Vegetarian menu – 8.15 lv.
            //Write a program that calculates how much it will cost a group of people to order takeaways.
            //The group will also order a dessert, the price of which is equal to 20 % of the total bill(excluding delivery).
            //The delivery price is 2.50 BGN and is finally charged.
            //Input
            //From the console read 3 lines:
            //   • Number of chicken menus – integer in the range[0... 99]
            //   • Number of menus with fish – integer in the range[0... 99]
            //   • Number of vegetarian menus – an integer in the range[0... 99]
            //Output
            //Print out only one line on the console: "{order price}"

            int chikMenus = int.Parse(Console.ReadLine());
            int fishMenus = int.Parse(Console.ReadLine());
            int vegMenus = int.Parse(Console.ReadLine());

            double chickenMenu = 10.35;
            double fishMenu = 12.40;
            double vegMenu = 8.15;
            double delPrice = 2.50;

            double totBill = (chikMenus * chickenMenu) + (fishMenus * fishMenu) + (vegMenus * vegMenu);
            double desPrice = totBill * 0.2;
            double orderPrice = totBill + desPrice + delPrice;

            Console.WriteLine(orderPrice);
    

