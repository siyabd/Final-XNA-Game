using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


//SB 

namespace SpaceBrain
{
    class Collision
    {
        public Texture2D flame;

        Point frameSizeFlame = new Point(96, 96);
        Point currentFrameFlame = new Point(0, 0);
        Point sheetSize = new Point(5, 3);
        int flameTimeSinceLastFrame = 0;
        int flameMillisecondsPerFrame = 70;
        Vector2 position = Vector2.Zero;

        Enemies enemies;
        Bullets bullet;

        Game1 game;

        public Collision(Texture2D coll){
            flame = coll;
        
        
        }
        public void getPositions(Vector2 pos)
        {
            position = pos;
        }
        public void Update(GameTime gameTime)
        {

            //==========================================================================================================================

            flameTimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (flameTimeSinceLastFrame > flameMillisecondsPerFrame)
            {
                flameTimeSinceLastFrame -= flameMillisecondsPerFrame;

                ++currentFrameFlame.X;
                if (currentFrameFlame.X >= sheetSize.X)
                {
                    currentFrameFlame.X = 0;
                    ++currentFrameFlame.Y;
                    if (currentFrameFlame.Y >= sheetSize.Y)
                        currentFrameFlame.Y = 0;
                }

            }






        }
        public void Draw(SpriteBatch SpriteBatch)
        {

            //if (game.lifeMain >= 20)
           // {
                SpriteBatch.Draw(flame, position, new Rectangle(currentFrameFlame.X * frameSizeFlame.X, currentFrameFlame.Y * frameSizeFlame.Y, frameSizeFlame.X, frameSizeFlame.Y), Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 0.2f);
            //}
                
                //spriteBatch.Draw(flame, new Vector2(miniMapPosition.X + position4.X / ratio + camera.X, miniMapPosition.Y + position4.Y / ratio + camera.Y), new Rectangle(currentFrameFlame.X * frameSizeFlame.X, currentFrameFlame.Y * frameSizeFlame.Y, frameSizeFlame.X, frameSizeFlame.Y), Color.White, 0, Vector2.Zero, 0.1f, SpriteEffects.None, 0.2f);
            //SpriteBatch.Draw(skull1, position, Color.White);

        }





    }
}
