using Raylib_cs;
using System.Numerics;
using System.Threading.Tasks;
using Coding;

namespace Pig
{
    class Pigs
    {
        
        
        
        int targetY = 100;
        int targetX = 410;

        bool page1 = true;

        int selectedOutfit1 = 0;
        int selectedOutfit2 = 0;

        int selectedIndex = 0;

        bool right=true;

        int targetY2 = 350;

        int currentFrame = 0;

        int pigkiller = 800;
        float speed = 0.1f;
        Texture2D IdleGris = Raylib.LoadTexture("Bilder/Pig_Walking/Pig-right.png");
        Texture2D Bacon = Raylib.LoadTexture("Bilder/Bacon.png");
        Texture2D Baby = Raylib.LoadTexture("Bilder/Gris_Baby.png");

        Texture2D BabyTexture;

        Stores ItemNumber = new Stores();
        
        List<Texture2D> PigOutfits = new List<Texture2D>{
            Raylib.LoadTexture("Bilder/Pig_Outfits_Torso/Mud.png"),
            Raylib.LoadTexture("Bilder/Pig_Outfits_Torso/Nude.png"),
            Raylib.LoadTexture("Bilder/Pig_Outfits_Torso/Abs.png"),
            Raylib.LoadTexture("Bilder/Pig_Outfits_Torso/BowTie.png"),
            Raylib.LoadTexture("Bilder/Pig_Outfits_Torso/Mankini.png"),
            Raylib.LoadTexture("Bilder/Pig_Outfits_Torso/BikiniBlue.png"),
            Raylib.LoadTexture("Bilder/Pig_Outfits_Torso/BikiniPurple.png"),
            Raylib.LoadTexture("Bilder/Pig_Outfits_Torso/Piercing.png"),
           
        };
        List<Texture2D> PigOutfitsRight = new List<Texture2D>{
            Raylib.LoadTexture("Bilder/PigFits_Right/Mud.png"),
            Raylib.LoadTexture("Bilder/PigFits_Right/Nude.png"),
            Raylib.LoadTexture("Bilder/PigFits_Right/Abs.png"),
            Raylib.LoadTexture("Bilder/PigFits_Right/BowTie.png"),
            Raylib.LoadTexture("Bilder/PigFits_Right/Mankini.png"),
            Raylib.LoadTexture("Bilder/PigFits_Right/Bikini.png"),
            Raylib.LoadTexture("Bilder/PigFits_Right/Bikini_Purple.png"),
            Raylib.LoadTexture("Bilder/PigFits_Right/Piercing.png"),
           
        };
        List<string> PigOutfitsNames = new List<string>{
            "Normal",
            "Ren gris",
            "Abs",
            "Bow tie",
            "Mankini",
            "Blå Bikini",
            "Lila bikini",
           "Navel piercing",
           
        };

        List<Texture2D> PigWalking = new List<Texture2D>{
            Raylib.LoadTexture("Bilder/Pig_Walking/Pig1.png"),
            Raylib.LoadTexture("Bilder/Pig_Walking/Pig2.png"),
            Raylib.LoadTexture("Bilder/Pig_Walking/Pig1.png"),
            Raylib.LoadTexture("Bilder/Pig_Walking/Pig3.png"),
            Raylib.LoadTexture("Bilder/Pig_Walking/Pig-right.png"),
        };

        public bool Hide = false;
        public bool Born = false;

        bool Closet= false;
        
        public int amountBacon = 0;
        

        public Rectangle rectangle = new Rectangle(600, 500, 100, 100);
        public Rectangle rectangle2 = new Rectangle(1075, 220, 100, 100);

