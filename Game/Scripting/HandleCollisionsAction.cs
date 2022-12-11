using System.Collections.Generic;
using Tag;
using Tag.Game.Casting;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;


namespace Tag.Game.Scripting 
{
    public class HandleCollisionsAction : Action
    {
        List<Raylib_cs.Rectangle> rectangles = new List<Raylib_cs.Rectangle>();
        public HandleCollisionsAction(List<Actor> surfaces){
            List<Block> walls = new List<Block>();

            // foreach (Block surface in (List<Block>) surfaces[0].){
            //     walls.Add(surface);
            // }
            Raylib_cs.Rectangle block = new Raylib_cs.Rectangle();
            foreach (Block wall in walls){
                block.x = wall.xCoordinate;
                block.y = wall.yCoordinate;
                block.width = wall.length;
                block.height = wall.width;
                rectangles.Add(block);
            }
            return;
        }
        public void Execute(Cast cast, Script script)
        {
            Raylib_cs.Rectangle  player_size1 = getPlayerRectangle((Player) cast.GetActors(Constants.PLAYER1)[0]);
            Raylib_cs.Rectangle  player_size2 = getPlayerRectangle((Player) cast.GetActors(Constants.PLAYER2)[0]);
            foreach (Raylib_cs.Rectangle wall in rectangles){
                if (Raylib.CheckCollisionRecs(player_size1, wall)){
                    int newY = ResetVerticalPos((Player) cast.GetActors(Constants.PLAYER1)[0], wall);
                    int newX = ResetHorizontalPos((Player) cast.GetActors(Constants.PLAYER1)[0], wall);
                    
                    Point position = new Point(newX, newY);
                    cast.GetActors(Constants.PLAYER1)[0].SetPosition(position);
                }
                if (Raylib.CheckCollisionRecs(player_size2, wall)){
                    int newY = ResetVerticalPos((Player) cast.GetActors(Constants.PLAYER2)[0], wall);
                    int newX = ResetHorizontalPos((Player) cast.GetActors(Constants.PLAYER2)[0], wall);
                    Point position = new Point(newX, newY);
                    cast.GetActors(Constants.PLAYER2)[0].SetPosition(position);
                }
                return;
            }
            // (Player) cast.GetActors(Constants.PLAYER1)[0];
            // (Player) cast.GetActors(Constants.PLAYER2)[0];
            
        }
        private Raylib_cs.Rectangle getPlayerRectangle(Player player){
            Raylib_cs.Rectangle  player_size = new Raylib_cs.Rectangle();
            player_size.x = player.GetPosition().GetX();
            player_size.y = player.GetPosition().GetY();
            player_size.width = player.getSize().GetX();
            player_size.height = player.getSize().GetY();
            return player_size;
        }
        private Raylib_cs.Rectangle getTempYPlayerRectangle(Player player){
            Raylib_cs.Rectangle  player_size = new Raylib_cs.Rectangle();
            player_size.x = player.GetPosition().GetX();
            player_size.y = player.getOldPos().GetY();
            player_size.width = player.getSize().GetX();
            player_size.height = player.getSize().GetY();
            return player_size;
        }
        private Raylib_cs.Rectangle getTempXPlayerRectangle(Player player){
            Raylib_cs.Rectangle  player_size = new Raylib_cs.Rectangle();
            player_size.x = player.getOldPos().GetX();
            player_size.y = player.GetPosition().GetY();
            player_size.width = player.getSize().GetX();
            player_size.height = player.getSize().GetY();
            return player_size;
        }


        private int ResetVerticalPos(Player player, Raylib_cs.Rectangle rectangle)
        {
            Raylib_cs.Rectangle player_size = getTempXPlayerRectangle(player);
            if (Raylib.CheckCollisionRecs(player_size, rectangle)){
                return player.getOldPos().GetY();
            }
            else{
                return player.GetPosition().GetY();
            }
        }
        private int ResetHorizontalPos(Player player, Raylib_cs.Rectangle rectangle)
        {
            Raylib_cs.Rectangle player_size = getTempYPlayerRectangle(player);
            if (Raylib.CheckCollisionRecs(player_size, rectangle)){
                return player.getOldPos().GetX();
            }
            return player.GetPosition().GetX();
        }
    }
}