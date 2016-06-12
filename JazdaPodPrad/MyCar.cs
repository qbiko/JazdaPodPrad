using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazdaPodPrad
{
    public class MyCar : Car
    {
        private float RealPositionY1;
        private float RealPositionY2;
        private int[] Margin;

        public MyCar(Vector2 Position, Dictionary<string, CarImage> TextureList) : base(Position, TextureList)
        {
            Margin = Texture.Margin;
            Array.Reverse(Margin);
            RealPositionY1 = Position.Y - Margin[3] - Texture.HeightImage;
            RealPositionY2 = Position.Y - Margin[3];
        }

        public void ChangePosition(int direction)
        {
            if (direction == 0 && Position.X>=30)
            {
                Position.X -= 10;
            }
            else if(direction==1 && Position.X<=474)
            {
                Position.X += 10;
            }
            
        }
        public void CheckCollision(Car car)
        {
            float realPositionX1 = Position.X + Margin[0];
            float realPositionX2 = Position.X + Margin[0] + Texture.WidthImage;
            float trapCarPositionY1 = car.Position.Y - car.Texture.Margin[1] - car.Texture.HeightImage;
            float trapCarPositionY2 = car.Position.Y - car.Texture.Margin[1];
            float trapCarPositionX1 = car.Position.X + car.Texture.Margin[0];
            float trapCarPositionX2 = car.Position.X + car.Texture.Margin[0] + car.Texture.WidthImage;

            var Collision = new Exception(); 
            
            if (((trapCarPositionY2 <= RealPositionY2 && trapCarPositionY2 >= RealPositionY1) || 
                (trapCarPositionY1 <= RealPositionY2 && trapCarPositionY1 >= RealPositionY1)) && 
                ((trapCarPositionX1>=realPositionX1 && trapCarPositionX1<=realPositionX2) || 
                (trapCarPositionX2 >= realPositionX1 && trapCarPositionX1 <= realPositionX2)))
            {
                throw Collision;
            }
        }
        override public void DrawCar(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture.Image, Position, Color.White);
        }
    }
}
