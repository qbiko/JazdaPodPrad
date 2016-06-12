using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace JazdaPodPrad
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D background;
        public Texture2D blueCar;
        public Texture2D greenCar;
        public Texture2D yellowCar;
        public Texture2D greyCar;
        public Texture2D orangeCar;
        public Texture2D redCar;
        private Texture2D menu;
        private Texture2D gameOver;
        private SpriteFont font;
        public CarImage Blue;
        public CarImage Green;
        public CarImage Yellow;
        public CarImage Grey;
        public CarImage Orange;
        public CarImage Red;
        public MyCar myCar;
        public Car trapCar1;
        public Car trapCar2;
        public Car trapCar3;
        public Dictionary<string, CarImage> TextureList;
        private int y;
        private int centerOfScreen;
        private int[] x;
        private bool stop;
        private bool gameover;
        private int level;
        private int toNextLevel;
        private int speed;
        public static int score;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            speed = 5;
            stop = false;
            gameover = false;
            score = 0;
            level = 1;
            toNextLevel = 30;
            graphics.PreferredBackBufferWidth = 674; this.graphics.PreferredBackBufferHeight = 600;
            Window.Position = new Point(390, 190);
            Window.Title = "Crazy Driver";
            graphics.ApplyChanges();
            centerOfScreen = (graphics.PreferredBackBufferWidth-100) / 2 - 40;
            x = new int[] { centerOfScreen - 180, centerOfScreen - 90, centerOfScreen, centerOfScreen + 90, centerOfScreen + 180 };
            y = graphics.PreferredBackBufferHeight - 140;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("tlo");
            blueCar = Content.Load<Texture2D>("bluecar");
            greyCar = Content.Load<Texture2D>("greycar");
            orangeCar = Content.Load<Texture2D>("orangecar");
            greenCar = Content.Load<Texture2D>("greencar");
            yellowCar = Content.Load<Texture2D>("yellowcar");
            redCar = Content.Load<Texture2D>("redcar");
            menu = Content.Load<Texture2D>("menu");
            font = Content.Load<SpriteFont>("ArialFont");
            gameOver = Content.Load<Texture2D>("gameover");

            TextureList = new Dictionary<string, CarImage>();

            Blue = new CarImage(blueCar, 14, 3, 11, 13);
            TextureList.Add("Blue", Blue);
            Grey = new CarImage(greyCar, 12, 3, 13, 13);
            TextureList.Add("Grey", Grey);
            Orange = new CarImage(orangeCar, 10, 6, 19, 13);
            TextureList.Add("Orange", Orange);
            Green = new CarImage(greenCar, 12, 4, 11, 9);
            TextureList.Add("Green", Green);
            Yellow = new CarImage(yellowCar, 9, 2, 16, 11);
            TextureList.Add("Yellow", Yellow);
            Red = new CarImage(redCar, 11, 5, 16, 12);
            TextureList.Add("Red", Red);


            myCar = new MyCar(new Vector2(centerOfScreen, y), TextureList);
            trapCar1 = new Car(new Vector2(x[0], -140), TextureList);
            trapCar2 = new Car(new Vector2(x[2], -280), TextureList);
            trapCar3 = new Car(new Vector2(x[4], -420), TextureList);

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F2))
            {
                stop = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F3))
            {
                stop = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F1))
            {
                gameover = false;
                level = 1;
                speed = 5;
                score = 0;
                myCar = new MyCar(new Vector2(centerOfScreen, y), TextureList);
                trapCar1 = new Car(new Vector2(x[0], -140), TextureList);
                trapCar2 = new Car(new Vector2(x[2], -280), TextureList);
                trapCar3 = new Car(new Vector2(x[4], -420), TextureList);
                toNextLevel = 30;
                stop = false;
            }

            try
            {
                myCar.CheckCollision(trapCar1);
                myCar.CheckCollision(trapCar2);
                myCar.CheckCollision(trapCar3);
            }
            catch
            {
                gameover = true;
                stop = true;
            }

            if (!stop)
            {
                trapCar1.ChangePosition(x, speed);
                trapCar2.ChangePosition(x, speed);
                trapCar3.ChangePosition(x, speed);

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    myCar.ChangePosition(0);
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    myCar.ChangePosition(1);
                }
            }

            if (score > toNextLevel)
            {
                level++;
                speed++;
                toNextLevel = toNextLevel * 3 / 2;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(menu, new Vector2(574, 0), Color.White);
            myCar.DrawCar(spriteBatch);
            trapCar1.DrawCar(spriteBatch);
            trapCar2.DrawCar(spriteBatch);
            trapCar3.DrawCar(spriteBatch);
            spriteBatch.DrawString(font, level.ToString(), new Vector2(620, 30), Color.Yellow);
            spriteBatch.DrawString(font, score.ToString(), new Vector2(618, 90), Color.Violet);
            if (gameover)
            {
                spriteBatch.Draw(gameOver, new Vector2(0, 0), Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
