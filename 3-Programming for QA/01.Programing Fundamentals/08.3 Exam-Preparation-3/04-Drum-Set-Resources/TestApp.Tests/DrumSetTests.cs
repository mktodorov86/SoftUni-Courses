using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestApp.Tests
{
    public class DrumSetTests
    {
        [Test]
        public void Test_Drum_TerminateCommandNotGiven_ThrowsArgumentException()
        {
            decimal money = 100;
            List<int> initialQuality = new List<int> { 10, 20, 30 };
            List<string> commands = new List<string> { "5", "3", "2" };

            var ex = Assert.Throws<ArgumentException>(() => DrumSet.Drum(money, initialQuality, commands));
            Assert.That(ex.Message, Is.EqualTo("Terminate command not given!"));
        }

        [Test]
        public void Test_Drum_StringGivenAsCommand_ThrowsArgumentException()
        {
            decimal money = 100;
            List<int> initialQuality = new List<int> { 10, 20, 30 };
            List<string> commands = new List<string> { "hit", "5", "Hit it again, Gabsy!" };

            var ex = Assert.Throws<ArgumentException>(() => DrumSet.Drum(money, initialQuality, commands));
            Assert.That(ex.Message, Is.EqualTo("Number did not parse correctly!"));
        }

        [Test]
        public void Test_Drum_ReturnsCorrectQualityAndAmount()
        {
            decimal money = 100;
            List<int> initialQuality = new List<int> { 10, 20, 30 };
            List<string> commands = new List<string> { "5", "10", "15", "Hit it again, Gabsy!" };

            string result = DrumSet.Drum(money, initialQuality, commands);

            // Calculate expected remaining money after processing commands
            decimal expectedMoney = money;
            foreach (var command in commands)
            {
                if (int.TryParse(command, out int power))
                {
                    foreach (var quality in initialQuality)
                    {
                        if (quality <= power)
                        {
                            expectedMoney -= quality * 3;
                        }
                    }
                }
            }

            // Prepare expected output string
            string expected = $"{string.Join(" ", initialQuality)}\nGabsy has {expectedMoney:f2}lv.";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Drum_BalanceZero_WithOneDrumLeftOver_ReturnsCorrectQualityAndAmount()
        {
            decimal money = 30;
            List<int> initialQuality = new List<int> { 10, 20, 30 };
            List<string> commands = new List<string> { "5", "25", "Hit it again, Gabsy!" };

            string result = DrumSet.Drum(money, initialQuality, commands);

            // Calculate expected remaining money after processing commands
            decimal expectedMoney = money;
            foreach (var command in commands)
            {
                if (int.TryParse(command, out int power))
                {
                    foreach (var quality in initialQuality)
                    {
                        if (quality <= power)
                        {
                            expectedMoney -= quality * 3;
                        }
                    }
                }
            }

            // Prepare expected output string
            List<int> usedQuality = new List<int> { 5, 5, 30 }; // First two drums are replaced, third drum remains
            string expected = $"\nGabsy has {expectedMoney:f2}lv.";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Drum_NotEnoughBalance_RemovesAllDrums_ReturnsCorrectQualityAndAmount()
        {
            decimal money = 20;
            List<int> initialQuality = new List<int> { 10, 20, 30 };
            List<string> commands = new List<string> { "10", "25", "Hit it again, Gabsy!" };

            string result = DrumSet.Drum(money, initialQuality, commands);
            List<int> usedQuality = new List<int>(); // All drums are removed

            string expected = $"{string.Join(" ", usedQuality)}\nGabsy has {money:f2}lv.";

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
