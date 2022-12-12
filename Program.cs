using System;
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
            cast.AddActor(Constants.BOOST, new SpeedPowerup());

            cast.AddActor(Constants.MESSAGE, new Actor());
            Actor message = (Actor)cast.GetFirstActor(Constants.MESSAGE);
            message.SetPosition(new Point((Constants.MAX_X / 2) - 100, 20));
            message.SetFontSize(Constants.FONT_SIZE);
            message.SetColor(Constants.RED);
            message.SetText("RED IS IT!");

            List<List<float>> obstacleList = new List<List<float>>()
            {
                new List<float> {20.000000f, 480.000000f, 200.000000f, 50.000000f},
                new List<float> {20.000000f, 10.000000f, 200.0f, 50.0f},
                new List<float> {360.000000f, 400.000000f, 200.481277f, 50.323700f},
                new List<float> {360.000000f, 100.000000f, 200.481277f, 50.323700f},
                new List<float> {70.000000f, 300.000000f, 50.481277f, 50.323700f},
                new List<float> {70.000000f, 200.000000f, 50.481277f, 50.323700f},
                 new List<float> {750.000000f, 300.000000f, 50.481277f, 50.323700f},
                new List<float> {750.000000f, 200.000000f, 50.481277f, 50.323700f},
                new List<float> {650.0f, 480.0f, 200.0f, 50.0f},
                new List<float> {650.0f, 10.0f, 200.0f, 50.0f}
            };
            
            cast.AddActor(Constants.MAZE, new Maze(obstacleList));     

            // ADD SERVICES
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);

            // ADD DIRECTOR
            Director director = new Director(videoService);

            // CREATE SCRIPT
            Script script = new Script();

            // TODO:
            script.AddAction(Constants.INITIALIZE, new DrawMazeAction(videoService));
            script.AddAction(Constants.INPUT, new ControlActorsAction(keyboardService));
            script.AddAction(Constants.UPDATE, new MoveActorsAction());
            script.AddAction(Constants.UPDATE, new PlayerCollisionsAction());
            script.AddAction(Constants.UPDATE, new HandleCollisionsAction((Maze) cast.GetFirstActor(Constants.MAZE)));
            script.AddAction(Constants.UPDATE, new ChangeBoostAction());
            script.AddAction(Constants.OUTPUT, new DrawActorsAction(videoService));
            
            // Start Game
            director.StartGame(cast, script);
        }
    }
}