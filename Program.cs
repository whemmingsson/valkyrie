using System;
using ValkyrieGame.Builder;
using ValkyrieGame.Models;

namespace ValkyrieGame
{
    class Program
    {
        private static readonly GameBuilder _builder = GameBuilder.Init();
        private static Game _game;

        static void Main(string[] args)
        {
            SetupGame();
            RunGame(_game);
        }

        private static void RunGame(Game game)
        {
            Console.WriteLine("Game started");
            Console.WriteLine("Game ended");

            Console.ReadKey();
        }

        private static void SetupGame()
        {
            _game = _builder
                .CreateGame("Test Game 1.0")
                .AddRoom("Cellar")
                .AddRoom("Attic")
                .ConnectRooms()
                .Save("game.json")
                .Build();

            _game = _builder.Reset().LoadGame("game.json").Build();
           
        }
    }
}
