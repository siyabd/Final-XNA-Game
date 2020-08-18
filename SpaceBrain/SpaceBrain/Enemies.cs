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
    class Enemies 
    {
        public Texture2D texture,lifeAdding;
        public  Rectangle lifeAddingRecta ;
        public Texture2D enemy2;
        public Vector2 position, eachPpos, eachPpos2,addingPosition;
        public Vector2 speed,speed2 = new Vector2(1,1);

        public Vector2 position4 =  new Vector2(0 , 0);
        public Vector2 speed4 = new Vector2(1, 1);
        public Vector2 posB;


        Texture2D lifeBar1, lifeBar2, lifeBar3,lifeBar4,lifeBar5;
        public Vector2 lifePosition;

        public int life;
        public Rectangle enemyRecta;
        public Rectangle bulletRecta;
        public Rectangle enemiesBulletRec;
        public bool isVisible = true;
        Random random = new Random();
        int randX, randY;
        int X, Y;
        Game1 game;
        List<Bullets> bullets = new List<Bullets>();
        public Texture2D bulletTexture;

        public Enemies(Texture2D newTexture, Vector2 newPos, Texture2D newBulletTexture, Texture2D life1in1,
            Texture2D life1in2, Texture2D life1in3, Texture2D life1in4, Texture2D life1in5,Texture2D addingL)
        {
            lifeAdding = addingL;
            bulletTexture = newBulletTexture;
            texture = newTexture;
            position = newPos;
            randX = random.Next(-4, 4);
            randY = random.Next(-4, 1);
            game = new Game1();
            speed = new Vector2(randX, randY);
             
            lifeBar1 = life1in1; 
            lifeBar2 = life1in2;
            lifeBar3 = life1in3;
            lifeBar4 = life1in4;
            lifeBar5 = life1in5;
            life = 30;
            X = random.Next(-6, 6);
            Y = random.Next(-6, 6);
            speed4 = new Vector2(X, Y);
            addingPosition.Y = random.Next(-2000, -1500);
            addingPosition.X= random.Next(-5, 2500);


        }
        public Rectangle BoundingBox
        { get
            {
                return new Rectangle((int)position.X,(int)position.Y, 32, 32);
            }
        }


        public Rectangle BoundingBoxEnemies
        {  
            get
            {

                Vector2 x = Vector2.Zero;
                foreach (Bullets bullet in bullets)
                {
                    x = new Vector2(bullet.positionB.X, bullet.positionB.Y);
                   // return new Rectangle((int)x, (int)y, 32, 32);
                }
                    return new Rectangle((int)x.X,(int)x.Y, 32, 32);
                
            }
        }

        float shoot = 0;
        public void Update(GraphicsDevice graphics, GameTime gameTime, int lifein)
        {

            //====================================================AI LEVELS===================================================================


            if (position.Y < 0 - 100)

            //=================================================================================================================================
           //if (game.shootEnemies < 2)
            //{
           
                isVisible = false;
            
                position += speed;
                if (position.Y <= 0 || position.Y >= 1900)
                    speed.Y *= -1;
                if (position.X <= 0 || position.X >= 3200)
                    speed.X *= -1;
          /* }
           else 
           {

               if (game.mainPosition.X < position.X)
                   position.X -= 3;
               else if (game.mainPosition.X > position.X)
                   position.X += 3;
               if (game.mainPosition.Y < position.Y)
                   position.Y -= 3;
               else if (game.mainPosition.Y > position.Y)
                   position.Y += 3;

           }*/
            //=================================================================================================================================

                lifePosition = new Vector2(position.X + 100, position.Y + 20);
               // enemyRecta = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

                position3Change();
                

            //====================================================================================================================
            shoot += (float)gameTime.ElapsedGameTime.TotalSeconds;
           // if (Vector2.Distance(position, game.mainPosition) < 50) { 
            if (shoot > 1)
            {
                shoot = 0;
               // if (game.shootEnemies >15 )
               ShootBullets();
            }

            UpdateBullets(); 
        }
       

        public void position3Change(){
            addingPosition.Y += 10;
            lifeAddingRecta = new Rectangle((int)addingPosition.X, (int)addingPosition.Y, lifeAdding.Width, lifeAdding.Height);
          //  if (addingPosition.Y >= 1200)
          //  {
               // addingPosition.Y = -1600;
           // }
            //position4 += speed4;       
            //if (position4.Y <= 0 || position4.Y >= 1200)
               // speed4.Y *= -1;
            ///if (position4.X <= 0 || position4.X >= 3200)
                //speed4.X *= -1    
        }

        public void UpdateBullets()
        {
            foreach (Bullets bullet in bullets)
            {
                bullet.positionB += bullet.speed;
                if (bullet.positionB.X < 0)
                    bullet.isVisible = false;
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].isVisible)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }
        }
        public void ShootBullets()
        {

            Bullets newBullet = new Bullets(bulletTexture);
         newBullet.speed.X = speed.X - 4f;
            newBullet.speed.Y = speed.Y;
            newBullet.positionB = new Vector2(position.X + newBullet.speed.X, position.Y + 2 );
            posB = newBullet.positionB;
             bulletRecta = new Rectangle((int)newBullet.positionB.X, (int)newBullet.positionB.Y, texture.Width, texture.Height);
            newBullet.isVisible = true;
            if (bullets.Count() < 4)
                bullets.Add(newBullet);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bullets bullet in bullets)
                bullet.Draw(spriteBatch);
            spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.Draw(texture, eachPpos, null, Color.Red, 0, Vector2.Zero, 0.2f, SpriteEffects.None, 0.2f);


            spriteBatch.Draw(lifeAdding, addingPosition, Color.White);
            spriteBatch.Draw(lifeAdding, eachPpos2, null, Color.White, 0, Vector2.Zero, 0.3f, SpriteEffects.None, 0.2f);

            if(life >=25)
            spriteBatch.Draw(lifeBar1, lifePosition, Color.White);
            else if (life >= 20)
                spriteBatch.Draw(lifeBar2, lifePosition, Color.White);
            else if (life >= 15)
                spriteBatch.Draw(lifeBar3, lifePosition, Color.White);
            else if (life >= 10)
                spriteBatch.Draw(lifeBar4, lifePosition, Color.White);
            else if(life >= 5)
                spriteBatch.Draw(lifeBar5, lifePosition, Color.White);
        }
    }
}
