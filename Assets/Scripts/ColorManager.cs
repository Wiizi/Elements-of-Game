using System.Collections.Generic;
using UnityEngine;

namespace ColorManagement
{
    // maintains an iterator list of unique colors that look good
    // if quering too many colors, random colors will be generated instead
    public class ColorManager
    {
        public static ColorManager ColorManagerInstance = new ColorManager();
        
        private List<Color> Colors;
        private static int colorNum;

        public static Color NewColor255(int r, int g, int b)
        {
            return new Color(r / 255.0f, g / 255.0f, b / 255.0f);
        }
        
        public ColorManager()
        {
            // add some nice 'proven' colors first
            this.Colors = new List<Color>();
            this.Colors.Add(Color.red);
            this.Colors.Add(Color.blue);
            this.Colors.Add(Color.yellow);
            this.Colors.Add(Color.cyan);
            this.Colors.Add(Color.magenta);
            this.Colors.Add(NewColor255(122, 244, 66)); // light green
            this.Colors.Add(NewColor255(244, 131, 66)); // orange
            this.Colors.Add(NewColor255(119, 49, 7)); // brown
            this.Colors.Add(NewColor255(6, 79, 18)); // dark green
            this.Colors.Add(NewColor255(116, 13, 219)); // violet
            this.Colors.Add(NewColor255(219, 13, 147)); // purple
        }

        public static Color NextColor()
        {
            Color color;
            if (colorNum < ColorManagerInstance.Colors.Count)
            {
                color = ColorManagerInstance.Colors[colorNum];
            }
            else
            {
                color = UnityEngine.Random.ColorHSV();
            }
            
            colorNum++;
            return color;
        }
        
    }
}