        public void drawPig1()
        {
            

            if(rectangle.x==600){currentFrame=4;}
            Texture2D CurrentTexture = PigWalking[currentFrame];
            if(!Hide){
                Raylib.DrawTexture(CurrentTexture, (int)rectangle.x, (int)rectangle.y, Color.WHITE);
                
                if(!right)
                {
                    Raylib.DrawTexture(PigOutfits[selectedOutfit1], (int)rectangle.x, (int)rectangle.y, Color.WHITE);
                }
                else Raylib.DrawTexture(PigOutfitsRight[selectedOutfit1], (int)rectangle.x, (int)rectangle.y, Color.WHITE);

            }

            
        }
        public void drawPig2()
        {
            if(rectangle.x==600){currentFrame=4;}
            Texture2D CurrentTexture = PigWalking[currentFrame];
            if(!Hide){
                Raylib.DrawTexture(CurrentTexture, (int)rectangle.x, (int)rectangle.y, Color.WHITE);
                if(!right)
                {
                    Raylib.DrawTexture(PigOutfits[selectedOutfit2], (int)rectangle.x, (int)rectangle.y, Color.WHITE);
                }
                else Raylib.DrawTexture(PigOutfitsRight[selectedOutfit2], (int)rectangle.x, (int)rectangle.y, Color.WHITE);
            }
            
        }

        public void drawBaby()
        {                   
            Raylib.DrawTexture(BabyTexture, (int)rectangle2.x, (int)rectangle2.y, Color.WHITE);
        }

        public async void SexingACTIVE()
        {
            float deltaY = speed/2;
            right=false;

            if (currentFrame >= PigWalking.Count-2)
            {
                currentFrame = 0;
            }

            
            if(!(rectangle.x==1000)){
                rectangle.x+=4;
                currentFrame+=1;
                
            }
            else if(!(rectangle.y==300)){
                rectangle.y-=4;
                BabyTexture=Baby;
                
                currentFrame+=1;
            }
            else{
                Hide=true;
                await Task.Delay(2000);
                Born=true;
                
                
            }
            
            if(Born==true)
            {   
                if(rectangle2.x<pigkiller){
                   BabyTexture=Bacon;
                }
                while (rectangle2.y > targetY&&rectangle2.x==1075) 
                {
                rectangle2.y -= deltaY;
                await Task.Delay(70);
                }

                while (rectangle2.x > targetX) 
                {
                rectangle2.x -= deltaY;
                await Task.Delay(70);
                }

                while (rectangle2.y < targetY2) 
                {
                rectangle2.y += deltaY;
                await Task.Delay(70);
                }

            }
        
        }

        public void bacon()
            {    if (rectangle2.y>330&&Raylib.IsKeyPressed(KeyboardKey.KEY_E)){
                    amountBacon+=1;
                   
                }}
        

        public void  DrawPigClothes ()
        {   
            if(Closet)
            {
                Raylib.DrawRectangle(130,120,1000,500, Color.WHITE);
                int y = 200;
                Raylib.DrawText("Använd pilarna för att navigera och ENTER för att godkänna",150,540,30,Color.GRAY);
                Raylib.DrawText("Klicka BACKSPACE för att gå tillbaka",150,575,30,Color.GRAY);
                if(page1){
                    Raylib.DrawText("               Gris 1           >",420,150,30,Color.BLACK); 
                }
                else if(!page1){
                    Raylib.DrawText("<            Gris 2           ",420,150,30,Color.BLACK); 
                }
                
                List<int> Inventory = Stores.inventory;
                for (int i = 0; i < Inventory.Count; i++)
                {
                    int itemIndex = Inventory[i];
                    string itemName = PigOutfitsNames[itemIndex];
                    
                    Raylib.DrawText(itemName, 150, y, 30, Color.BLACK);
                    y += 50;
                    

                }
               
                    
                
            
            }

        }
    
            
        
        
        public void InteractLogic (){


            
            List<int> Inventory = Stores.inventory;
            
            if(selectedIndex > 0){
                if(Raylib.IsKeyPressed(KeyboardKey.KEY_UP)){
                selectedIndex-=1;
            }
            }
            if(selectedIndex < Inventory.Count-1){
                if(Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN)){
                    selectedIndex+=1;

                }
            }
            if(Raylib.IsKeyPressed(KeyboardKey.KEY_E)){
                Closet=true;

            }
            if(Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE)){
                Closet=false;

            }
            if((!page1)&&Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT)){
                page1=true;

            }
            if(page1&&Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT)){
                page1=false;

            }
            

    
    
        }
    }
}