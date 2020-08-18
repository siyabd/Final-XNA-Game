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

namespace SpaceBrain
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //SB
        //======================================================================================================================================
        bool isOption = false;
        bool isBack = false;
        bool isExit = false;
        bool isStart = false;
        public Texture2D start1, start2, exit1, exit2;
        Vector2 startPos;
        Vector2 exitPos;

        
        //======================================================================================================================================
        Texture2D mainBackGround,welcomeBackGround,option,optionBack;
        Texture2D main,back1,firstBackGround,title,gameOver;
        Texture2D mainSprite;

        Texture2D backLevel1, backLevel2;


        public int shootEnemies = 0;
        Texture2D life1;
        Texture2D mainlife1,mainlife2,mainlife3,mainlife4,mainlife5;
        public float lifeMain = 100;

        
         float rotation =1f;
         bool isScreen = false;
         bool isDraw = false, isDraw2 = false, isDraw3 = false;
        bool state = false;   
        SpriteFont font;

        int level = 1;

        
        public Vector2 mainPosition = new Vector2(300,100);
        Vector2 mainPosition2 = new Vector2(1, 10);
        Vector2 mainPosition3 = new Vector2(1400, 75);

        public Vector2 allPosition;

        Vector2 origin,optionPos ;
        public Vector2 speed = new Vector2(1, 1), speed2 = new Vector2(1, 1), speed3 = new Vector2(1, 1);
        const float tangetialVelocity = 5f;
        float friction = 0.1f;


        SoundEffect shootingSong;
        Song playingMusic,openingMusic,GameoverMusic;
        public int score = 0;

        Vector2 mainDirection1;
        Vector2 mousePosition, mousePosition2;
        Vector2 mainLifePos;
        //======================================================Camera============================================================================
        int life;
        public int factor = 3;
        public int ratio = 12;
        int vitualWorldX = 0, vitualWordY = 0;
        public int ScreenSizeX = 0, ScreenSizeY = 0;

        public Texture2D miniMap, miniCamera;
       public Vector2 miniMapPosition = new Vector2(0, 576), miniCamPos;
        public Vector2 camera = Vector2.Zero;
        //=====================================================Classes====================================================================
      
        ViewCamera viewCam;
        List<Enemies>enemies = new List<Enemies>();
        List<Bullets> bullets = new List<Bullets>();
        Random random = new Random();
        userControlled userC;
        Collision collision;
        Evading evade;
        public Game1()
        {


            graphics = new GraphicsDeviceManager(this);
            ScreenSizeX = 1024; ScreenSizeY = 768;
            vitualWorldX = 3072; ; vitualWordY = 2304;
            graphics.PreferredBackBufferWidth = ScreenSizeX;
            graphics.PreferredBackBufferHeight = ScreenSizeY;
            Content.RootDirectory = "Content";


        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
            
        {
            optionPos = new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 2-120);
            exitPos = new Vector2(Window.ClientBounds.Width / 2  - 100  , Window.ClientBounds.Height / 2 );
            startPos = new Vector2(Window.ClientBounds.Width / 2 - 100 , 100);
            mainLifePos = new Vector2(camera.X + 4400, camera.Y + 3000);
            IsMouseVisible = true;
           // B = new Bullets();
            //===========================================================================classes==================================
           viewCam = new ViewCamera(GraphicsDevice.Viewport);

           life = 30;
            //====================================================================================================================
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
          
            spriteBatch = new SpriteBatch(GraphicsDevice);
            userC = new userControlled(Content.Load<Texture2D>(@"images/sprites/spaceship"), new Vector2(0f, 0f), new Vector2(64f, 64f), graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            collision = new Collision(Content.Load<Texture2D>(@"images/flame"));
            evade = new Evading(Content.Load<Texture2D>(@"images/sprites/alien"));
            //=============================================================Camera===============================================
            miniCamera = Content.Load<Texture2D>(@"images/camera/cam");
            miniMap = Content.Load<Texture2D>(@"images/camera/miniMap");
            //==========================================================================================================================
            mainBackGround = Content.Load<Texture2D>(@"images/background1");
            welcomeBackGround = Content.Load<Texture2D>(@"images/welcoming");
            main = Content.Load<Texture2D>(@"images/main");
            back1 = Content.Load<Texture2D>(@"images/Untitled");
            firstBackGround = Content.Load<Texture2D>(@"images/first");
            title = Content.Load<Texture2D>(@"images/title");
            gameOver = Content.Load<Texture2D>(@"images/gameOver1");

            backLevel1 = Content.Load<Texture2D>(@"images/back3");
            backLevel2 = Content.Load<Texture2D>(@"images/camera/back2");
            optionBack = backLevel2 = Content.Load<Texture2D>(@"images/option");

            miniMapPosition = new Vector2(0, ScreenSizeY - miniMap.Height);
            //=============================================================Buttons======================================================
            start1 = Content.Load<Texture2D>(@"images/Welcoming/btn1");
            start2 = Content.Load<Texture2D>(@"images/Welcoming/btn2");
            exit1 = Content.Load<Texture2D>(@"images/Welcoming/btn7");
            exit2 = Content.Load<Texture2D>(@"images/Welcoming/btn8");
            option = Content.Load<Texture2D>(@"images/Welcoming/btn5");
            //===============================================================FONT=====================================================
            font = Content.Load<SpriteFont>("Fonts\\newGame");
            //===============================================================Sprites===================================================
            mainSprite = Content.Load<Texture2D>(@"images/sprites/spaceship");
            userC.velocity = new Vector2(1, 1);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //==============================================================Life======================================================
            life1 = Content.Load<Texture2D>(@"images/life /life1");

            mainlife1 = Content.Load<Texture2D>(@"images/life /mainlife");
            mainlife2 = Content.Load<Texture2D>(@"images/life /mainlife2");
            mainlife3 = Content.Load<Texture2D>(@"images/life /mainlife3");
            mainlife4 = Content.Load<Texture2D>(@"images/life /mainlife4");
            mainlife5 = Content.Load<Texture2D>(@"images/life /mainlife5");
            //=============================================================Music======================================================
            shootingSong = Content.Load<SoundEffect>(@"music/shot");
            playingMusic = Content.Load<Song>(@"music/dead");
            openingMusic = Content.Load<Song>(@"music/Entrance");
            GameoverMusic = Content.Load<Song>(@"music/Entrance");
            MediaPlayer.Play(openingMusic);
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            userC.texture.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        float spawn = 0;
        protected override void Update(GameTime gameTime)
        {
            Mouse.WindowHandle = this.Window.Handle;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            mainLifePos = new Vector2(camera.X + 440, camera.Y + 700);



            
            MouseState mouseState = Mouse.GetState();
            if (Mouse.GetState().X <= miniMap.Width && Mouse.GetState().X >= 0 && Mouse.GetState().Y >= ScreenSizeY - miniMap.Height && Mouse.GetState().Y <= ScreenSizeY)
            {
                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    //camera.X = (Mouse.GetState().X -80) * ratio;
                    
                    //camera.X = Mouse.GetState().X;
                    camera.X= miniMapPosition.X + (Mouse.GetState().X - miniCamera.Width - miniMapPosition.X) *ratio;
                    camera.Y = miniMapPosition.Y + (Mouse.GetState().Y - miniCamera.Height - miniMapPosition.Y) * 7;  }}

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            { camera.X -= 3;}
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                camera.X += 3;
                if (camera.X + miniCamera.Width * 2 >= 2900) camera.X = 2500;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                camera.Y -= 3;}
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {camera.Y += 3;
                if (camera.Y + miniCamera.Height * 2 >= 1740) camera.Y = 1740;
            }
            if (camera.X <= 0) { camera.X = 0 * factor; }
            if (camera.Y <= 0) { camera.Y = 0 * factor; }
            //=============================================================================================================================
           //isStart = false;
           // isExit = false;

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {

                 isScreen = true;
            }

            Rectangle mouseRect = new Rectangle((int)mouseState.X, (int)mouseState.Y, start1.Width, start1.Height);
            Rectangle startRec = new Rectangle((int)startPos.X, (int)startPos.Y, mainSprite.Width, mainSprite.Height);
            Rectangle optionRecta = new Rectangle((int)optionPos.X, (int)optionPos.Y, option.Width, option.Height);
            Rectangle exitRect = new Rectangle((int)exitPos.X, (int)exitPos.Y, exit1.Width, exit1.Height);
            mousePosition2 = new Vector2(mouseState.X, mouseState.Y);

            if (mouseRect.Intersects(startRec))
            {
                isStart = true;
                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    state = true;
                    MediaPlayer.Play(playingMusic);
                }
            }
            else if (mouseRect.Intersects(optionRecta))
            {
               // isOption = true;
               // isBack = true;

                if (Keyboard.GetState().IsKeyDown(Keys.Enter)){
                   // isBack = false;
                    //isOption = false;
                
                }

            }
            else if (mouseRect.Intersects(exitRect))
            {
                isExit = true;
               // if(isExit == true)
                //Exit();
            }
          
            //===========================================================================================================================
            Rectangle mouseRecta = new Rectangle((int)Mouse.GetState().X, (int)Mouse.GetState().Y, 140, 140);
           
            Rectangle spriteMainRect1 = new Rectangle((int)mainPosition.X, (int)mainPosition.Y, mainSprite.Width, mainSprite.Height);
            Rectangle spriteMainRect2 = new Rectangle((int)mainPosition2.X, (int)mainPosition2.Y, mainSprite.Width, mainSprite.Height);
            Rectangle spriteMainRect3 = new Rectangle((int)mainPosition3.X, (int)mainPosition3.Y, mainSprite.Width, mainSprite.Height);

            if (mouseRecta.Intersects(spriteMainRect1))
            {
                if (Mouse.GetState().RightButton == ButtonState.Pressed)
                {
                    isDraw = true;
                }
            }
            else
            {

                if (Mouse.GetState().RightButton == ButtonState.Pressed)
                    isDraw = false;
            }
            //===============================================
            if (mouseRecta.Intersects(spriteMainRect2))
            {
                if (Mouse.GetState().RightButton == ButtonState.Pressed)
                {
                    isDraw2 = true;
                }
            }
            else
            {
                if (Mouse.GetState().RightButton == ButtonState.Pressed)
                    isDraw2 = false;
            }

            if (mouseRecta.Intersects(spriteMainRect3))
            {
                if (Mouse.GetState().RightButton == ButtonState.Pressed)
                {
                    isDraw3 = true;
                }
            }
            else
            {
                   if (Mouse.GetState().RightButton == ButtonState.Pressed)
                    isDraw3 = false;
            }

            //===================================================================================================================================

            if (isDraw == false)
            {

                Rectangle mainSpriteRec = new Rectangle((int)mainPosition.X, (int)mainPosition.Y, mainSprite.Width, mainSprite.Height);
                mainPosition += speed;
                origin = new Vector2(mainSpriteRec.Width / 2, mainSpriteRec.Height / 2);
                if (Keyboard.GetState().IsKeyDown(Keys.Right)) rotation += 0.1f;

                if (Keyboard.GetState().IsKeyDown(Keys.Left)) rotation -= 0.1f;

                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    speed.X = (float)Math.Cos(rotation) * tangetialVelocity;
                    speed.Y = (float)Math.Sin(rotation) * tangetialVelocity;

                }
                else if (speed != Vector2.Zero)
                {
                    float i = speed.X;
                    float j = speed.Y;

                    speed.X = i -= friction * i;
                    speed.Y = j -= friction * j;
                }
            }
            else
            {
                MouseState mousestate = Mouse.GetState();

                mousePosition = new Vector2(mousestate.X, mousestate.Y);
                mainDirection1 = (Vector2)mousePosition - mainPosition;
                mainDirection1.Normalize();

                if (mouseState.LeftButton == ButtonState.Pressed && Vector2.Distance(mousePosition, mainPosition) > 60)
                {
                    mainPosition+= mainDirection1 * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 5;
                 
                }

            }
            //-----------------------------------------------RECTANGLE2------------------------------------------------------

            if (isDraw2 == false)
            {
                mainPosition2 += speed2;

                if (mainPosition2.Y <= 0 || mainPosition2.Y >= 1900)
                    speed2.Y *= -1;
                if (mainPosition2.X <= 0 || mainPosition2.X >= 3200)
                    speed2.X *= -1;
            }
            else
            {
                MouseState mousestate = Mouse.GetState();

                mousePosition = new Vector2(mousestate.X, mousestate.Y);
                mainDirection1 = (Vector2)mousePosition - mainPosition2;
                mainDirection1.Normalize();

                if (mouseState.LeftButton == ButtonState.Pressed && Vector2.Distance(mousePosition, mainPosition2) > 60)
                {
                    mainPosition2 += mainDirection1 * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 5;

                }

            }



            if (isDraw3 == false)
            {
                mainPosition3 += speed3;
                if (mainPosition3.Y <= 0 || mainPosition3.Y >= 1900)
                    speed3.Y *= -1;
                if (mainPosition2.X <= 0 || mainPosition2.X >= 3200)
                    speed3.X *= -1;
            }
            else
            {
                MouseState mousestate = Mouse.GetState();

                mousePosition = new Vector2(mousestate.X, mousestate.Y);
                mainDirection1 = (Vector2)mousePosition - mainPosition3;
                mainDirection1.Normalize();

                if (mouseState.LeftButton == ButtonState.Pressed && Vector2.Distance(mousePosition, mainPosition3) > 60)
                {
                    mainPosition3 += mainDirection1 * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 5;

                }

            }

           //===========================================================================================================
            userC.position(gameTime);
            spawn += (float)gameTime.ElapsedGameTime.TotalSeconds ;

            foreach (Enemies enemy in enemies)
            enemy.Update(graphics.GraphicsDevice, gameTime,life);
            loadEnemies();
            //=============================================CameraMoveMent======================================================
            
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Shoot();   
            }

            collision.getPositions(mainPosition);
            bulletInMainSpprite();
            //collision.getPositions(enemies.)
            foreach (Bullets bullet in bullets) {
            bullet.pos(miniMapPosition, ratio, camera);}
            evade.evade(mainPosition, miniMapPosition, ratio, camera);
            collision.Update(gameTime);
           attacking();
            updateBullets();
            CheckBulletHits();
            viewCam.Update(gameTime, this);
            base.Update(gameTime);
        }


        protected void CheckBulletHits()
        {
            for (int i = 0; i < bullets.Count; i++) {
                if (bullets[i].isVisible)
                {
                    for (int x = 0; x < enemies.Count; x++)
                        if (enemies[x].isVisible)
                        {

                           
                         if (Intersects(bullets[i].BoundingBox,
                                          enemies[x].BoundingBox))
                            {
                                enemies[x].life -=1;
                                
                             if (score >= 10)
                                    level = 2;
                                
                               if (enemies[x].life <= 5)
                               {
                                   score += 1;
                                    enemies.RemoveAt(x);
                                    shootEnemies += 1;
                               }
                            }
                        }
                }
            }
        }

        void bulletInMainSpprite() {

             for (int x = 0; x < enemies.Count; x++)
                 if (enemies[x].isVisible)
                 {
                     if (mainBox.Intersects(enemies[x].bulletRecta))
                     //lifeMain -= 1f;

                     if (mainBox.Intersects(enemies[x].lifeAddingRecta))
                         lifeMain += 20;
 

                 }
        }
            /*
            for (int x = 0; x < enemies.Count; x++)
                        if (enemies[x].isVisible)
                        {           if (Intersects2(enemies[x].BoundingBox,
                                             mainBox))
                            {
                               lifeMain -= 1;

                                if (lifeMain <= 4)
                                {
                                    dead = true;
                                }
                            
                        }
                
            }
        




            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].isVisible)
                {



                    if (Intersects(bullets[i].BoundingBox,
                                     mainBox))
                    {
                       

                        score -= 100;
                        lifeMain -= 1;
                        //if (lifeMain <= 5)
                        //{
                           
                            //    x--;
                        //}
                    }

                }


            }

        
        }*/
        public Rectangle mainBox
        {
            get { return new Rectangle((int)mainPosition.X, (int)mainPosition.Y, mainSprite.Width, mainSprite.Height); }
        }
        protected bool Intersects(Rectangle rectA, Rectangle rectB)
        {
            // Returns True if rectA and rectB contain any overlapping points
            return (rectA.Right > rectB.Left && rectA.Left < rectB.Right &&
                    rectA.Bottom > rectB.Top && rectA.Top < rectB.Bottom);
        }
       
        /*
        protected void BulletHits()
        {
            // Check to see of any of the players bullets have 
            // impacted any of the enemies.
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].is)
                    for (int x = 0; x < iTotalMaxEnemies; x++)
                        if (enemies[x].IsActive)
                            if (Intersects(bullets[i].BoundingBox,
                                           enemies[x].CollisionBox))
                            {
                                DestroyEnemy(x);
                                RemoveBullet(i);
                            }
            }

            // If we have run out of active enemies, generate new ones
            //if (iActiveEnemies < 1)
                //StartNewWave();
        }*/
        public void updateBullets() {

            foreach (Bullets bullet in bullets) {
                bullet.positionB += bullet.speed;
                if(Vector2.Distance(bullet.positionB,mainPosition) > 500)
                    bullet.isVisible = false;
            
            }
            for (int i = 0; i < bullets.Count; i++)
                if (!bullets[i].isVisible)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
        
        }

        public void attacking()
        {

            foreach (Enemies enemy in enemies)
            {
                
               if (Vector2.Distance(mainPosition, enemy.position) > 400)
                {

                    if (mainPosition.X < enemy.position.X)
                        enemy.position.X -= 1;
                    else if (mainPosition.X > enemy.position.X)
                        enemy.position.X += 1;
                    if (mainPosition.Y < enemy.position.Y)
                        enemy.position.Y -= 1;
                    else if (mainPosition.Y > enemy.position.Y)
                        enemy.position.Y += 1;

                }

                /*

                if (Vector2.Distance(mainPosition, enemy.position) < 50)
                {
                    //chase = 
                    if (mainPosition.X < enemy.position.X)
                        mainPosition.X -= speed.X;
                    else if (mainPosition.X > enemy.position.X)
                        mainPosition.X += speed.X;
                    if (mainPosition.Y < enemy.position.Y)
                        mainPosition.Y -= speed.Y;
                    else if (mainPosition.Y > enemy.position.Y)
                        mainPosition.Y += speed.Y;
                */
                    /*  if (Vector2.Distance(mainPosition2, enemy.position) < 50)
                      {
                          enemy.position += enemy.speed;
                          if (enemy.position.Y <= 0 || enemy.position.Y >= 1900)
                              speed.Y *= -1;
                          if (enemy.position.X <= 0 || enemy.position.X >= 3200)
                              speed.X *= -1;

                      }
                      else
                      {

                          if (mainPosition2.X < enemy.position.X)
                              enemy.position.X -= 1;
                          else if (mainPosition2.X > enemy.position.X)
                              enemy.position.X += 1;
                          if (mainPosition2.Y < enemy.position.Y)
                              enemy.position.Y -= 1;
                          else if (mainPosition2.Y > enemy.position.Y)
                              enemy.position.Y += 1;
                      }*/
               // }
                enemy.eachPpos = new Vector2(miniMapPosition.X + enemy.position.X / ratio + camera.X, miniMapPosition.Y + enemy.position.Y / ratio + camera.Y);
                enemy.eachPpos2 = new Vector2(miniMapPosition.X + enemy.addingPosition.X / ratio + camera.X, miniMapPosition.Y + enemy.addingPosition.Y / ratio + camera.Y);
            }

        }
        public void Shoot() {
            SoundEffectInstance soundEffectInstance =   shootingSong.CreateInstance(); 
            soundEffectInstance.Play();

            Bullets newBullet = new Bullets(Content.Load<Texture2D>(@"images/sprites/bullet2"));
            newBullet.speed = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation)) * 6f+ speed;
            newBullet.positionB = (mainPosition) + newBullet.speed * 5;
            newBullet.isVisible = true;

            if (bullets.Count() < 20)
                bullets.Add(newBullet);
        }

        public void loadEnemies() {

            int enemiesAdd = 0;
            if (shootEnemies <= 5)
                enemiesAdd = 2;
            else if (shootEnemies <= 10)
                enemiesAdd = 6;
              else if (shootEnemies <= 15)
                enemiesAdd =10 ;

            int Yval = random.Next(100, 1000);
            int Xval = random.Next(0, 3200);
  

        if (spawn >=1)
        {
            spawn = 0;
            if(enemies.Count()< 9)
                if(level == 1)
                enemies.Add(new Enemies(Content.Load<Texture2D>(@"images/sprites/S2"), new Vector2(Xval, Yval), Content.Load<Texture2D>(@"images/sprites/bullet")
                    , Content.Load<Texture2D>(@"images/life/life1"), Content.Load<Texture2D>(@"images/life/life2"), Content.Load<Texture2D>(@"images/life/life3"), Content.Load<Texture2D>(@"images/life/life4"), Content.Load<Texture2D>(@"images/life/life5"), Content.Load<Texture2D>(@"images/sprites/A4")));
                if(level == 2)
                    if (enemies.Count() < enemiesAdd)
                    enemies.Add(new Enemies(Content.Load<Texture2D>(@"images/sprites/A6"), new Vector2(Xval, Yval), Content.Load<Texture2D>(@"images/sprites/bullet")
                    , Content.Load<Texture2D>(@"images/life/life1"), Content.Load<Texture2D>(@"images/life/life2"), Content.Load<Texture2D>(@"images/life/life3"), Content.Load<Texture2D>(@"images/life/life4"), Content.Load<Texture2D>(@"images/life/life5"), Content.Load<Texture2D>(@"images/sprites/A4")));
        
        }
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Brown);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, viewCam.Transform);

            switch (state) { 
                case false :

                    if (isScreen == false) {
                        spriteBatch.Draw(firstBackGround, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.7f);
                        spriteBatch.Draw(back1, new Vector2(100, 400), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.6f);
                        spriteBatch.Draw(title, new Vector2(50, 0), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.5f);
                    
                    }

                    else if (isScreen == true)
                    {
                        if (isOption == false && isBack==false)
                        {

                            if (isStart == false)
                                spriteBatch.Draw(start2, startPos, Color.White);

                            else
                                spriteBatch.Draw(start1, startPos, Color.White);
                            if (isExit == false)
                                spriteBatch.Draw(exit1, exitPos, Color.White);
                            else
                                spriteBatch.Draw(exit2, exitPos, Color.White);
                            spriteBatch.Draw(option, optionPos, Color.White);
                            spriteBatch.Draw(welcomeBackGround, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.7f);
                        }
                        else {
                            spriteBatch.Draw(title, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.7f);
                            spriteBatch.Draw(optionBack, new Vector2(0, 130), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.7f);
                           // spriteBatch.Draw(option, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.2f);
                        }
                    } 
                        break;
//===============================================================================================================================
                case true :
                        if (lifeMain >= 0)
                        {
                            if (level == 1)
                            {
                                spriteBatch.DrawString(font, "Camera [ X" + camera.X.ToString() + ":Y" + camera.Y.ToString() + "]", camera, Color.Red);
                                // spriteBatch.DrawString(font, "Camera [ X" + camera.X.ToString() + ":Y" + camera.Y.ToString() + "]", camera, Color.White);
                                spriteBatch.Draw(main, new Vector2(camera.X, camera.Y + 50), null, Color.Red, 0, Vector2.Zero, 0.9f, SpriteEffects.None, 0.3f);
                                spriteBatch.Draw(mainBackGround, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0.7f);
                                spriteBatch.Draw(welcomeBackGround, new Vector2(2600, 0), null, Color.White, 0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0.7f);
                               
                            
                            }
                            else {
                                spriteBatch.Draw(main, new Vector2(camera.X, camera.Y + 50), null, Color.White, 0, Vector2.Zero, 0.9f, SpriteEffects.None, 0.2f);
                                spriteBatch.Draw(backLevel1, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 0.3f);
                                spriteBatch.Draw(backLevel2, new Vector2(2600, 0), null, Color.White, 0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0.7f);
                            }
                                /// spriteBatch.DrawString(font, mainPosition2.ToString(), new Vector2(mainPosition2.X - 20, mainPosition2.Y + 50), Color.White);
                            spriteBatch.DrawString(font, "GAME LEVEL ( " + level.ToString() + ")", new Vector2(mainLifePos.X, mainLifePos.Y - 50), Color.Blue);
                            spriteBatch.DrawString(font, "SCORE < " + score.ToString() + ">", new Vector2(camera.X + 890, camera.Y), Color.Red);
                            spriteBatch.DrawString(font, "SPACE WARRIOR ", new Vector2(camera.X + 400, camera.Y), Color.Red, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.2f);


                            userC.Draw(spriteBatch);

                            if (lifeMain <= 30)
                            {

                                collision.Draw(spriteBatch);

                            }
                            else
                            {
                                //MainSprite1
                                spriteBatch.DrawString(font, mainPosition.ToString(), new Vector2(mainPosition.X - 20, mainPosition.Y + 50), Color.White);
                                spriteBatch.Draw(mainSprite, mainPosition, null, Color.White, (rotation - 4.75f), origin, 1f, SpriteEffects.None, 0.2f);
                                spriteBatch.Draw(mainSprite, new Vector2(miniMapPosition.X + mainPosition.X / ratio + camera.X, miniMapPosition.Y + mainPosition.Y / ratio + camera.Y), null, Color.White, rotation - 4.7f, origin, 0.10f, SpriteEffects.None, 0.2f);
                            }



                            evade.Draw(spriteBatch);
                            foreach (Enemies enemy in enemies)
                                enemy.Draw(spriteBatch);

                            foreach (Bullets bullet in bullets)
                                bullet.Draw(spriteBatch);

                            if (isDraw == true)
                            {
                                Texture2D rect = new Texture2D(graphics.GraphicsDevice, 145, 160); Color[] data = new Color[145 * 160]; for (int i = 0; i < data.Length; ++i) data[i] = Color.Green;
                                rect.SetData(data); Vector2 color = new Vector2(mainPosition.X + 20, mainPosition.Y);

                                spriteBatch.Draw(rect, color, null, Color.White, rotation - 4.7f, origin, 1, SpriteEffects.None, 0.3f);
                            }
                            if (isDraw2 == true)
                            {
                                Texture2D rect = new Texture2D(graphics.GraphicsDevice, 145, 160); Color[] data = new Color[145 * 160]; for (int i = 0; i < data.Length; ++i) data[i] = Color.Green;
                                rect.SetData(data); Vector2 color = new Vector2(mainPosition2.X + 20, mainPosition2.Y);

                                spriteBatch.Draw(rect, color, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.3f);
                            }
                            if (isDraw3 == true)
                            {
                                Texture2D rect = new Texture2D(graphics.GraphicsDevice, 145, 160); Color[] data = new Color[145 * 160]; for (int i = 0; i < data.Length; ++i) data[i] = Color.Green;
                                rect.SetData(data); Vector2 color = new Vector2(mainPosition3.X + 20, mainPosition3.Y);

                                spriteBatch.Draw(rect, color, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.3f);
                            }
                          
                            //mainSprite2
                            spriteBatch.DrawString(font, mainPosition2.ToString(), new Vector2(mainPosition2.X - 20, mainPosition2.Y + 50), Color.White);
                            spriteBatch.Draw(mainSprite, mainPosition2, null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.2f);
                            spriteBatch.Draw(mainSprite, new Vector2(miniMapPosition.X + mainPosition2.X / ratio + camera.X, miniMapPosition.Y + mainPosition2.Y / ratio + camera.Y), null, Color.White, 0, Vector2.Zero, 0.10f, SpriteEffects.None, 0.2f);

                            //MainSprite3
                            spriteBatch.DrawString(font, mainPosition3.ToString(), new Vector2(mainPosition3.X - 20, mainPosition3.Y + 50), Color.White);
                            spriteBatch.Draw(mainSprite, mainPosition3, null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.2f);
                            spriteBatch.Draw(mainSprite, new Vector2(miniMapPosition.X + mainPosition3.X / ratio + camera.X, miniMapPosition.Y + mainPosition3.Y / ratio + camera.Y), null, Color.White, 0, Vector2.Zero, 0.10f, SpriteEffects.None, 0.2f);


                            spriteBatch.DrawString(font, "MY LIFE [ " + lifeMain.ToString() + "% ]", new Vector2(mainLifePos.X, mainLifePos.Y -30 ), Color.Red);
                            if (lifeMain >= 90)
                                spriteBatch.Draw(mainlife1, mainLifePos, Color.White);
                            else if (lifeMain >= 70)
                                spriteBatch.Draw(mainlife2, mainLifePos, Color.White);
                            else if (lifeMain >= 40)
                                spriteBatch.Draw(mainlife3, mainLifePos, Color.White);
                            else if (lifeMain >= 20)
                                spriteBatch.Draw(mainlife4, mainLifePos, Color.White);
                            else if (lifeMain >= 10)
                                spriteBatch.Draw(mainlife5, mainLifePos, Color.White);

                            spriteBatch.Draw(miniCamera, new Vector2(miniMapPosition.X + camera.X / ratio + camera.X, miniMapPosition.Y + camera.Y / ratio + camera.Y), null, Color.Red, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
                        }
                        else {
                            spriteBatch.DrawString(font, "SCORE < " + score.ToString() + ">", new Vector2(camera.X , camera.Y+150), Color.Red);
                            spriteBatch.Draw(gameOver, camera, null, Color.White, 0f, Vector2.Zero, 1.4f, SpriteEffects.None, 0.7f);
                        
                        
                        }
                            break;
                        
            }  
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
