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

        private Dictionary<string, int>? Rounds { get; set; } = new Dictionary<string, int>();

        public void generateNumbers()
        {
            FirstNum = 0;
            SecondNum = 0;
        }

        public void Play()
        {
            bool loop = true;
            while(loop)
            {
                Console.WriteLine("Type the mode you want to play or type 'list' to see the list of rounds you have played.");
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "add": PlayAdd(); break;
                    case "sub": PlaySub(); break;
                    case "mul": PlayMul(); break;
                    case "list": ShowList(); break;
                    case "exit": loop = false; break;
                }
            }
        }

        public void ShowList()
        {
            foreach (var pair in Rounds)
            {
                Console.WriteLine($"Problem: {pair.Key}, Answer: {pair.Value}");
            }
        }

        public void PlayMode(Func<int,int,int> operation, string mode)
        {
            bool keepPlaying = true;
            while (keepPlaying)
            {
                generateNumbers();
                int correctAnswer = operation(FirstNum, SecondNum);
                string problem = $"{FirstNum} {mode} {SecondNum} = ?";
                Console.WriteLine(problem);
                PlayerAnswer = Console.ReadLine();
                try
                {
                    if (PlayerAnswer == "exit")
                    {
                        Console.WriteLine("goodbye");
                        return; ;
                    }
                    else if (Convert.ToInt32(PlayerAnswer) == correctAnswer)
                    {
                        Console.WriteLine("You got it!");
                        Rounds.Add(problem, Convert.ToInt32(PlayerAnswer));
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

        public void PlayAdd()
        {
            PlayMode((a, b) => a + b, "+");
        }
        public void PlaySub()
        {
            PlayMode((a, b) => a - b, "-");
        }
        public void PlayMul()
        {
            PlayMode((a, b) => a * b, "*");
        }

    }
}
