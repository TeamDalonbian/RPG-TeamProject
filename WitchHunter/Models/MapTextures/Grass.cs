using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WitchHunter.Interfaces;

namespace WitchHunter.Models.MapTextures
{
    class Grass : GameObject, IBackGround
    {

        public Grass(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
        }


        public override void Update()
        {
        }

        public override void RespondToCollision(GameObject hitObject)
        {
        }
    }
}
