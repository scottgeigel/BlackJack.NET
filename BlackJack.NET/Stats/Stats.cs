using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BlackJack.NET
{
    class Stats : IGameListener
    {
        private readonly Stopwatch timer = new();
        private readonly Dictionary<int, int> winHistogram = new();
        private int playerWinCount = 0;
        public int TotalGames { get; private set; } = 0;

        public void NewGame()
        {
            TotalGames++;
        }

        public void PlayerWon(int score)
        {
            playerWinCount++;
            if (!winHistogram.ContainsKey(score))
            {
                winHistogram[score] = 1;
            }
            else
            {
                winHistogram[score]++;
            }
        }

        public void StartTimer()
        {
            timer.Start();
        }

        public void StopTimer()
        {
            timer.Stop();
        }

        public void PrintStats()
        {
            float winRate = ((float)playerWinCount * 100) / ((float)TotalGames);
            Console.Out.WriteLine($"Number of games: {TotalGames}");
            Console.Out.WriteLine($"Player success rate {winRate:00.00}%");
            foreach(KeyValuePair<int, int> kvp in winHistogram)
            {
                Console.Out.WriteLine($"{kvp.Key} => {kvp.Value}");
            }

            Console.Out.WriteLine($"Elapsed time {timer.Elapsed}");
        }
    }
}
