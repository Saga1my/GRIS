using Raylib_cs;
using System.Numerics;
using Pig;

namespace Potato
{
    public class Potatoes
    {
        static Rectangle potatis = new Rectangle(10, 10, 1000, 100);
        static Rectangle peng = new Rectangle(10, 650, 1000, 100);
        static Rectangle bacon = new Rectangle(1115, 10, 1000, 100);
        public static int AmountPotatoes = 2;
        static Texture2D potatistexture = Raylib.LoadTexture("Bilder/Potato.png");
        static Texture2D bacontexture = Raylib.LoadTexture("Bilder/Bacon.png");
        static Texture2D Pengtexture = Raylib.LoadTexture("Bilder/Peng.png");
        public static void drawPotato()
        {
            // must be called within Raylib drawing
            Raylib.DrawTexture(potatistexture, (int)potatis.x, (int)potatis.y, Color.WHITE);
            Raylib.DrawText($"{AmountPotatoes}", 100, 30, 50, Color.BLACK);
        }
        static public void drawPeng()
        {

            Raylib.DrawTexture(Pengtexture, (int)peng.x, (int)peng.y, Color.WHITE);

        }
        static public void drawBacon()
        {

            Raylib.DrawTexture(bacontexture, (int)bacon.x, (int)bacon.y, Color.WHITE);
            

        }
    }

}