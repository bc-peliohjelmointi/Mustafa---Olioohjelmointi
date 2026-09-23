namespace kertaus10101
{
    using System;

    class KolikonKeraamispeli
    {
        static int pelaajaX = 5, pelaajaY = 5; 
        static int kolikkoX, kolikkoY;        
        static int kolikoitaJaljella = 1;     
        static bool peliKaynnissa = true;     

        static void Main()
        {
         
            AlustaKolikko();

          
            while (peliKaynnissa && kolikoitaJaljella > 0)
            {
                TulostaKartta();
                LiikutaPelaajaa();
            }

            if (kolikoitaJaljella == 0)
            {
                Console.WriteLine("Onneksi olkoon! Keräsit kolikon!");
            }
            else
            {
                Console.WriteLine("Peli lopetettiin.");
            }
        }

        static void AlustaKolikko()
        {
            Random random = new Random();
            kolikkoX = random.Next(1, 10); 
            kolikkoY = random.Next(1, 10);
        }

        static void TulostaKartta()
        {
            Console.Clear();
            for (int y = 1; y <= 10; y++) 
            {
                for (int x = 1; x <= 10; x++) 
                {
                    if (x == pelaajaX && y == pelaajaY)
                        Console.Write("[P]"); 
                    else if (x == kolikkoX && y == kolikkoY)
                        Console.Write("[$]"); 
                    else
                        Console.Write("[ ]"); 
                }d
                Console.WriteLine();
            }
        }

        static void LiikutaPelaajaa()
        {
            Console.WriteLine("Liiku WASD-näppäimillä tai paina Q lopettaaksesi:");
            ConsoleKey syote = Console.ReadKey(true).Key;

            
            if (syote == ConsoleKey.Q)
            {
                peliKaynnissa = false;
                return;
            }

           
            if (syote == ConsoleKey.W && pelaajaY > 1) pelaajaY--; 
            if (syote == ConsoleKey.S && pelaajaY < 10) pelaajaY++; 
            if (syote == ConsoleKey.A && pelaajaX > 1) pelaajaX--; 
            if (syote == ConsoleKey.D && pelaajaX < 10) pelaajaX++; 

            
            if (pelaajaX == kolikkoX && pelaajaY == kolikkoY)
            {
                kolikoitaJaljella = 0; 
            }
        }
    }

}
