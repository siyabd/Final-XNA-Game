using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Text;
using System;
using System.Linq;
using System.Collections.Generic;


namespace SpaceBrain
{
    class Bullets
    {       
              public Texture2D texture;
            public Vector2 positionB, origin, speed,pos1;
            public bool isVisible ;
             public Rectangle bulletRecta ;
            public Bullets (Texture2D newTexture){
                texture = newTexture;
                isVisible = false;
    
    }

            public void pos( Vector2 miniMapPosition, int ratio, Vector2 camera) {
               bulletRecta = new Rectangle((int)positionB.X, (int)positionB.Y, texture.Width, texture.Height);
                pos1 = new Vector2(miniMapPosition.X + positionB.X / ratio + camera.X, miniMapPosition.Y + positionB.Y / ratio + camera.Y);            
            }
            
             public Rectangle BoundingBox
            {
                get { return new Rectangle((int)positionB.X , (int)positionB.Y, 30, 25); }
            }
             
        public void Draw(SpriteBatch spritebatch){

            spritebatch.Draw(texture, positionB, null, Color.White, 0f, origin, 0.1f, SpriteEffects.None, 0f);
            spritebatch.Draw(texture, pos1, null, Color.White, 0f, origin, 0.04f, SpriteEffects.None, 0f);
            
        }

    }
}
