using Raylib_cs;

class Background
{
    public Texture2D backgroundImage;
    public List<Rectangle> colliders = new List<Rectangle>
    {
            new Rectangle(665, 340, 1000, 500) // Grishus
    };

    public Background(Texture2D backgroundImage, List<Rectangle> colliders)
    {
        this.backgroundImage = backgroundImage;
        this.colliders = colliders;
    }
}