using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    class GameController
    {
        Random r = new Random();
        private int firstNum;
        private int FirstNum
        {
            get { return firstNum; }
            set { firstNum = r.Next(0, 100); }
        }

        private int secondNum;
        private int SecondNum
        {
            get { return secondNum; }

            set { secondNum = r.Next(0, 100); }
        }

        private string? PlayerAnswer { get; set; }
        private int PlayerScore { get; set; }

        public void generateNumbers()
        {
            FirstNum = 0;
            SecondNum = 0;
        }

        public void PlayMode(Func<int,int,int> operation, string mode)
        {
            bool keepPlaying = true;
            while (keepPlaying)
            {
                generateNumbers();
                int correctAnswer = operation(FirstNum, SecondNum);
                Console.WriteLine($"{FirstNum} {mode} {SecondNum} = ?");
                PlayerAnswer = Console.ReadLine();
                try
                {
                    if (PlayerAnswer == "exit")
                    {
                        Console.WriteLine("goodbye");
                        return;
                    }
                    else if (Convert.ToInt32(PlayerAnswer) == correctAnswer)
                    {
                        Console.WriteLine("You got it!");
                        PlayerScore++;
                    }
                    else
                    {
                        Console.WriteLine("That's the wrong answer.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("That number's too high o_O.");
                }
            }
        }

        public void addRound()
        {
            PlayMode((a, b) => a + b, "+");
        }
    }
}
