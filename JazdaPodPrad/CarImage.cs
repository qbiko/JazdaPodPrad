using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazdaPodPrad
{
    public class CarImage
    {
        public const int WidthTexture = 80;
        public const int HeightTexture = 140;
        public Texture2D Image { get; }
        public int[] Margin { get; }
        public int WidthImage { get; }
        public int HeightImage { get; }

        public CarImage(Texture2D nImage, int left, int top, int right, int bottom)
        {
            Image = nImage;
            Margin = new int[] { left, top, right, bottom };
            Array.Reverse(Margin);
            WidthImage = WidthTexture - left - right;
            HeightImage = HeightTexture - top - bottom;
        }
    }
}
