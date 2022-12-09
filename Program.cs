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
            cast.AddActor(Constants.PLAYER1, new Player(new Point(Constants.MAX_X / 4, Constants.MAX_Y / 2), Constants.RED, true));
            cast.AddActor(Constants.PLAYER2, new Player(new Point(Constants.MAX_X * 3 / 4, Constants.MAX_Y / 2), Constants.BLUE, false));
            // cast.AddActor(Constants.MAZE, new Maze());           // Currently being added in the DrawBlock class

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
            script.AddAction(Constants.UPDATE, new HandleCollisionsAction(cast.GetActors(Constants.BLOCK)));
            script.AddAction(Constants.OUTPUT, new DrawActorsAction(videoService));
            
            // Start Game
            director.StartGame(cast, script);
        }
    }
}