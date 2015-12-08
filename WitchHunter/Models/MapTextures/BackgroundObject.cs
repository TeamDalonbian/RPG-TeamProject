using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WitchHunter.Exceptions;

namespace WitchHunter.Models
{
    public class BackgroundObject
    {
        protected Texture2D objTexture;
        protected Rectangle rectangle;

        protected BackgroundObject(Texture2D objTexture, Rectangle rectangle)
        {
            this.ObjTexture = objTexture;
            this.Rectangle = rectangle;
        }
        public Rectangle Rectangle
        {
            get { return this.rectangle; }

            set
            {
                if (value.Width <= 0 || value.Height <= 0)
                {
                    throw new InvalidObjectParameterException("size", Messages.Message.InvalidObject);
                }

                this.rectangle = value;
            }
        }

        public Texture2D ObjTexture { get { return this.objTexture; } set { this.objTexture = value; } }


        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rect = new Rectangle(this.Rectangle.X, this.Rectangle.Y,
                this.Rectangle.Width, this.Rectangle.Height);

            spriteBatch.Draw(this.objTexture, rect, Color.White);
        }
    }
}
