using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WitchHunter.Exceptions;
using WitchHunter.Interfaces;

namespace WitchHunter.Models
{
    public abstract class GameObject : IColliadable
    {
        protected Texture2D objTexture;
        protected Rectangle rectangle;

        protected GameObject(Texture2D objTexture, Rectangle rectangle)
        {
            this.ObjTexture = objTexture;
            this.Rectangle = rectangle;
            this.State = GameObjectStates.Intact;
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

        public GameObjectStates State { get; set; }

        public virtual void Update()
        {

        }


        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rect = new Rectangle(this.Rectangle.X, this.Rectangle.Y,
                this.Rectangle.Width, this.Rectangle.Height);

            spriteBatch.Draw(this.objTexture, rect, Color.White);
        }

        public virtual void RespondToCollision(GameObject hitObject)
        {

        }

    }
}
