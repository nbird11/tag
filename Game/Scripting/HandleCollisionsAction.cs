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
        List<Block> walls = new List<Block>();
        public HandleCollisionsAction(List<Actor> surfaces){
            foreach (Block surface in surfaces){
                walls.Add(surface);
            }
        }
        public void Execute(Cast cast, Script script)
        {
            checkCollision((Player) cast.GetActors(Constants.PLAYER1)[0], walls);
            checkCollision((Player) cast.GetActors(Constants.PLAYER2)[0], walls);
            
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


        private void ResetVerticalPos(Player player, Raylib_cs.Rectangle rectangle)
        {
            Raylib_cs.Rectangle player_size = getTempXPlayerRectangle(player);
            if (Raylib.CheckCollisionRecs(player_size, rectangle)){
                player.SetPosition(new Point(player.GetPosition().GetX(), player.getOldPos().GetY()));
            }
            return;
        }
        private void ResetHorizontalPos(Player player, Raylib_cs.Rectangle rectangle)
        {
            Raylib_cs.Rectangle player_size = getTempYPlayerRectangle(player);
            if (Raylib.CheckCollisionRecs(player_size, rectangle)){
                player.SetPosition(new Point(player.getOldPos().GetX(), player.GetPosition().GetY()));
            }
            return;
        }
        public void checkCollision(Player player, List<Block> walls)
        {
            Raylib_cs.Rectangle  player_size = getPlayerRectangle(player);
            Raylib_cs.Rectangle wall = new Raylib_cs.Rectangle();
            foreach (Block block in walls){
                wall.x = block.xCoordinate;
                wall.y = block.yCoordinate;
                wall.width = block.length;
                wall.height = block.width;
                if (Raylib.CheckCollisionRecs(player_size, wall)){
                    ResetVerticalPos(player, wall);
                    player_size = getPlayerRectangle(player);
                    if (Raylib.CheckCollisionRecs(player_size, wall)){
                        ResetHorizontalPos(player, wall);
                    }
                }
            }
            return;
        }
    }
}