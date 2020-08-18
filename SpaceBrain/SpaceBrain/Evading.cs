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
using System.Collections.Generic;using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBrain
{
    class Evading
    {
        Vector2 speed = new Vector2(3f,3f);
        Vector2 speed2 = new Vector2(5f, 5f);
        Vector2 position = new Vector2(1200,1);
        Vector2 position3 = new Vector2(1200, 1);
        Vector2 position2, position4;
        Texture2D image;
            Game1 game;
        public Evading(Texture2D img)
        {
            game = new Game1();
            image =img;
           // position = position1;
        }

        public void evade(Vector2 mainPosition, Vector2 miniMapPosition,int ratio, Vector2 camera)
        {
            position += speed;
            if (position.X <= 0 || position.X >= 3200)
             speed.X *= -1;
           if (position.Y <= 0 || position.Y >= 1900)
               speed.Y *= -1;


            if (mainPosition.X < position.X)
              position.X +=speed.Y;
             if (mainPosition.X > position.X)
                position.X-=speed.Y;

             if (mainPosition.Y< position.Y)
                position.X +=speed.X;
             else if (mainPosition.Y> position.Y)
                position.X -=speed.X;

            //===========================================================sprite2
             position3 += speed2;
             if (position3.X <= 0 || position3.X >= 3200)
                 speed2.X *= -1;
             if (position3.Y <= 0 || position3.Y >= 1900)
                 speed2.Y *= -1;


             if (mainPosition.X < position3.X)
                 position3.X += speed2.Y;
             if (mainPosition.X > position3.X)
                 position3.X -= speed2.Y;

             if (mainPosition.Y < position3.Y)
                 position3.X += speed2.X;
             else if (mainPosition.Y > position3.Y)
                 position3.X -= speed2.X;



             position2 = new Vector2(miniMapPosition.X + position.X / ratio + camera.X, miniMapPosition.Y + position.Y / ratio + camera.Y);
             position4 = new Vector2(miniMapPosition.X + position3.X / ratio + camera.X, miniMapPosition.Y + position3.Y / ratio + camera.Y);
        }
        public void Draw(SpriteBatch spritebatch)
        {

            spritebatch.Draw(image, position, Color.White);
            spritebatch.Draw(image,position2 , null, Color.White, 0, Vector2.Zero, 0.10f, SpriteEffects.None, 0.2f);

            spritebatch.Draw(image, position3, Color.White);
            spritebatch.Draw(image, position4, null, Color.White, 0, Vector2.Zero, 0.10f, SpriteEffects.None, 0.2f);
        }




    }
}
