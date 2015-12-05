using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WitchHunter.Models;
using WitchHunter.Models.Characters;
using WitchHunter.Models.MapTextures;
using WitchHunter.Models.MapTextures.Obstacles;
using WitchHunter.Models.Spells;

namespace WitchHunter.Engine
{
    public static class CollisionHandler
    {
        public static GameObject GetCollisionInfo(GameObject obj)
        {
            var collidingObject = GameEngine.gameObjects
                    .FirstOrDefault(gameObject => (!gameObject.Equals(obj) && gameObject.Rectangle.Intersects(obj.Rectangle)));

            if (obj is Tree)
            {
                collidingObject = GameEngine.gameObjects.FirstOrDefault(gameObject => (gameObject is Character) && gameObject.Rectangle.Intersects(obj.Rectangle));
            }

            return collidingObject;
        }

        public static bool ObstaclesObstructingView(Rectangle rect)
        {
            var obstacles = GameEngine.gameObjects.Where(
                    gameObject => (gameObject is Obstacle) && gameObject.Rectangle.Intersects(rect));

            return obstacles.Any();
        }
    }
}
