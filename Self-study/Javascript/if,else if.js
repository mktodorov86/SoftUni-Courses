hour = -1;
if (hour >=6 && hour < 12)
    console.log("Good morning");
else if (hour > 12 && hour <18)
    console.log("Good afternoon");
else if (hour > 24 || hour < 0)
    console.log("ERROR");
else
    console.log("Good evening");