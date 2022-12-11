// using System.Collections.Generic;
// using Tag.Game.Casting;
// using Tag.Game.Services;
// using System;


// namespace Tag.Game.Scripting
// {
//     /// <summary>
//     /// <para>An output action that draws all the actors.</para>
//     /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
//     /// </summary>
//     public class DrawBlockAction : Action
//     {
//         private VideoService _videoService;

//         /// <summary>
//         /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
//         /// </summary>
//         public DrawBlockAction(VideoService videoService)
//         {
//             this._videoService = videoService;
//         }

//         //List<Block> maze1 = new List<Block>();
//         List<List<float>> maze2 = new List<List<float>>()
//         {
            
//              new List<float> {201.000000f, 226.000000f, 0.000000f, 0.000000f},
//              new List<float> {199.000000f, 229.000000f, 150.394547f, 779.317200f},
//              new List<float> {499.000000f, 235.000000f, 111.481277f, 291.323700f},
//              new List<float> {601.000000f, 578.000000f, 519.544678f, 118.843216f},
//              new List<float> {500.000000f, 741.000000f, 111.481262f, 281.858368f},
//              new List<float> {1215.000000f, 256.000000f, 135.670593f, 433.304657f},
//              new List<float> {1216.000000f, 795.000000f, 119.894920f, 222.962585f},
//              new List<float> {1547.000000f, 224.000000f, 103.067612f, 795.092957f},

//         };
        
//         public void Execute(Cast cast, Script script)
//         {
//         //     Block block1 = new Block(201.000000f, 226.000000f, 0.000000f, 0.000000f);
//         // maze1.Add(block1);

//         // maze2.Add([201.000000, 226.000000, 0.000000, 0.000000]);

//         // List<List<float>> maze2 = 
//         //     [201.000000, 226.000000, 0.000000, 0.000000]
//         //     [199.000000, 229.000000, 150.394547, 779.317200],
//         //     [499.000000, 235.000000, 111.481277, 291.323700],
//         //     [601.000000, 578.000000, 519.544678, 118.843216],
//         //     [500.000000, 741.000000, 111.481262, 281.858368],
//         //     [1215.000000, 256.000000, 135.670593, 433.304657],
//         //     [1216.000000, 795.000000, 119.894920, 222.962585],
//         //     [1547.000000, 224.000000, 103.067612, 795.092957];

        
            


//             Block block = new Block();
//             List<Block> blockMaze =block.createBlockList(maze2);

//             block.drawblock(blockMaze);
//            // _videoService.ClearBuffer();
//             // _videoService.DrawActors(segments1);
//             // _videoService.DrawActors(segments2);
//             // _videoService.DrawActors(messages);
//             // _videoService.FlushBuffer();
//         }
//     }
// }