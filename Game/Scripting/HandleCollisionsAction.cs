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
        public HandleCollisionsAction(Maze maze){
        
            Raylib_cs.Rectangle block = new Raylib_cs.Rectangle();
            foreach (Block wall in maze._maze){
                block.x = wall.xCoordinate;
                block.y = wall.yCoordinate;
                block.width = wall.length;
                block.height = wall.height;
                rectangles.Add(block);
            }
            return;
        }
        public void Execute(Cast cast, Script script)
        {
            Raylib_cs.Rectangle  player_size1 = getPlayerRectangle((Player) cast.GetFirstActor(Constants.PLAYER1));
            Raylib_cs.Rectangle  player_size2 = getPlayerRectangle((Player) cast.GetFirstActor(Constants.PLAYER2));

            Player player_1 = (Player) cast.GetFirstActor(Constants.PLAYER1);
            Player player_2 = (Player) cast.GetFirstActor(Constants.PLAYER2);

            foreach (Raylib_cs.Rectangle wall in rectangles){
                if (Raylib.CheckCollisionRecs(player_size1, wall)){
                    int newY = ResetVerticalPos(player_1, wall);
                    int newX = ResetHorizontalPos(player_1, wall);
                    
                    Point position = new Point(newX, newY);
                    player_1.SetPosition(position);
                }
                if (Raylib.CheckCollisionRecs(player_size2, wall)){
                    int newY = ResetVerticalPos(player_2, wall);
                    int newX = ResetHorizontalPos(player_2, wall);
                    
                    Point position = new Point(newX, newY);
                    player_2.SetPosition(position);
                }

                player_1.setOldPos(player_1.GetPosition());
                player_2.setOldPos(player_2.GetPosition());
                
                return;
            }
            
            
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