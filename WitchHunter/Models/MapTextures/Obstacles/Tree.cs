using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WitchHunter.Interfaces;
using WitchHunter.Models.MapTextures.Obstacles;
using WitchHunter.Models.Spells;

namespace WitchHunter.Models.MapTextures
{
    public class Tree : Obstacle
    {
        public Tree(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
        }
    }
}
