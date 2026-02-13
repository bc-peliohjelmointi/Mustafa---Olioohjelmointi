namespace kertaus10101
{
    using System;

    class KolikonKeraamispeli
    {
        static int pelaajaX = 5, pelaajaY = 5; // Pelaajan aloituspaikka
        static int kolikkoX, kolikkoY;         // Kolikon sijainti
        static int kolikoitaJaljella = 1;     // Kolikkojen määrä
        static bool peliKaynnissa = true;     // Onko peli käynnissä

        static void Main()
        {
            // Alustetaan peli
            AlustaKolikko();

            // Pääsilmukka
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
            kolikkoX = random.Next(1, 10); // Satunnainen paikka
            kolikkoY = random.Next(1, 10);
        }

        static void TulostaKartta()
        {
            Console.Clear();
            for (int y = 1; y <= 10; y++) // Kartan korkeus
            {
                for (int x = 1; x <= 10; x++) // Kartan leveys
                {
                    if (x == pelaajaX && y == pelaajaY)
                        Console.Write("[P]"); // Pelaaja
                    else if (x == kolikkoX && y == kolikkoY)
                        Console.Write("[$]"); // Kolikko
                    else
                        Console.Write("[ ]"); // Tyhjä ruutu
                }d
                Console.WriteLine();
            }
        }

        static void LiikutaPelaajaa()
        {
            Console.WriteLine("Liiku WASD-näppäimillä tai paina Q lopettaaksesi:");
            ConsoleKey syote = Console.ReadKey(true).Key;

            // Lopeta peli, jos Q painetaan
            if (syote == ConsoleKey.Q)
            {
                peliKaynnissa = false;
                return;
            }

            // Päivitä pelaajan sijaintia
            if (syote == ConsoleKey.W && pelaajaY > 1) pelaajaY--; // Ylös
            if (syote == ConsoleKey.S && pelaajaY < 10) pelaajaY++; // Alas
            if (syote == ConsoleKey.A && pelaajaX > 1) pelaajaX--; // Vasen
            if (syote == ConsoleKey.D && pelaajaX < 10) pelaajaX++; // Oikea

            // Tarkista, onko pelaaja kolikon kohdalla
            if (pelaajaX == kolikkoX && pelaajaY == kolikkoY)
            {
                kolikoitaJaljella = 0; // Kolikko kerätty
            }
        }
    }

}
