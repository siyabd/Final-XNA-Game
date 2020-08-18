using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Text;

namespace SpaceBrain 
{
    

    class userControlled : Microsoft.Xna.Framework.Game
    {
        Vector2 image2Direction;
        Vector2 mousePosition2;


       public Vector2 position1,position2,position3;
       Vector2 speed1 = new Vector2(1, 1);
       Vector2 speed2 = new Vector2(1, 1);

        public Texture2D texture { get; set;} // Sprite texture, read-only property
        public Vector2 positionSprite { get; set; } // Sprite position on screen
        public Vector2 size { get; set; } // Sprite size in pixels
    private Vector2 screenSize { get; set; } // Screen size
    public Vector2 velocity { get; set; } // Sprite velocity
        

        public userControlled (Texture2D newTexture, Vector2 newPosition,
            Vector2 newSize, int ScreenWidth, int ScreenHeight)
            {
                texture = newTexture;
            positionSprite = newPosition;
            size = newSize;
            screenSize = new Vector2(ScreenWidth, ScreenHeight);
        }

       public void Update(GameTime gameTime, Game1 go)
       { }

        
       

        public void position(GameTime gameTime) {


            position1 += speed1;
            if (position1.Y <= 0 || position1.Y >= 1900)
                speed1.Y *= -1;

            if (position1.X <= 0 || position1.X >= 3200)
                speed1.X *= -1;

            position2 += speed2;
            if (position2.Y <= 0 || position2.Y >= 1900)
                speed1.Y *= -1;

            if (position1.X <= 0 || position1.X >= 3200)
                speed1.X *= -1;

        
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position1, Color.White);
            spriteBatch.Draw(texture, position2 , Color.White);
        }


    }
}
