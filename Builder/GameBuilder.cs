using Newtonsoft.Json;
using System.Collections.Generic;
using ValkyrieGame.Models;

namespace ValkyrieGame.Builder
{
    class GameBuilder
    {
        private Game _game;

        private IList<Room> _temporaryRooms;

        private GameBuilder() 
        {
            _temporaryRooms = new List<Room>();
        }

        public static GameBuilder Init()
        {
            return new GameBuilder();
        }

        public GameBuilder Reset()
        {
            _game = null;
            return this;
        }

        public GameBuilder CreateGame(string name)
        {
            _game = new Game(name);
            return this;
        }

        public GameBuilder AddRoom(string name)
        {
            var room = new Room(name);
            _game.Rooms.Add(room);
            _temporaryRooms.Add(room);

            return this;
        }

        public GameBuilder ConnectRooms()
        {
            if(_temporaryRooms.Count == 2)
            {
                var door = Door.CreateBetween(_temporaryRooms[0], _temporaryRooms[1]);
                _game.Doors.Add(door);
                _temporaryRooms.Clear();
            }

            return this;
        }

        public GameBuilder LoadGame(string fileName)
        {
            if(_game != null)
                throw new System.Exception("Game object already created. Don't run CreateGame() if you intended to load it from a file");

            if (!System.IO.File.Exists(fileName))
                throw new System.Exception("Game file not found");

            var gameAsJson = System.IO.File.ReadAllText(fileName);

            _game = Newtonsoft.Json.JsonConvert.DeserializeObject<Game>(
                gameAsJson, 
                new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });

            return this;
        }

        public GameBuilder Save(string fileName)
        {
            var gameAsJson = JsonConvert.SerializeObject(
                _game, 
                Formatting.Indented, 
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                });

            System.IO.File.WriteAllText(fileName, gameAsJson);

            return this;
        }

        public Game Build()
        {
            return _game;
        }
    }
}
