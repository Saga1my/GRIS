using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;



namespace Coding
{
    class Stores
    {
        Rectangle Source = new Rectangle(0, 0, 240, 140);
        Rectangle Destination = new Rectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
        Texture2D LoveStore = Raylib.LoadTexture("Bilder/LoveStore.png");
        Texture2D Frej = Raylib.LoadTexture("Bilder/frej.png");
        Vector2 noll = new Vector2(0, 0);
        int FrejKonvo = 0;

        public int Pengar = 25;
        int selectedIndex = 0;


        public bool Shop = false;


        Dictionary<int,string> Produkter1 = new Dictionary<int, string>();
    
        List<int> Selected = new List<int>{
            0,
            1,
            2,
            3,
            4,
            5,
            6,
        };
       
        List<int> Pris1 = new List<int>{
            25,
            45,
            45,
            100,
            150,
            151,
            10000
        };

        public static List<int> inventory = new List<int>();
        List<string> Dialog = new List<string> { "Frej: HEJ! VÄLKOMMMEN TILL MIN BUTIK!", "Jag säljer produkter som gör så att dina djur förökar sig mer produktivt :D", "Klicka på E för att se vårt sortiment av varor!", "Eller så kan du bara vara kvar här och prata med mig antar jag", "Jag hatar ballonger", "Varför försöker du fortfarande prata med mig", "Du vet att din karaktär är stum va?", "Sluta stirra sådär du gör mig jätte obekväm", "Vet du vad, nu är jag riktigt jävla trött på dig", "SLUTA KLICKA ENTER", "Fine, jag ger upp", "Gå härifrån annars kommer jag bara låtsas som om jag ej känner dig" };

        public void produkter()   { if(Produkter1.Count==0&&inventory.Count==0)
            {
                Produkter1.Add(0,"Normal");
                Produkter1.Add(1,"Tvål.............................................................................................................................25kr");
                Produkter1.Add(2,"Protein pulver till grisar........................................................................45kr");
                Produkter1.Add(3,"Röd bow tie...........................................................................................................45kr");
                Produkter1.Add(4,"Mankini......................................................................................................................100kr");
                Produkter1.Add(5,"Sexig Bikini 1.........................................................................................................150kr");
                Produkter1.Add(6,"Sexig Bikini 2........................................................................................................151kr");
                Produkter1.Add(7,"Navel Piercing (RARE)................................................................................10 000kr");
            }
            if(inventory.Count<1){
                Produkter1.Remove(0);
                inventory.Add(0);
            }}
        public void storeLogic()
        {   

            if (Raylib.IsKeyDown(KeyboardKey.KEY_E))
            {
                Shop = true;

            }

            if (Shop)
            {
            
                int CurrentPris = Pris1[selectedIndex];
                
                if (selectedIndex < 0) 
                {
                    selectedIndex = 0;
                }
                else if (selectedIndex >= Pris1.Count) 
                {
                    selectedIndex = Pris1.Count - 1;
                }  

                if (Pengar >= CurrentPris && Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                {
                    Produkter1.Remove(selectedIndex);
                    Pris1.RemoveAt(selectedIndex);
                    Pengar -= (CurrentPris);
                    inventory.Add(selectedIndex);
                    Selected.RemoveAt(selectedIndex);


                }
                
                if (Raylib.IsKeyDown(KeyboardKey.KEY_BACKSPACE))
                {
                    Shop = false;
                }

                if (selectedIndex > 0)
                {
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
                    {
                        selectedIndex -= 1;
                        

                    }
                }
                if (selectedIndex < Selected.Count - 1)
                {
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
                    {
                        selectedIndex += 1;
                        

                    }
                }
            }   
        }
        












        public void DrawStore1()
        {
    
            Raylib.DrawTexturePro(LoveStore, Source, Destination, noll, 0, Color.WHITE);

            Raylib.DrawTexture(Frej, 500, 70, Color.WHITE);
            if (!Shop)
            {
                Raylib.DrawRectangle(100, (Raylib.GetScreenHeight() - 250), 1075, 150, Color.BLACK);
                try
                {
                    Raylib.DrawText(Dialog[FrejKonvo], 140, Raylib.GetScreenHeight() - 230, 25, Color.WHITE);
                    Raylib.DrawText("klicka ENTER för att fortsätta", 140, Raylib.GetScreenHeight() - 140, 25, Color.GRAY);
                }

                catch
                {
                    FrejKonvo = 0;
                    Raylib.DrawText(Dialog[FrejKonvo], 140, Raylib.GetScreenHeight() - 250, 25, Color.WHITE);

                }

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                {
                    FrejKonvo++;
                }
            }

            if(Shop)
            {

                int y = 100;
                Raylib.DrawRectangle(130, 120, 1000, 500, Color.BLACK);
                Raylib.DrawText("Använd pilarna för att navigera och ENTER för att köpa", 150, 540, 30, Color.GRAY);
                Raylib.DrawText("Klicka BACKSPACE för att gå tillbaka", 150, 575, 30, Color.GRAY);
                Raylib.DrawText($"Pengar: {Pengar} kr", 10, 675, 30, Color.WHITE);





               foreach (KeyValuePair<int, string> item in Produkter1)
                {
                    y += 50;



                    if (selectedIndex == item.Key)
                    {
                        Raylib.DrawText(item.Value, 150, y, 30, Color.YELLOW);
                    }
                


                    else
                    {
                        Raylib.DrawText(item.Value, 150, y, 30, Color.WHITE);
                    }
                    
                }
            }
        }









        public void Info()
        {
            Raylib.DrawText("klicka ESC för att lämna butiken", 50, 20, 25, Color.GRAY);

        }
    }
}

