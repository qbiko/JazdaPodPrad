using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazdaPodPrad
{
    public class Car
    {
        public Vector2 Position;
        public CarImage Texture { get; set; }
        public Dictionary<string, CarImage> TextureList { get; set; }

        public Car(Vector2 nPosition, Dictionary<string, CarImage> nTextureList)
        {
            Position = nPosition;
            TextureList = nTextureList;
            ChangeColor();   
        }

        public virtual void DrawCar(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture.Image, Position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipVertically, 0);
        }

        public void ChangePosition(int[] x, int speed)
        {
            if (Position.Y >= 600)
            {
                Position.Y = -140;
                var rand = new Random();
                int temp = rand.Next(0, 5);
                Position.X = x[temp];
                ChangeColor();
                Game1.score++;
            }
            Position.Y += speed;
        }

        private void ChangeColor()
        {
            var rand = new Random();
            int Color = rand.Next(0, 4);
            switch ((ColorCar)Color)
            {
                case ColorCar.Blue:
                    Texture = TextureList["Blue"];
                    break;
                case ColorCar.Red:
                    Texture = TextureList["Red"];
                    break;
                case ColorCar.Grey:
                    Texture = TextureList["Grey"];
                    break;
                case ColorCar.Yellow:
                    Texture = TextureList["Yellow"];
                    break;
                case ColorCar.Green:
                    Texture = TextureList["Green"];
                    break;
                default:
                    Texture = TextureList["Blue"];
                    break;
            }
        }
    }
}
