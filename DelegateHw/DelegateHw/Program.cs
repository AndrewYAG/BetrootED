using System.Timers;

namespace DelegateHw
{
    internal class Program
    {
        // add delegate and event (maybe timer eventHandler to move)
        // add ivent invokation
        // add automove if no action for some perOfTime
        static void Main(string[] args)
        {


            GameField newGame = new GameField();

            newGame.Snake.autoMoveTimer = new System.Timers.Timer(1000);

            newGame.Snake.autoMoveTimer.Elapsed += (object? sender, ElapsedEventArgs e) =>
            {
                if (newGame.IsGameOver)
                {
                    newGame.Snake.autoMoveTimer.Stop();
                }
            };
            newGame.Snake.autoMoveTimer.Elapsed += newGame.Snake.AutoMoveInCurrentDirection;
            newGame.Snake.autoMoveTimer.Elapsed += newGame.CheckCollision;
            newGame.Snake.autoMoveTimer.Elapsed += newGame.PrintGame;
            newGame.Snake.autoMoveTimer.Start();


            while (!newGame.IsGameOver)
            {
                newGame.PrintGame();
                newGame.CheckCollision();

                newGame.Snake.Move(Console.ReadKey().Key);

                newGame.CheckCollision();
            }
        }
    }
}