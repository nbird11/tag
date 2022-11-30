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
            cast.AddActor("player1", new Player());
            cast.AddActor("player2", new Player());

            // ADD SERVICES
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);

            // ADD DIRECTOR
            Director director = new Director(videoService);

            // CREATE SCRIPT
            Script script = new Script();
            // script.AddAction("draw", new InitialDraw());
            // script.AddAction("update", new ...)
            
            // Start Game
            director.StartGame(cast, script);
        }
    }
}