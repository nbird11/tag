using System.Collections.Generic;
using Tag.Game.Casting;
using Tag.Game.Directing;
using Tag.Game.Scripting;
using Tag.Game.Services;

namespace Tag
{
    public class Program
    {
        // TODO: Functionality for maze lists
        // 
        // public static List<>

        // Experimental maze list
        
        // Rectangle platforms[5] = {
        // {552.000000, 550.000000, 850.000000, 350.000000},
        // {705.000000, 1044.000000, 237.000000, 537.000000},
        // {1144.000000, 1556.000000, 145.000000, -45.000000},
        // {1307.000000, 1504.000000, 684.000000, 83.000000},
        // {1336.000000, 1025.000000, 137.000000, 344.000000},

        // Maze maze = new Maze()
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