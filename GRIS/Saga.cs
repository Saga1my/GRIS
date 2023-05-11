using Raylib_cs;
using System.Numerics;

namespace Character
{
    public class Player
    {
        List<Texture2D> SagaWalkingRight = new List<Texture2D>(){
            Raylib.LoadTexture("Bilder/Saga_walking/SagaWalkingRight1.png"),
            Raylib.LoadTexture("Bilder/Saga_idle/RightViewSaga.png"),
            Raylib.LoadTexture("Bilder/Saga_walking/SagaWalkingRight1.png"),
            Raylib.LoadTexture("Bilder/Saga_idle/RightViewSaga.png")
        };
        List<Texture2D> SagaWalkingLeft = new List<Texture2D>(){
            Raylib.LoadTexture("Bilder/Saga_walking/SagaWalkingLeft1.png"),
            Raylib.LoadTexture("Bilder/Saga_idle/LeftViewSaga.png"),
            Raylib.LoadTexture("Bilder/Saga_walking/SagaWalkingLeft1.png"),
            Raylib.LoadTexture("Bilder/Saga_idle/LeftViewSaga.png")

        };
        Dictionary<string, Texture2D> SagaTextures = new Dictionary<string, Texture2D> {
            {"avatar", Raylib.LoadTexture("Bilder/Saga_idle/FrontViewSaga.png")},
            {"back", Raylib.LoadTexture("Bilder/Saga_idle/BackViewSaga.png")},
            {"left", Raylib.LoadTexture("Bilder/Saga_idle/LeftViewSaga.png")},
            {"right", Raylib.LoadTexture("Bilder/Saga_idle/RightViewSaga.png")}
        };

        List<Texture2D> SagaWalkingUp = new List<Texture2D>(){
            Raylib.LoadTexture("Bilder/Saga_walking/SagaWalkingUp1.png"),
            Raylib.LoadTexture("Bilder/Saga_idle/BackViewSaga.png"),
            Raylib.LoadTexture("Bilder/Saga_walking/SagaWalkingUp2.png"),
            Raylib.LoadTexture("Bilder/Saga_idle/BackViewSaga.png")
        };
        List<Texture2D> SagaWalkingDown = new List<Texture2D>(){
            Raylib.LoadTexture("Bilder/Saga_walking/SagaWalkingDown1.png"),
            Raylib.LoadTexture("Bilder/Saga_idle/FrontViewSaga.png"),
            Raylib.LoadTexture("Bilder/Saga_walking/SagaWalkingDown2.png"),
            Raylib.LoadTexture("Bilder/Saga_idle/FrontViewSaga.png")
        };
        public Rectangle character = new Rectangle(Raylib.GetScreenWidth() / 2 - 50, Raylib.GetScreenHeight() / 2 - 50, 150, 150);
        Texture2D CurrentTexture;

        public void drawCharacter()
        {

            // must be called within Raylib drawing
            Raylib.DrawTexturePro(CurrentTexture, new Rectangle(0, 0, CurrentTexture.width, CurrentTexture.height), character, Vector2.Zero, 0f, Color.WHITE);
        }

        int WalkingAnimation = 0;
        int WalkingAnimationIndex = 0;


        public void checkWalking()
        {
            List<Texture2D> currentTextureSet = new List<Texture2D>() { SagaTextures["avatar"] };

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                character.y -= 7;
                currentTextureSet = SagaWalkingUp;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                character.x -= 7;
                currentTextureSet = SagaWalkingLeft;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                character.x += 7;
                currentTextureSet = SagaWalkingRight;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                character.y += 7;
                currentTextureSet = SagaWalkingDown;
            }

            WalkingAnimation++;
            if (WalkingAnimation >= 10)
            {
                WalkingAnimation = 0;
                if (WalkingAnimationIndex >= currentTextureSet.Count() - 1)
                {
                    WalkingAnimationIndex = 0;
                }
                else
                {
                    WalkingAnimationIndex++;
                }
                CurrentTexture = currentTextureSet[WalkingAnimationIndex];
            }
        }

        public Vector2 checkBackgound()
        {

            if ((int)character.x < 10)
            {
                return new Vector2(-1, 0);
            }
            else if ((int)character.x > (Raylib.GetScreenWidth() - 150))
            {
                return new Vector2(1, 0);
            }
            else if ((int)character.y < 10)
            {
                return new Vector2(0, -1);
            }
            else if ((int)character.y > (Raylib.GetScreenHeight() - 150))
            {
                return new Vector2(0, 1);
            }
            else { return new Vector2(0, 0); };
        }
    }
}