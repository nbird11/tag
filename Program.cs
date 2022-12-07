using System.Collections.Generic;
using Tag.Game.Casting;
using Tag.Game.Directing;
using Tag.Game.Scripting;
using Tag.Game.Services;

namespace Tag
{
    public class Program
    {      
        public static void Main(string[] args)
        {
            // ADD CAST
            Cast cast = new Cast();
            cast.AddActor(Constants.PLAYER1, new Player());
            cast.AddActor(Constants.PLAYER2, new Player());
            // cast.AddActor(Constants.MAZE, new Maze());

            // ADD SERVICES
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);

            // ADD DIRECTOR
            Director director = new Director(videoService);

            // CREATE SCRIPT
            Script script = new Script();

            // TODO:
            script.AddAction(Constants.INITIALIZE, new DrawBlockAction(videoService));
            script.AddAction(Constants.INPUT, new ControlActorsAction(keyboardService));
            script.AddAction(Constants.UPDATE, new MoveActorsAction());
            script.AddAction(Constants.UPDATE, new HandleCollisionsAction());
            script.AddAction(Constants.OUTPUT, new DrawActorsAction(videoService));
            
            // Start Game
            director.StartGame(cast, script);
        }
    }
}