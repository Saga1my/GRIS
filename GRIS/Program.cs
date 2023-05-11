//Inventory
//sell meat
//buy potato
//put on clothes


using Raylib_cs;
using System.Numerics;
using Character;
using Pig;
using Potato;
using Coding;


Raylib.InitWindow(1280, 720, "GRIS SPELET :D");
Raylib.SetTargetFPS(60);

Player player = new Player();
Stores LoveStore = new Stores();
Pigs Gris1 = new Pigs();
Pigs Gris2 = new Pigs();
Pigs baby = new Pigs();
Pigs Inventory = new Pigs();


Gris2.rectangle.y = 400;



Rectangle Source = new Rectangle(0, 0, 240, 140);
Rectangle Destination = new Rectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight());

Vector2 noll = new Vector2(0, 0);

bool InsideStore = false;
bool Grisar_i_Rörelse = false;
bool Hide = false;

Vector2 startingposition = new Vector2(1, 0);
Vector2 lastPosition;
Vector2 GRISFRAME = new Vector2(2, 1);
Vector2 LoveStoreFRAME = new Vector2(0, 1);
Vector2 whichway;
Vector2 current = new Vector2(1, 0);  //denna del används för att byta bakgrundsbilder


Raylib.SetExitKey(KeyboardKey.KEY_NULL);

Texture2D KILLER = Raylib.LoadTexture("Bilder/killer.png");



Texture2D tex0 = Raylib.LoadTexture("Bilder/backgrounds/Bakgrundsbild-top-left.png");
List<Rectangle> coll0 = new();

Texture2D tex1 = Raylib.LoadTexture("Bilder/backgrounds/Bakgrundsbild-top-mid.png");
List<Rectangle> coll1 = new();

Texture2D tex2 = Raylib.LoadTexture("Bilder/backgrounds/Bakgrundsbild-top-right.png");
List<Rectangle> coll2 = new();

Texture2D tex3 = Raylib.LoadTexture("Bilder/backgrounds/Bakgrundsbild-down-left.png");
List<Rectangle> coll3 = new();

Texture2D tex4 = Raylib.LoadTexture("Bilder/backgrounds/Bakgrundsbild-down-mid.png");
List<Rectangle> coll4 = new();

Texture2D tex5 = Raylib.LoadTexture("Bilder/backgrounds/Bakgrundsbild-down-right.png");
List<Rectangle> coll5 = new();

coll0.Add(new Rectangle(0, 0, 1300, 25));
coll0.Add(new Rectangle(200, 100, 125, 150));
coll0.Add(new Rectangle(705, 100, 125, 150));
coll0.Add(new Rectangle(0, 695, 1300, 25));
coll0.Add(new Rectangle(0, 0, 25, 800));

coll1.Add(new Rectangle(0, 0, 1300, 25));
coll1.Add(new Rectangle(0, 650, 390, 75));
coll1.Add(new Rectangle(720, 650, 600, 75));

coll2.Add(new Rectangle(0, 0, 1300, 25));
coll2.Add(new Rectangle(0, 700, 1300, 25));
coll2.Add(new Rectangle(1260, 0, 25, 800));
coll2.Add(new Rectangle(400, 0, 650, 250));

coll4.Add(new Rectangle(720, 0, 650, 100));
coll4.Add(new Rectangle(0, 0, 390, 100));
coll4.Add(new Rectangle(0, 700, 1300, 25));

coll3.Add(new Rectangle(0, 700, 1300, 25));
coll3.Add(new Rectangle(0, 0, 30, 720));
coll3.Add(new Rectangle(0, 0, 300, 25));
coll3.Add(new Rectangle(300, 0, 700, 200));
coll3.Add(new Rectangle(900, 0, 400, 100));

coll5.Add(new Rectangle(0, 700, 1300, 25));
coll5.Add(new Rectangle(695, 150, 575, 800));
coll5.Add(new Rectangle(450, 100, 775, 40));
coll5.Add(new Rectangle(450, 100, 2, 300));
coll5.Add(new Rectangle(0, 0, 1000, 75));



Background[,] background = new Background[2, 3]
 {
    {new Background(tex0, coll0), new Background(tex1, coll1), new Background(tex2, coll2),},
    {new Background(tex3, coll3), new Background(tex4, coll4), new Background(tex5, coll5),}
};

//själva spelet
while (!Raylib.WindowShouldClose())
{
    lastPosition = new Vector2(player.character.x, player.character.y);


    whichway = player.checkBackgound();
    if (!(whichway == noll))
    {
        current = current + whichway;
        teleport(player);
    };

    if (InsideStore && Raylib.IsKeyDown(KeyboardKey.KEY_ESCAPE))
    {
        player.character.y = 350;
        InsideStore = false;
        LoveStore.Shop = false;
    }

    if (!InsideStore)
    {
        player.checkWalking();
    }
    if (baby.Born == true && player.character.x > 200 && player.character.y < 600)
    {
        baby.bacon();

    }
    if (player.character.x > 400) { Inventory.InteractLogic(); }
    SceneManager();
    LoveStore.produkter();
    Draw();
    if (InsideStore) { LoveStore.storeLogic(); }



}

//rita saker
void Draw()
{
    Raylib.BeginDrawing();

    Raylib.DrawTexturePro(background[(int)current.Y, (int)current.X].backgroundImage, Source, Destination, new Vector2(0, 0), 0, Color.WHITE);

    player.drawCharacter();
    Potatoes.drawPotato();
    Potatoes.drawPeng();
    Potatoes.drawBacon();
    Raylib.DrawText($"{LoveStore.Pengar}", 85, 660, 50, Color.BLACK);
    Raylib.DrawText($"{baby.amountBacon}", 1200, 20, 50, Color.BLACK);



    if (current == LoveStoreFRAME && player.character.y <= 225 && player.character.x < 650 && player.character.x > 520)
    {
        LoveStore.DrawStore1();
        LoveStore.Info();
        InsideStore = true;
    }


    if (current == GRISFRAME)
    {
        if (!Hide)
        {
            Gris1.drawPig1();
            Gris2.drawPig2();

        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && Potatoes.AmountPotatoes >= 2)
        {
            Grisar_i_Rörelse = true;
            Potatoes.AmountPotatoes -= 2;
        }

        if (Grisar_i_Rörelse)
        {
            Gris1.SexingACTIVE();
            Gris2.SexingACTIVE();
            baby.SexingACTIVE();



            if (baby.Born)
            { baby.drawBaby(); }
        }

        Raylib.DrawTexturePro(KILLER, Source, Destination, noll, 0, Color.WHITE);
        Inventory.DrawPigClothes();

    }


    Raylib.EndDrawing();

}

static void teleport(Player player)
{
    if (player.character.x <= 10)
    {
        player.character.x = 1000;
    }
    else if (player.character.y <= 10)
    {
        player.character.y = 500;
    }
    else if (player.character.x >= (Raylib.GetScreenWidth() - 150))
    {
        player.character.x = 20;
    }
    else if (player.character.y >= (Raylib.GetScreenHeight() - 150))
    {
        player.character.y = 20;
    }

}




void SceneManager()
{
    //säkerhets kolla om listan är mindre än currentScene
    foreach (Rectangle collider in background[(int)current.Y, (int)current.X].colliders)
    {
        if (Raylib.CheckCollisionRecs(player.character, collider))
        {
            player.character.x = lastPosition.X;
            player.character.y = lastPosition.Y;
        }
    }
}






